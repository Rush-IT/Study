#ifndef MYPAINTER_H
#define MYPAINTER_H

#include <QBrush>
#include <QFont>
#include <QPen>
#include <QWidget>
#include <QVector>
#include <QPixmap>
#include "edge.h"

class MyPainter
{
public:
    MyPainter();

public:
    void draw(QPainter *painter, QPaintEvent *event);

private:
    QBrush frontBlack;
    QBrush frontWhile;
    QBrush frontGreen;
    QBrush back;
    QFont glFont;
    QPen textPen;
    QPen linePen;
    double pointX = 10;
    double pointY = 10;
    double sizeX = 80;
    double sizeY = 80;
    QString Photo(int x, int y);

    bool flag = false;

};

#endif // MYPAINTER_H
