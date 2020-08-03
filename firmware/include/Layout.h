#include <Enumerations/KeyCodes.h>

#define RowCount 10
#define ColumnCount 10

//Rows Pins
int Rows[RowCount] = {1,2,3,4,5};
//Columns Pins
int Columns[ColumnCount] = {6,7,8,9,10};

void SetupLayout()
{
    for (auto i = 0; i < RowCount; i++)
    {
        auto rowPin = Rows[i];
        pinMode(rowPin, INPUT);
    }

    for (auto i = 0; i < ColumnCount; i++)
    {
        auto columnPin = Columns[i];
        pinMode(columnPin, INPUT_PULLUP);
    }
}