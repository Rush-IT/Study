#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "myglw.h"
#include <QGridLayout>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    MyGLW *openGLW = new MyGLW(this);
    QGridLayout *mainlayout = new QGridLayout;

    mainlayout->addWidget(openGLW, 0, 0, 10, 10);
}

MainWindow::~MainWindow()
{
    delete ui;
}

