#include <Arduino.h>

//BLevel = BrightnessLevel
int BLevel;
int CurrentBLevel;

int AnalogBLevel[] = {0, 100, 200 ,255};

#define LedPin 10

void SetupLed()
{
    pinMode(LedPin, OUTPUT);
}

void RunLed()
{
    if(CurrentBLevel != BLevel)
    {
        CurrentBLevel = BLevel;
        analogWrite(LedPin, AnalogBLevel[BLevel]);
    }
}