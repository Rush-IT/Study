#ifndef MYGLW_H
#define MYGLW_H

#include <QOpenGLWidget>
#include "mypainter.h"
#include <QMouseEvent>
#include "edge.h"

class MyGLW : public QOpenGLWidget
{
public:
    MyGLW(QWidget *parent);
public slots:
    void redraw();
protected:
    void paintEvent(QPaintEvent *event) override;
    void mousePressEvent(QMouseEvent *event) override;
    //void mouseReleaseEvent(QMouseEvent*event);
    //void mouseMoveEvent(QMouseEvent*event);

private:
    MyPainter *mypainter;
    void move_piece(int x, int y);
    bool ColorMove(int x, int y);
    int XClickCell = -1;
    int YClickCell = -1;
    bool Pushmove = false;
    bool white = true;
    bool long_white = true;
    bool black = true;
    bool long_black = true;

    QString move = "WHITE";
};

#endif // MYGLW_H
