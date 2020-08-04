#include <Arduino.h>

unsigned long debounceTime[255];

bool Debounce(int debounceId, unsigned long time)
{
    auto lastTime = debounceTime[debounceId];
    auto currentTime = millis();
    if(lastTime + time > currentTime)
    {
        debounceTime[debounceId] = currentTime;
        return true;
    }
    
    return false;
}