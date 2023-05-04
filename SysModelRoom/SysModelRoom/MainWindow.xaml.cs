using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SysModelRoom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool fDoor = false;
        bool sDoor = false;
        bool fWindow = false;
        bool sWindow = false;
        bool fHeater = false;
        bool sHeater = false;
        bool fStart = false;
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            timer.Start();
        }
        void timerTick(object sender, EventArgs e)
        {
            start.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            List<string> helper = new List<string>();
            if (fWindow == true)//Первое окно открыто
            {
                roomA.Text = TempWindow(roomA.Text, atmos.Text);
                roomA.Text = TempWindow(heaterA.Text, atmos.Text);
            }
            if (sWindow == true)//Второе окно открыто
            {
                roomB.Text = TempWindow(roomB.Text, atmos.Text);
                roomB.Text = TempWindow(heaterB.Text, atmos.Text);
            }
            if (fHeater == true)
            {
                if (Convert.ToDecimal(desireA.Text) > Convert.ToDecimal(roomA.Text))
                {
                    heaterA.Text = Convert.ToString(Convert.ToDecimal(heaterA.Text) + 1);
                }
                else// if(Convert.ToDecimal(desireA.Text) != Convert.ToDecimal(roomA.Text))
                {
                    if (desireA.Text != roomA.Text)
                        heaterA.Text = Convert.ToString(Convert.ToDecimal(heaterA.Text) - 1);
                }
            }
            if (sHeater == true)
            {
                if (Convert.ToDecimal(desireB.Text) > Convert.ToDecimal(roomB.Text))
                {
                    heaterB.Text = Convert.ToString(Convert.ToDecimal(heaterB.Text) + 2);
                }
                else// if(Convert.ToDecimal(desireB.Text) != Convert.ToDecimal(roomB.Text))
                {
                    if (desireB.Text != roomB.Text)
                        heaterB.Text = Convert.ToString(Convert.ToDecimal(heaterB.Text) - 1);
                }
            }
            if (Convert.ToDecimal(roomA.Text) != Convert.ToDecimal(desireA.Text))
            {
                helper = TempObj(roomA.Text, heaterA.Text);//вспомогательный элемент обмена темп между кондиционером1 и комнатой1
                roomA.Text = helper[0];
                heaterA.Text = helper[1];
            }
            if (Convert.ToDecimal(roomB.Text) != Convert.ToDecimal(desireB.Text))
            {
                helper = TempObj(roomB.Text, heaterB.Text);//вспомогательный элемент обмена темп между кондиционером2 и комнатой2
                roomB.Text = helper[0];
                heaterB.Text = helper[1];
            }
            if (sDoor == true)//если дверь между 2 комнатами открыта
            {
                helper = TempObj(roomA.Text, roomB.Text);
                roomA.Text = helper[0];
                roomB.Text = helper[1];

            }

            if (fDoor == true)//если дверь между улицей и комнатой 1 закрыта
            {
                roomA.Text = TempDoor(roomA.Text, atmos.Text);
            }
        }
        public string TempWindow(string first, string window) //взаимодействие окна с комнатой
        {
            string result = "";
            decimal FNumber = Convert.ToDecimal(first);
            decimal SNumber = Convert.ToDecimal(window);
            decimal helper = Math.Abs(SNumber - FNumber) / 8;
            if ((helper < Convert.ToDecimal(0.01)) && (helper != 0))
            {
                helper = Convert.ToDecimal(0.01);
            }
            if (SNumber < FNumber)
            {
                FNumber = FNumber - helper;
            }
            else
            {
                FNumber = FNumber + helper;
            }
            result = Convert.ToString(Math.Round(FNumber, 2));
            return result;
        }
        public string TempDoor(string first, string window) //взаимодействие двери с комнатой
        {
            string result = "";
            decimal FNumber = Convert.ToDecimal(first);
            decimal SNumber = Convert.ToDecimal(window);
            decimal helper = Math.Abs(SNumber - FNumber) / 8;
            if ((helper < Convert.ToDecimal(0.01)) && (helper != 0))
            {
                helper = Convert.ToDecimal(0.01);
            }
            if (SNumber < FNumber)
            {
                FNumber = FNumber - helper;
            }
            else
            {
                FNumber = FNumber + helper;
            }
            result = Convert.ToString(Math.Round(FNumber, 2));
            return result;
        }
        public List<string> TempObj(string first, string window) //взаимодействия в комнате
        {
            List<string> result = new List<string>() { "", "" };
            decimal FNumber = Convert.ToDecimal(first);
            decimal SNumber = Convert.ToDecimal(window);
            decimal helper = Math.Abs(SNumber - FNumber) /8;
            if ((helper < Convert.ToDecimal(0.001)) && (helper != 0))
            {
                helper = Convert.ToDecimal(0.001);
            }
            if (SNumber < FNumber)
            {
                FNumber = FNumber - helper;
                SNumber = SNumber + helper;
            }
            else
            {
                FNumber = FNumber + helper;
                SNumber = SNumber - helper;
            }
            result[0] = Math.Round(FNumber, 2).ToString();
            result[1] = Math.Round(SNumber, 2).ToString();
            return result;
        }

        private void FirstDoor(object sender, RoutedEventArgs e)
        {
            if (fDoor == false) door1.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else door1.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            fDoor = !fDoor;
        }

        private void door2_Click(object sender, RoutedEventArgs e)
        {
            if (sDoor == false) door2.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else door2.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            sDoor = !sDoor;
        }

        private void window1_Click(object sender, RoutedEventArgs e)
        {
            if (fWindow == false) window1.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else window1.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            fWindow = !fWindow;
        }

        private void window2_Click(object sender, RoutedEventArgs e)
        {
            if (sWindow == false) window2.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else window2.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            sWindow = !sWindow;
        }

        private void heater2_Click(object sender, RoutedEventArgs e)
        {
            if (sHeater == false) heater2.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else heater2.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            sHeater = !sHeater;
        }

        private void heater1_Click(object sender, RoutedEventArgs e)
        {
            if (fHeater == false) heater1.Background = new SolidColorBrush(Color.FromRgb(121, 222, 63));
            else heater1.Background = new SolidColorBrush(Color.FromRgb(249, 104, 104));
            fHeater = !fHeater;
        }

        private void star_Click(object sender, RoutedEventArgs e)
        {
            if (fStart == false)
            {
                
            }
        }
    }
}
