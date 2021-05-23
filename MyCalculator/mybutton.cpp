#include "mybutton.h"

MyButton::MyButton(const QString &text, QWidget *parent)
    :QToolButton(parent)
{
    setText(text);
    setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Preferred);
}
