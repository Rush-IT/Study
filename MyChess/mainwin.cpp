#include "mainwin.h"
#include <QGridLayout>
#include "myglw.h"

MainWin::MainWin()
{
    QGridLayout *mainLayout = new QGridLayout;
    MyGLW *openGLW = new MyGLW(this);
    mainLayout->addWidget(openGLW, 0, 0);
    setLayout(mainLayout);
    setStyleSheet("background-color: rgb(56, 57, 58);");

    setGeometry(550, 200, 700, 750);
}
