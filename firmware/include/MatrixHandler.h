#include <MacroHandler.h>
#include <Layout.h>
#include <Keyboard.h>
#include <Debouncer.h>

void SetupMatrix()
{
    Keyboard.begin();
    SetupLayout();
    pinMode(LED_BUILTIN, OUTPUT);
}

void RunMatrix()
{
    KeyCodes keyPressed = KeyCodes::Null;

    for (auto rowIndex = 0; rowIndex < RowCount; rowIndex++)
    {
        for (auto columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
        {
            Keyboard.print(KeyCodes::A);
        }
    }

    if(keyPressed == KeyCodes::Null)
    {
        return;
    }

    if(RunMacro(keyPressed))
    {
        return;
    }


    return;
}