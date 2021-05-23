#include "clculator.h"
#include <QToolButton>
#include <QGridLayout>
#include <qmath.h>
#include <QMessageBox>

using namespace std;

Calculator::Calculator()
{
    m_display_left  = new QLineEdit();
    m_display_right = new QLineEdit();
    m_sign_label    = new QLabel();
    m_base_label    = new QLabel();
    m_power_label    = new QLabel();


    QGridLayout *mainLayout = new QGridLayout;

    m_display_right->setText("0");

    m_display_left->setReadOnly(true);
    m_display_left->setAlignment(Qt::AlignRight);
    m_display_left->setMaxLength(15);
    m_display_left->setStyleSheet("background-color: rgb(46, 47, 48); color: rgb(255, 255, 250)");

    m_display_right->setAlignment(Qt::AlignRight);
    m_display_right->setReadOnly(true);
    m_display_right->setMaxLength(15);
    m_display_right->setStyleSheet("background-color: rgb(46, 47, 48); color: rgb(255, 255, 250)");

    QFont font = m_display_left->font();
    font.setPointSize(font.pointSize() + 8);
    m_display_left->setFont(font);
    m_display_right->setFont(font);

    m_sign_label->setFont(font);
    m_sign_label->setAlignment(Qt::AlignRight);
    m_sign_label->setStyleSheet("background-color: rgb(46, 47, 48); color: rgb(255, 255, 250)");

    m_base_label->setFont(font);
    m_base_label->setAlignment(Qt::AlignRight);
    m_base_label->setStyleSheet("background-color: rgb(46, 47, 48); color: rgb(255, 255, 250)");
    m_base_label->setAlignment(Qt::AlignVCenter);

    m_power_label->setFont(font);
    m_power_label->setAlignment(Qt::AlignRight);
    m_power_label->setStyleSheet("background-color: rgb(46, 47, 48); color: rgb(255, 255, 250)");
    m_power_label->setAlignment(Qt::AlignVCenter);


    for(int i = 0; i < 10; ++i)
        m_digitButtons[i] = createButton(QString::number(i), SLOT(digitClicked()));

    MyButton *pointButton = createButton(".", SLOT(pointClicked()));
    MyButton *changeSignButton  = createButton("+/-", SLOT(changeSignClicked()));

    MyButton *backspaceButton = createButton(m_backspace, SLOT(backspaceClicked()));
    MyButton *clearButton = createButton("C", SLOT(clear()));
    MyButton *clearAllButton = createButton("CA", SLOT(clearALL()));

    MyButton *divisionButton = createButton(m_division_sign, SLOT(doubleOperatorClicked()));
    MyButton *timesButton = createButton(m_times_sign, SLOT(doubleOperatorClicked()));
    MyButton *plusButton = createButton("+", SLOT(doubleOperatorClicked()));
    MyButton *minusButton = createButton("-", SLOT(doubleOperatorClicked()));

    MyButton *power2Button = createButton(m_power_a, SLOT(unaryOperatorClicked()));
    MyButton *powerAButton = createButton(m_power_a, SLOT(OperatorClicked()));
    MyButton *naturalButton = createButton("ln", SLOT(unaryOperatorClicked()));
    MyButton *decinalButton = createButton("lg", SLOT(unaryOperatorClicked()));

    MyButton *equalButton = createButton("=", SLOT(equalClicked()));

    MyButton *logBaseButton = createButton("log", SLOT(unaryOperatorClicked()));
    MyButton *newBaseButton = createButton("log" + m_log_n, SLOT(OperatorClicked()));





    mainLayout->addWidget(m_display_left,  0, 0, 1, 5);
    mainLayout->addWidget(m_sign_label,    1, 4, 1, 1);
    mainLayout->addWidget(m_display_right, 2, 0, 1, 5);

    mainLayout->addWidget(newBaseButton,   3, 0, 1, 1);
    mainLayout->addWidget(m_base_label,    3, 1, 1, 2);

    mainLayout->addWidget(powerAButton,    4, 0, 1, 1);
    mainLayout->addWidget(m_power_label,   4, 1, 1, 2);

    mainLayout->addWidget(clearAllButton,  4, 3, 1, 1);
    mainLayout->addWidget(clearButton,     3, 3, 1, 1);
    mainLayout->addWidget(backspaceButton, 3, 4, 1, 1);




    for (int i = 1; i < 10; ++i)
    {
        int row = ((9 - i) / 3) + 5;
        int column = ((i - 1) % 3) + 1;
        mainLayout->addWidget(m_digitButtons[i], row, column);
    }
    mainLayout->addWidget(m_digitButtons[0], 8, 1);
    mainLayout->addWidget(pointButton,       8, 2);
    mainLayout->addWidget(changeSignButton,  8, 3);

    mainLayout->addWidget(logBaseButton, 5, 0);
    mainLayout->addWidget(decinalButton, 6, 0);
    mainLayout->addWidget(power2Button,  7, 0);
    mainLayout->addWidget(naturalButton, 8, 0);

    mainLayout->addWidget(divisionButton, 4, 4);
    mainLayout->addWidget(timesButton,    5, 4);
    mainLayout->addWidget(minusButton,    6, 4);
    mainLayout->addWidget(plusButton,     7, 4);
    mainLayout->addWidget(equalButton,    8, 4);



    setLayout(mainLayout);

    setStyleSheet("background-color: rgb(46, 47, 48);");


    setGeometry(650, 250, 500, 600);
    setWindowTitle("Calculator");
}



MyButton *Calculator::createButton(const QString text, const char *member)
{   
    MyButton *btn = new MyButton(text);
    QFont font = btn->font();
    font.setPointSize(12);
    btn->setFont(font);
    if (text == "=")
    {
        btn->setStyleSheet("background-color: rgb(146, 189, 108);color: rgb(255, 255, 250)");
    }
    else if(text == "+" || text == m_division_sign || text == "-" || text == m_times_sign)
    {
        btn->setStyleSheet("background-color: rgb(186, 149, 69);color: rgb(255, 255, 250)");
    }
    else if(text == "log" || text == "lg" || text == "ln" || (text == m_power_a && f == false))
    {
        btn->setStyleSheet("background-color: rgb(255, 170, 133)");
        f = true;
    }
    else if(text == "NewBase")
    {
        btn->setStyleSheet("background-color: rgb(46, 47, 48);color: rgb(255, 255, 250)");
    }
    else
    {
        btn->setStyleSheet("background-color: rgb(91, 93, 93);color: rgb(255, 255, 250)");
    }
        connect(btn, SIGNAL(clicked()), this, member);
    return btn;
}

void Calculator::digitClicked()
{
    MyButton *button = (MyButton*)sender();
    //double all_number;
    int digit = button->text().toInt();

    if (f_log == false && f_power == false)
    {
        // Печать на главную строку
        if(m_display_right->text() == "#ERROR#")
            m_display_right->setText("0");


        if (m_display_right->text() == "0")
        {
            m_display_right->clear();
            m_display_left->clear();
        }

        m_display_right->setText(m_display_right->text() + QString::number(digit));
    }
    else if (f_log == true)
    {
        // Печать на строку логарифма
        if (m_base_label->text() == "log0")
        {
            m_base_label->clear();
            m_base_label->setText("log");
            log_base = digit;
            m_base_label->setText(m_base_label->text() + QString::number(digit));
        }
        else
        {
            m_base_label->setText(m_base_label->text() + QString::number(digit));
            log_base = m_base_label->text().remove(0, 3).toDouble();
        }
    }
    else if (f_power == true)
    {
        // Печать на строку степени
        if (m_power_label->text() == "x0")
        {
            m_power_label->clear();
            m_power_label->setText("x");
            power_n = digit;
            m_power_label->setText(m_power_label->text() + QString::number(digit));
        }
        else
        {
            m_power_label->setText(m_power_label->text() + QString::number(digit));
            power_n = m_power_label->text().remove(0, 1).toDouble();
        }
    }
}

// Проверка на наличие кнопки, и ее добавление к стороке, если ее нет
void Calculator::pointClicked()
{
    if(f_log == false && f_power == false)
    {
        if (!m_display_right->text().contains("."))
        {
            m_display_right->setText(m_display_right->text() + ".");
        }
    }
    else if (f_log == true)
    {
        if (!m_base_label->text().contains("."))
        {
            m_base_label->setText(m_base_label->text() + ".");
            f_point = true;
        }
    }
    else if (f_power == true)
    {
        if (!m_power_label->text().contains("."))
        {
            m_power_label->setText(m_power_label->text() + ".");
            f_point = true;
        }
    }
}

void Calculator::changeSignClicked()
{
    if(f_log == false && f_power == false)
    {
        QString text = m_display_right->text();
        double val = text.toDouble();
        if(val > 0.0)
        {
            text.prepend("-");
        }
        else if(val < 0.0)
        {
            text.remove(0, 1);
        }
        m_display_right->setText(text);
    }
    else if (f_power == true)
    {
        QString text = m_power_label->text().remove(0, 1);
        double val = power_n;
        if(val > 0.0)
        {
            text.prepend("-");
        }
        else if(val < 0.0)
        {
            text.remove(0, 1);
        }
        power_n *= -1;
        m_power_label->setText("x" + text);
    }
}

// Удаление последнего символа
void Calculator::backspaceClicked()
{
    if (f_log == false && f_power == false)
    {
        QString text = m_display_right->text();
        text.chop(1);

        if (text.isEmpty())
        {
            text = "0";
        }
        m_display_right->setText(text);
    }
    else if (f_log == true)
    {
        QString text = m_base_label->text();
        text.chop(1);

        if (text == "log")
        {
            text = "log0";
        }
        log_base = text.remove(0, 3).toDouble();
        m_base_label->setText("log" + text);
    }
    else if (f_power == true)
    {
        QString text = m_power_label->text();
        text.chop(1);

        if (text == "x")
        {
            text = "x0";
        }
        power_n = text.remove(0, 1).toDouble();
        m_power_label->setText("x" + text);
    }
}

// Удаление нижней строки.
void Calculator::clear()
{
    if (f_log == false && f_power == false)
    {
        m_display_right->setText("0");
    }
    else if (f_log == true)
    {
        m_base_label->setText("log0");
    }
    else if (f_power == true)
    {
        m_power_label->setText("x0");
    }
}

// Удаление верхней и нижней строк.
void Calculator::clearALL()
{
    if (f_log == true)
        m_base_label->setText("log0");
    if (f_power == true)
        m_power_label->setText("x0");
    m_display_left->setText("");
    m_display_right->setText("0");
    m_operations.clear();
    m_sign_label->setText("");
}

void Calculator::unaryOperatorClicked()
{
    if (f_log == false && f_power == false)
    {
        MyButton *button = (MyButton*)sender();
        QString operation = button->text();

        double operand = m_display_right->text().toDouble();
        double result = 0.0;

        if (operation == m_power_a)
        {
            if(operand == 0.0)
            {
                abortOperation();
                return;
            }
            result = pow(operand, power_n);
        }
        else if(operation == "ln")
        {
            if (operand <= 0)
            {
                abortOperation();
                return;
            }
            result = qLn(operand);
        }
        else if(operation == "lg")
        {
            if (operand <= 0)
            {
                abortOperation();
                return;
            }
            result = log10(operand);
        }
        else if(operation == "log")
        {
            if (operand <= 0 || log_base == 1 || log_base <= 0)
            {
                abortOperation();
                return;
            }
            result = log(operand)/log(log_base);
        }

        m_display_right->setText(QString::number(result));
    }
}

// Проверка на выполнение операций '+', '-', '*', '/'.
void Calculator::doubleOperatorClicked()
{
    if(f_log == false && f_power == false)
    {
        MyButton *button = (MyButton*)sender();
        QString operation = button->text();

        double operand = m_display_right->text().toDouble();

        if (m_display_right->text() == "0")
            return;

        m_sign_label->setText(operation);

        if (m_display_right->text() == "")
            return;

        m_display_right->clear();

        if (!m_operations.isEmpty())
        {
            if (!calculate(operand, m_operations))
            {
                abortOperation();
                return;
            }
        }
        else
        {
            m_display_left->setText(QString::number(operand));
        }
        m_operations = operation;
    }
}

void Calculator::OperatorClicked()
{
    MyButton *button = (MyButton*)sender();
    QString operation = button->text();

    if (operation == "log" + m_log_n || operation == "log" + m_log_n2)
    {
        if (log_base == 2)
            button->setText("log" + m_log_n);
        else
            button->setText("log" + m_log_n2);

        if (f_log == false)
        {
            f_log = true;
            if (f_power == true)
            {
                f_power = false;
                m_power_label->setText("");
            }
            m_base_label->setText("log" + QString::number(log_base));
        }
        else
        {
            f_log = false;
            m_base_label->setText("");
        }
    }
    else if (operation == m_power_a || operation == m_power_2)
    {
        if (power_n == 2)
            button->setText(m_power_2);
        else
            button->setText(m_power_a);
        if (f_power == false)
        {
            f_power = true;
            if (f_log == true)
            {
                f_log = false;
                m_base_label->setText("");
            }
            m_power_label->setText("x" + QString::number(power_n));
        }
        else
        {
            f_power = false;
            m_power_label->setText("");
        }
    }
}

// Проверка на выполнение пред. операции, и вывод результата.
void Calculator::equalClicked()
{
    if (f_log == false && f_power == false)
    {
        double operand = m_display_right->text().toDouble();
        if (m_display_left->text() != ""){
            if (!m_operations.isEmpty())
            {
                if (!calculate(operand, m_operations))
                {
                    abortOperation();
                    return;
                }
                m_operations.clear();
            }
            m_display_right->setText(m_display_left->text());
            m_display_left->clear();
            m_sign_label->clear();
        }
    }
}

// Вывод ошибки.
void Calculator::abortOperation()
{
    if (m_display_left->text() != "")
        m_display_left->setText("#ERROR#");
    m_display_right->setText("#ERROR#");
}

// Выполнение операций '+', '-', '*', '/'.
bool Calculator::calculate(double operand, const QString &operation)
{
    double temp_total = m_display_left->text().toDouble();

    if(operation == "+")
        temp_total += operand;
    else if(operation == "-")
        temp_total -= operand;
    else if(operation == m_times_sign)
        temp_total *= operand;
    else if(operation == m_division_sign)
    {
        if (operand == 0.0)
            return false;
        temp_total /= operand;
    }
    m_display_left->setText(QString::number(temp_total));
    return true;
}

