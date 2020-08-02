#include <LedHandler.h>
#include <MatrixHandler.h>

void setup() {
  SetupLed();
  SetupMatrix();
}

void loop() {
  RunLed();
  RunMatrix();
}