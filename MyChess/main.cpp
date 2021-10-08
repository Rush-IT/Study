#include "mainwin.h"

#include <QApplication>
QVector <QVector<int>> matrix;
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWin w;
    w.show();
    return a.exec();
}
