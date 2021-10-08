#include "mypainter.h"
#include <QPainter>
#include <QPaintEvent>
#include <QWidget>
#include <QVector>

QVector <double> Xpointer { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
QVector <double> Ypointer { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
QVector <QVector <int>> BoardColor
{
    { 0, 1, 0, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 0, 1, 0 },
    { 0, 1, 0, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 0, 1, 0 },
    { 0, 1, 0, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 0, 1, 0 },
    { 0, 1, 0, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 0, 1, 0 }
};
QVector <QVector <int>> NewBoardColor
{
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 }
};
QVector <QVector <int>> FigureMove
{
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 },
    {0, 0, 0, 0, 0, 0, 0, 0 }
};

MyPainter::MyPainter()
{
    frontBlack = QBrush(QColor(181, 136, 99));
    frontWhile = QBrush(QColor(240, 217, 181));
    frontGreen = QBrush(QColor(129, 150, 105));
    back  = QBrush(QColor(156, 157, 158));
    textPen = QPen(QColor(255, 255, 250));
    linePen = QPen(QColor(155, 155, 250));
    glFont.setPixelSize(1);


    int indent = sizeX - 10;
    double x = pointX;
    double y = pointY;

    for(int i = 0; i < 9; ++i)
    {
        Xpointer[i] = x;
        Ypointer[i] = y;
        x += pointX + indent;
        y += pointY + indent;
    }
}

QVector<QVector<int>> mass
{
    {-4, -2, -3, -5, -6, -3, -2, -4},
    {-1, -1, -1, -1, -1, -1, -1, -1},
    { 0,  0,  0,  0,  0,  0,  0,  0},
    { 0,  0,  0,  0,  0,  0,  0,  0},
    { 0,  0,  0,  0,  0,  0,  0,  0},
    { 0,  0,  0,  0,  0,  0,  0,  0},
    { 1,  1,  1,  1,  1,  1,  1,  1},
    { 4,  2,  3,  5,  6,  3,  2,  4}
};

QVector <QVector <bool>> PushMove
{
  {false, false, false, false, false, false, false, false},
  {false, false, false, false, false, false, false, false}
};

void MyPainter::draw(QPainter *painter, QPaintEvent *event)
{
    painter->fillRect(event->rect(), back);
    painter->setFont(glFont);
    //painter->set

    for(int i = 0; i < 8; ++i)
    {
        for(int j = 0; j < 8; ++j)
        {
            switch(BoardColor[i][j])
            {
            case 0:
                painter->setBrush(frontWhile);
                break;
            case 1:
                painter->setBrush(frontBlack);
                break;
            }
            switch(NewBoardColor[i][j])
            {
            case 0:
                painter->drawRect(Xpointer[j], Ypointer[i], sizeX, sizeY);
                break;
            case 1:
                painter->setBrush(frontGreen);
                painter->drawRect(Xpointer[j], Ypointer[i], sizeX, sizeY);
                break;
            case 2:
                painter->drawRect(Xpointer[j], Ypointer[i], sizeX, sizeY);
                painter->setBrush(frontGreen);
                painter->drawEllipse(Xpointer[j] + 29.5, Ypointer[i] + 29.5, sizeX/4, sizeY/4);
                break;
            }
            QPixmap map(Photo(i, j));
            painter->drawPixmap(QPoint(Xpointer[j]+7, Ypointer[i]+7), map);
        }
    }


}

QString MyPainter::Photo(int x, int y)
{
    QString photo;
    for(int i = 0; i < 8; ++i)
    switch(mass[x][y])
    {
    case -1: photo = "D:/MyChess/pawn.png";break;
    case -2: photo = "D:/MyChess/horse.png"; break;
    case -3: photo = "D:/MyChess/bishop.png"; break;
    case -4: photo = "D:/MyChess/rook.png"; break;
    case -5: photo = "D:/MyChess/queen.png"; break;
    case -6: photo = "D:/MyChess/king.png"; break;
    case 0: photo = "0"; break;
    case 1: photo = "D:/MyChess/pawn1.png";break;
    case 2: photo = "D:/MyChess/horse1.png"; break;
    case 3: photo = "D:/MyChess/bishop1.png"; break;
    case 4: photo = "D:/MyChess/rook1.png"; break;
    case 5: photo = "D:/MyChess/queen1.png"; break;
    case 6: photo = "D:/MyChess/king1.png"; break;
    }

    return photo;
}


