#include <LedHandler.h>
#include <MatrixHandler.h>
#include <RawHIDHandler.h>

void setup() {
  SetupRawHID();
  SetupLed();
  SetupMatrix();
}

void loop() {
  RunLed();
  RunMatrix();
}