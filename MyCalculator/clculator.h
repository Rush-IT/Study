#ifndef CLCULATOR_H
#define CLCULATOR_H

#include <QWidget>
#include <QLineEdit>
#include <QLabel>
#include <mybutton.h>

class Calculator: public QWidget
{
    Q_OBJECT
public:
    Calculator();

private slots:
    void digitClicked();
    void unaryOperatorClicked();
    void doubleOperatorClicked();
    void equalClicked();
    void pointClicked();
    void changeSignClicked();
    void backspaceClicked();
    void clear();
    void clearALL();
    void OperatorClicked();

private:
    MyButton *createButton(const QString text, const char *member);

    void abortOperation();

    QString m_operations;

    QLineEdit *m_display_left;
    QLineEdit *m_display_right;
    QLabel *m_sign_label;
    QLabel *m_base_label;
    QLabel *m_power_label;

    MyButton *m_digitButtons[10];

    bool calculate(double operand, const QString& operation);
    double log_calculate(double base, double operand);
    double log_base = 2;
    bool f_log = false;
    double power_n = 2;
    bool f_power = false;
    bool f_point = false;
    bool f = false;

    QString m_division_sign = QChar(0x000000F7);
    QString m_times_sign    = QChar(0x000000D7);
    QString m_change        = QChar(0x000000B1);
    QString m_backspace     = QChar(0x0000232B);
    QString m_power_2 = ('x' + QChar(0x000000b2));
    QString m_power_a = ('x' + QChar(0x0000207F));
    QString m_log_n  = QChar(0x00002082);
    QString m_log_n2 = QChar(0x00002099);
};

#endif // CLCULATOR_H
