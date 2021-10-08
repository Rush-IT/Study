#include "myglw.h"
#include <QPainter>


MyGLW::MyGLW(QWidget *parent):QOpenGLWidget(parent)
{
    mypainter = new MyPainter;
}

void MyGLW::redraw()
{
    this->update();
}

void MyGLW::paintEvent(QPaintEvent *event)
{
    QPainter painter;
    painter.begin(this);
    mypainter->draw(&painter, event);
    painter.end();
}

void MyGLW::mousePressEvent(QMouseEvent *event)
{
    extern QVector<double> Xpointer;
    extern QVector<double> Ypointer;
    extern QVector <QVector <int>> mass;
    extern QVector<QVector <bool>> PushMove;
    extern QVector <QVector <int>> FigureMove;
    extern QVector <QVector <int>> NewBoardColor;
    int king = (move == "WHITE") ? 6 : -6;
    for (int i = 0; i < 8; ++i)
        for (int j = 0; j < 8; ++j)
            if (mass[i][j] == king) king = 606;
    if (king !=606)
    {
        return;
    }
    double a_x, a_y;
    int i_x = -1, i_y = -1;
    a_x = event->x();
    a_y = event->y();
    for(int i = 0; i < 8; ++i)
    {
        //Проверка на клик в зоне клетки
        if (a_x > Xpointer[0] && a_x < Xpointer[i + 1] && i_x == -1) i_x = i;
        if (a_y > Ypointer[0] && a_y < Ypointer[i + 1] && i_y == -1) i_y = i;

    }
    //Проверка на нажатие на одну и ту же клетку
    if(XClickCell == i_x && YClickCell == i_y)
    {
        XClickCell = -1;
        YClickCell = -1;
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                NewBoardColor[i][j] = 0;
                FigureMove[i][j] = 0;
            }
        }
    }
    else if (i_x != -1 && i_y != -1)
    {
        //Проверка на первый клик по клетке
        if (XClickCell != -1 && YClickCell != -1)
        {
            //В случае второго клика
            //По заданным координатам ставится фигура
            move_piece(i_x, i_y);
            //Происходит возвращение всех переменных в обычное состояние
            XClickCell = -1;
            YClickCell = -1;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    NewBoardColor[i][j] = 0;
                    FigureMove[i][j] = 0;

                }
            }
            if (!Pushmove)
            {
                for(int i = 0; i < 8; ++i)
                {
                    PushMove[0][i] = false;
                    PushMove[1][i] = false;
                }
                Pushmove = false;
            }
        }
        else
        {
            //В случае первого клика
            //Происходит сохранение координат
            XClickCell = i_x;
            YClickCell = i_y;
            //Проверка на клик в зону фигуры
            if (!ColorMove(i_x, i_y))
            {
                XClickCell = -1;
                YClickCell = -1;
                for (int i = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 8; ++j)
                    {
                        NewBoardColor[i][j] = 0;
                        FigureMove[i][j] = 0;
                    }
                }
            }
        }
    }

    update();
}

bool MyGLW::ColorMove(int x, int y)
{
    extern QVector <QVector<int>> mass;
    extern QVector <QVector <int>> NewBoardColor;
    extern QVector <QVector <bool>> PushMove;
    extern QVector <QVector <int>> FigureMove;
    if (move == "WHITE")
    {
        switch(mass[y][x])
        {
        //Пешка
        case 1:
            NewBoardColor[y][x] = 1;
            if (y-1 >=0 && mass[y-1][x] == 0) NewBoardColor[y-1][x] = 2;
            if (y == 6 && mass[y-2][x] == 0) NewBoardColor[y-2][x] = 2;
            if (y-1 >=0 && x+1 < 8 && mass[y-1][x+1] < 0) NewBoardColor[y-1][x+1] = 1;
            if (y-1 >=0 && x-1 >=0 && mass[y-1][x-1] < 0) NewBoardColor[y-1][x-1] = 1;
            if (x+1 < 8 && mass[y-1][x+1] == 0 && y == 3 && PushMove[1][x+1])
            {
                NewBoardColor[y-1][x+1] = 2;
            }
            if (x-1 >=0 && mass[y-1][x-1] == 0 && y == 3 && PushMove[1][x-1])
            {
                NewBoardColor[y-1][x-1] = 2;
            }
            break;
        //Конь
        case 2:
            NewBoardColor[y][x] = 1;

            if (y-2 >=0 && x+1 < 8 && mass[y-2][x+1] <= 0) NewBoardColor[y-2][x+1] = (mass[y-2][x+1] == 0) ? 2 : 1;
            if (y-2 >=0 && x-1 >=0 && mass[y-2][x-1] <= 0) NewBoardColor[y-2][x-1] = (mass[y-2][x-1] == 0) ? 2 : 1;
            if (y+1 < 8 && x+2 < 8 && mass[y+1][x+2] <= 0) NewBoardColor[y+1][x+2] = (mass[y+1][x+2] == 0) ? 2 : 1;
            if (y-1 >=0 && x+2 < 8 && mass[y-1][x+2] <= 0) NewBoardColor[y-1][x+2] = (mass[y-1][x+2] == 0) ? 2 : 1;
            if (y+2 < 8 && x+1 < 8 && mass[y+2][x+1] <= 0) NewBoardColor[y+2][x+1] = (mass[y+2][x+1] == 0) ? 2 : 1;
            if (y+2 < 8 && x-1 >=0 && mass[y+2][x-1] <= 0) NewBoardColor[y+2][x+1] = (mass[y+2][x+1] == 0) ? 2 : 1;
            if (y+1 < 8 && x-2 >=0 && mass[y+1][x-2] <= 0) NewBoardColor[y+1][x-2] = (mass[y+1][x-2] == 0) ? 2 : 1;
            if (y-1 >=0 && x-2 >=0 && mass[y-1][x-2] <= 0) NewBoardColor[y-1][x-2] = (mass[y-1][x-2] == 0) ? 2 : 1;

            break;
        //Слон
        case 3:
            NewBoardColor[y][x] = 1;
            bool f;int i;
            f = false;
            i = 0;
            while(y+i < 8 && x+i < 8 && !f)
            {
                if (mass[y+i][x+i] != 0 && i != 0) f = true;
                if (mass[y+i][x+i] <= 0)
                {
                    NewBoardColor[y+i][x+i] = (mass[y+i][x+i] == 0) ? 2 : 1;
                    FigureMove[y+i][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y+i < 8 && x-i >=0 && !f)
            {
                if (mass[y+i][x-i] != 0 && i != 0) f = true;
                if (mass[y+i][x-i] <= 0)
                {
                    NewBoardColor[y+i][x-i] = (mass[y+i][x-i] == 0) ? 2 : 1;
                    FigureMove[y+i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x-i >=0 && !f)
            {
                if (mass[y-i][x-i] != 0 && i != 0) f = true;
                if (mass[y-i][x-i] <= 0)
                {
                    NewBoardColor[y-i][x-i] = (mass[y-i][x-i] == 0) ? 2 : 1;
                    FigureMove[y-i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x+i < 8 && !f)
            {
                if (mass[y-i][x+i] != 0 && i != 0) f = true;
                if (mass[y-i][x+i] <= 0)
                {
                    NewBoardColor[y-i][x+i] = (mass[y-i][x+i] == 0) ? 2 : 1;
                    FigureMove[y-i][x+i]++;
                }
                i++;
            }
            break;
        //Ладья
        case 4:
            NewBoardColor[y][x] = 1;
            i = 0;
            f = false;
            while(y+i < 8 && !f)
            {
                if (mass[y+i][x] != 0 && i != 0) f = true;
                if (mass[y+i][x] <= 0)
                {
                    NewBoardColor[y+i][x] = (mass[y+i][x] == 0) ? 2 : 1;
                    FigureMove[y+i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && !f)
            {
                if (mass[y-i][x] != 0 && i != 0) f = true;
                if (mass[y-i][x] <= 0)
                {
                    NewBoardColor[y-i][x] = (mass[y-i][x] == 0) ? 2 : 1;
                    FigureMove[y-i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x+i < 8 && !f)
            {
                if (mass[y][x+i] != 0 && i != 0) f = true;
                if (mass[y][x+i] <= 0)
                {
                    NewBoardColor[y][x+i] = (mass[y][x+i] == 0) ? 2 : 1;
                    FigureMove[y][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x-i >= 0 && !f)
            {
                if (mass[y][x-i] != 0 && i != 0) f = true;
                if (mass[y][x-i] <= 0)
                {
                    NewBoardColor[y][x-i] = (mass[y][x-i] == 0) ? 2 : 1;
                    FigureMove[y][x-i]++;
                }
                i++;
            }
            break;
        //Ферзь
        case 5:
            NewBoardColor[y][x] = 1;
            f = false;
            i = 0;
            while(y+i < 8 && x+i < 8 && !f)
            {
                if (mass[y+i][x+i] != 0 && i != 0) f = true;
                if (mass[y+i][x+i] <= 0)
                {
                    NewBoardColor[y+i][x+i] = (mass[y+i][x+i] == 0) ? 2 : 1;
                    FigureMove[y+i][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y+i < 8 && x-i >=0 && !f)
            {
                if (mass[y+i][x-i] != 0 && i != 0) f = true;
                if (mass[y+i][x-i] <= 0)
                {
                    NewBoardColor[y+i][x-i] = (mass[y+i][x-i] == 0) ? 2 : 1;
                    FigureMove[y+i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x-i >=0 && !f)
            {
                if (mass[y-i][x-i] != 0 && i != 0) f = true;
                if (mass[y-i][x-i] <= 0)
                {
                    NewBoardColor[y-i][x-i] = (mass[y-i][x-i] == 0) ? 2 : 1;
                    FigureMove[y-i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x+i < 8 && !f)
            {
                if (mass[y-i][x+i] != 0 && i != 0) f = true;
                if (mass[y-i][x+i] <= 0)
                {
                    NewBoardColor[y-i][x+i] = (mass[y-i][x+i] == 0) ? 2 : 1;
                    FigureMove[y-i][x+i]++;
                }
                i++;
            }
            i = 0;
            f = false;
            while(y+i < 8 && !f)
            {
                if (mass[y+i][x] != 0 && i != 0) f = true;
                if (mass[y+i][x] <= 0)
                {
                    NewBoardColor[y+i][x] = (mass[y+i][x] == 0) ? 2 : 1;
                    FigureMove[y+i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && !f)
            {
                if (mass[y-i][x] != 0 && i != 0) f = true;
                if (mass[y-i][x] <= 0)
                {
                    NewBoardColor[y-i][x] = (mass[y-i][x] == 0) ? 2 : 1;
                    FigureMove[y-i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x+i < 8 && !f)
            {
                if (mass[y][x+i] != 0 && i != 0) f = true;
                if (mass[y][x+i] <= 0)
                {
                    NewBoardColor[y][x+i] = (mass[y][x+i] == 0) ? 2 : 1;
                    FigureMove[y][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x-i >= 0 && !f)
            {
                if (mass[y][x-i] != 0 && i != 0) f = true;
                if (mass[y][x-i] <= 0)
                {
                    NewBoardColor[y][x-i] = (mass[y][x-i] == 0) ? 2 : 1;
                    FigureMove[y][x-i]++;
                }
                i++;
            }
            break;
        //Король
        case 6:
            NewBoardColor[y][x] = 1;


            if (long_white || white)
            {
                bool f = false;
                if (white && mass[y][x+1] != 0) f = true;
                if (white && mass[y][x+2] != 0) f = true;
                if (white && !f)
                {
                    NewBoardColor[y][x+2] = 2;
                    FigureMove[y][x+2]++;
                }
                f = false;
                int i = 1;
                while (long_white && !f && i < 4)
                {
                    if (mass[y][x-i] !=0) f = true;
                    i++;
                }
                if (!f && long_white)
                {
                    NewBoardColor[y][x-2] = 2;
                    FigureMove[y][x-2]++;
                }
            }


            for (int i = y-1; i < y+2; ++i)
            {
                for (int j = x-1; j < x+2; ++j)
                {
                    if (i>=0 && i<8 && j>=0 && j<8 && mass[i][j] <=0)
                    {
                        NewBoardColor[i][j] = (mass[i][j] == 0) ? 2 : 1;
                        FigureMove[i][j]++;
                    }
                }
            }
            break;
        default:
            return false;
        }
    }
    else
    {
        //Черные фигуры
        switch(mass[y][x])
        {
        //Пешка
        case -1:
            NewBoardColor[y][x] = 1;
            if (y == 7)
            {
                mass[y][x] = 5;
                break;
            }
            if (mass[y+1][x] == 0) NewBoardColor[y+1][x] = 2;
            if (x+1 < 8 && mass[y+1][x+1] > 0) NewBoardColor[y+1][x+1] = 1;
            if (x-1 >=0 && mass[y+1][x-1] > 0) NewBoardColor[y+1][x-1] = 1;
            if (mass[y+2][x] == 0 && y == 1) NewBoardColor[y+2][x] = 2;
            if (x+1 < 8 && mass[y+1][x+1] == 0 && y == 4 && PushMove[0][x+1])
            {
                NewBoardColor[y+1][x+1] = 2;
            }
            if (x-1 >=0 && mass[y+1][x-1] == 0 && y == 4 && PushMove[0][x-1])
            {
                NewBoardColor[y+1][x-1] = 2;
            }
            break;
        //Конь
        case -2:
            NewBoardColor[y][x] = 1;

            if (y-2 >=0 && x+1 < 8 && mass[y-2][x+1] >= 0) NewBoardColor[y-2][x+1] = (mass[y-2][x+1] == 0) ? 2 : 1;
            if (y-2 >=0 && x-1 >=0 && mass[y-2][x-1] >= 0) NewBoardColor[y-2][x-1] = (mass[y-2][x-1] == 0) ? 2 : 1;
            if (y+1 < 8 && x+2 < 8 && mass[y+1][x+2] >= 0) NewBoardColor[y+1][x+2] = (mass[y+1][x+2] == 0) ? 2 : 1;
            if (y-1 >=0 && x+2 < 8 && mass[y-1][x+2] >= 0) NewBoardColor[y-1][x+2] = (mass[y-1][x+2] == 0) ? 2 : 1;
            if (y+2 < 8 && x+1 < 8 && mass[y+2][x+1] >= 0) NewBoardColor[y+2][x+1] = (mass[y+2][x+1] == 0) ? 2 : 1;
            if (y+2 < 8 && x-1 >=0 && mass[y+2][x-1] >= 0) NewBoardColor[y+2][x-1] = (mass[y+2][x-1] == 0) ? 2 : 1;
            if (y+1 < 8 && x-2 >=0 && mass[y+1][x-2] >= 0) NewBoardColor[y+1][x-2] = (mass[y+1][x-2] == 0) ? 2 : 1;
            if (y-1 >=0 && x-2 >=0 && mass[y-1][x-2] >= 0) NewBoardColor[y-1][x-2] = (mass[y-1][x-2] == 0) ? 2 : 1;

            break;
        //Слон
        case -3:
            NewBoardColor[y][x] = 1;
            bool f;int i;
            f = false;
            i = 0;
            while(y+i < 8 && x+i < 8 && !f)
            {
                if (mass[y+i][x+i] != 0 && i != 0) f = true;
                if (mass[y+i][x+i] >= 0)
                {
                    NewBoardColor[y+i][x+i] = (mass[y+i][x+i] == 0) ? 2 : 1;
                    FigureMove[y+i][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y+i < 8 && x-i >=0 && !f)
            {
                if (mass[y+i][x-i] != 0 && i != 0) f = true;
                if (mass[y+i][x-i] >= 0)
                {
                    NewBoardColor[y+i][x-i] = (mass[y+i][x-i] == 0) ? 2 : 1;
                    FigureMove[y+i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x-i >=0 && !f)
            {
                if (mass[y-i][x-i] != 0 && i != 0) f = true;
                if (mass[y-i][x-i] >= 0)
                {
                    NewBoardColor[y-i][x-i] = (mass[y-i][x-i] == 0) ? 2 : 1;
                    FigureMove[y-i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x+i < 8 && !f)
            {
                if (mass[y-i][x+i] != 0 && i != 0) f = true;
                if (mass[y-i][x+i] >= 0)
                {
                    NewBoardColor[y-i][x+i] = (mass[y-i][x+i] == 0) ? 2 : 1;
                    FigureMove[y-i][x+i]++;
                }
                i++;
            }
            break;
        //Ладья
        case -4:
            NewBoardColor[y][x] = 1;
            i = 0;
            f = false;
            while(y+i < 8 && !f)
            {
                if (mass[y+i][x] != 0 && i != 0) f = true;
                if (mass[y+i][x] >= 0)
                {
                    NewBoardColor[y+i][x] = (mass[y+i][x] == 0) ? 2 : 1;
                    FigureMove[y+i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && !f)
            {
                if (mass[y-i][x] != 0 && i != 0) f = true;
                if (mass[y-i][x] >= 0)
                {
                    NewBoardColor[y-i][x] = (mass[y-i][x] == 0) ? 2 : 1;
                    FigureMove[y-i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x+i < 8 && !f)
            {
                if (mass[y][x+i] != 0 && i != 0) f = true;
                if (mass[y][x+i] >= 0)
                {
                    NewBoardColor[y][x+i] = (mass[y][x+i] == 0) ? 2 : 1;
                    FigureMove[y][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x-i >= 0 && !f)
            {
                if (mass[y][x-i] != 0 && i != 0) f = true;
                if (mass[y][x-i] >= 0)
                {
                    NewBoardColor[y][x-i] = (mass[y][x-i] == 0) ? 2 : 1;
                    FigureMove[y][x-i]++;
                }
                i++;
            }
            break;
        //Ферзь
        case -5:
            NewBoardColor[y][x] = 1;
            f = false;
            i = 0;
            while(y+i < 8 && x+i < 8 && !f)
            {
                if (mass[y+i][x+i] != 0 && i != 0) f = true;
                if (mass[y+i][x+i] >= 0)
                {
                    NewBoardColor[y+i][x+i] = (mass[y+i][x+i] == 0) ? 2 : 1;
                    FigureMove[y+i][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y+i < 8 && x-i >=0 && !f)
            {
                if (mass[y+i][x-i] != 0 && i != 0) f = true;
                if (mass[y+i][x-i] >= 0)
                {
                    NewBoardColor[y+i][x-i] = (mass[y+i][x-i] == 0) ? 2 : 1;
                    FigureMove[y+i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x-i >=0 && !f)
            {
                if (mass[y-i][x-i] != 0 && i != 0) f = true;
                if (mass[y-i][x-i] >= 0)
                {
                    NewBoardColor[y-i][x-i] = (mass[y-i][x-i] == 0) ? 2 : 1;
                    FigureMove[y-i][x-i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && x+i < 8 && !f)
            {
                if (mass[y-i][x+i] != 0 && i != 0) f = true;
                if (mass[y-i][x+i] >= 0)
                {
                    NewBoardColor[y-i][x+i] = (mass[y-i][x+i] == 0) ? 2 : 1;
                    FigureMove[y-i][x+i]++;
                }
                i++;
            }
            i = 0;
            f = false;
            while(y+i < 8 && !f)
            {
                if (mass[y+i][x] != 0 && i != 0) f = true;
                if (mass[y+i][x] >= 0)
                {
                    NewBoardColor[y+i][x] = (mass[y+i][x] == 0) ? 2 : 1;
                    FigureMove[y+i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(y-i >=0 && !f)
            {
                if (mass[y-i][x] != 0 && i != 0) f = true;
                if (mass[y-i][x] >= 0)
                {
                    NewBoardColor[y-i][x] = (mass[y-i][x] == 0) ? 2 : 1;
                    FigureMove[y-i][x]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x+i < 8 && !f)
            {
                if (mass[y][x+i] != 0 && i != 0) f = true;
                if (mass[y][x+i] >= 0)
                {
                    NewBoardColor[y][x+i] = (mass[y][x+i] == 0) ? 2 : 1;
                    FigureMove[y][x+i]++;
                }
                i++;
            }
            f = false;
            i = 0;
            while(x-i >= 0 && !f)
            {
                if (mass[y][x-i] != 0 && i != 0) f = true;
                if (mass[y][x-i] >= 0)
                {
                    NewBoardColor[y][x-i] = (mass[y][x-i] == 0) ? 2 : 1;
                    FigureMove[y][x-i]++;
                }
                i++;
            }
            break;
        //Король
        case -6:
            NewBoardColor[y][x] = 1;
            if (long_black || black)
            {
                bool f = false;
                if (black && mass[y][x+1] != 0) f = true;
                if (black && mass[y][x+2] != 0) f = true;
                if (black && !f)
                {
                    NewBoardColor[y][x+2] = 2;
                    FigureMove[y][x+2]++;
                }
                f = false;
                int i = 1;
                while (long_black && !f && i < 4)
                {
                    if (mass[y][x-i] !=0) f = true;
                    i++;
                }
                if (!f && long_black)
                {
                    NewBoardColor[y][x-2] = 2;
                    FigureMove[y][x-2]++;
                }
            }
            for (int i = y-1; i < y+2; ++i)
            {
                for (int j = x-1; j < x+2; ++j)
                {
                    if (i>=0 && i<8 && j>=0 && j<8 && mass[i][j] >=0)
                    {
                        NewBoardColor[i][j] = (mass[i][j] == 0) ? 2 : 1;
                        FigureMove[i][j]++;
                    }
                }
            }
            break;
        default:
            return false;
        }
    }
    return true;
}

void MyGLW::move_piece(int x, int y)
{
    extern QVector <QVector <int>> mass;
    extern QVector <QVector <bool>> PushMove;
    extern QVector <QVector <int>> FigureMove;
    if(move == "WHITE")
    {
        switch(mass[YClickCell][XClickCell])
        {
        case 1:
            if (y + 1 == YClickCell)
            {
                if (x == XClickCell || ((x-1 == XClickCell || x+1 == XClickCell) && mass[y][x] < 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    if (y == 0) mass[y][x] = 5;
                    mass[YClickCell][XClickCell] = 0;
                    move = "BLACK";
                }
                else if (((x-1 == XClickCell && mass[y+1][x] < 0) || (x+1 == XClickCell && mass[y+1][x] < 0)) && mass[y][x] == 0 && y+1 == 3)
                {
                    if (PushMove[1][x])
                    {
                        mass[y][x] = mass[YClickCell][XClickCell];
                        mass[YClickCell][XClickCell] = 0;
                        mass[YClickCell][x] = 0;
                        move = "BLACK";
                    }
                }

            }
            else if (y + 2 == YClickCell && y == 4)
            {
                if (x == XClickCell)
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "BLACK";
                    PushMove[0][x] = true;
                    Pushmove = true;
                }
            }
            break;
        case 2:
            if (y - 2 == YClickCell || y + 2 == YClickCell)
            {
                if ((x - 1 == XClickCell || x + 1 == XClickCell) && (mass[y][x] <= 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "BLACK";
                }
            }
            else if (x - 2 == XClickCell || x + 2 == XClickCell)
            {
                if ((y - 1 == YClickCell || y + 1 == YClickCell) && (mass[y][x] <= 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "BLACK";
                }
            }
            break;
        case 3:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "BLACK";
            }
            break;
        case 4:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "BLACK";
                if (XClickCell == 7) white = false;
                if (!XClickCell) long_white = false;
            }
            break;
        case 5:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "BLACK";
            }

            break;
        case 6:
            if (FigureMove[y][x]!=0)
            {
                if (mass[y][x-2] == mass[YClickCell][XClickCell])
                {
                    mass[y][x-1] = mass[y][x+1];
                    mass[y][x+1] = 0;
                }
                else if (mass[y][x+2] == mass[YClickCell][XClickCell])
                {
                    mass[y][x+1] = mass[y][x-2];
                    mass[y][x-2] = 0;
                }
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "BLACK";
                white = false;
                long_white = false;
            }

            break;
        }

    }
    else
    {
        switch(mass[YClickCell][XClickCell])
        {
        case -1:
            if (y - 1 == YClickCell)
            {
                if ((x == XClickCell && mass[y][x] == 0) || ((x-1 == XClickCell || x+1 == XClickCell) && mass[y][x] > 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "WHITE";
                }
                else if (((x-1 == XClickCell && mass[y-1][x]>0) || (x+1 == XClickCell && mass[y-1][x ]>0)) && mass[y][x] == 0 && y-1 == 4)
                {
                    if (PushMove[0][x])
                    {
                        mass[y][x] = mass[YClickCell][XClickCell];
                        mass[YClickCell][XClickCell] = 0;
                        mass[YClickCell][x] = 0;
                        move = "WHITE";
                    }
                }
            }
            else if (y - 2 == YClickCell && y == 3)
            {
                if (x == XClickCell)
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "WHITE";
                    PushMove[1][x] = true;
                    Pushmove = true;
                }
            }
            break;
        case -2:
            if (y - 2 == YClickCell || y + 2 == YClickCell)
            {
                if ((x - 1 == XClickCell || x + 1 == XClickCell) && (mass[y][x] >= 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "WHITE";
                }
            }
            else if (x - 2 == XClickCell || x + 2 == XClickCell)
            {
                if ((y - 1 == YClickCell || y + 1 == YClickCell) && (mass[y][x] >= 0))
                {
                    mass[y][x] = mass[YClickCell][XClickCell];
                    mass[YClickCell][XClickCell] = 0;
                    move = "WHITE";
                }
            }

            break;
        case -3:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "WHITE";
            }

            break;
        case -4:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "WHITE";
                if (XClickCell == 7) black = false;
                if (!XClickCell) long_black = false;
            }

            break;
        case -5:
            if (FigureMove[y][x]!=0)
            {
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "WHITE";
            }

            break;
        case -6:
            if (FigureMove[y][x]!=0)
            {
                if (mass[y][x-2] == mass[YClickCell][XClickCell])
                {
                    mass[y][x-1] = mass[y][x+1];
                    mass[y][x+1] = 0;
                }
                else if (mass[y][x+2] == mass[YClickCell][XClickCell])
                {
                    mass[y][x+1] = mass[y][x-2];
                    mass[y][x-2] = 0;
                }
                mass[y][x] = mass[YClickCell][XClickCell];
                mass[YClickCell][XClickCell] = 0;
                move = "WHITE";
                black = false;
                long_black = false;
            }

            break;
        }
    }
}



/*
void MyGLW::mouseMoveEvent(QMouseEvent *event)
{
    extern QVector <double> Xpoint;
    extern QVector <double> Ypoint;
    extern QVector <QVector <int>> mass;
    if (status=="move")
    {
        for (int i=0;i<graph1.size();i++)
        {
            if (graph1[i].mark)
            {
                for (int j=0;j<graph2.size();j++)
                {
                    if (graph2[j].x1==graph1[i].x && graph2[j].y1==graph1[i].y)
                    {
                        graph2[j].x1=event->x();
                        graph2[j].y1=event->y();
                    }
                    if (graph2[j].x2==graph1[i].x && graph2[j].y2==graph1[i].y)
                    {
                        graph2[j].x2=event->x();
                        graph2[j].y2=event->y();
                    }
                }
                graph1[i].x=event->x();
                graph1[i].y=event->y();
                break;
            }
        }
    }
    update();
}
*/


