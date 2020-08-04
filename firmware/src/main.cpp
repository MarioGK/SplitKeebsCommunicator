#include <LedHandler.h>
#include <MatrixHandler.h>
#include <RawHIDHandler.h>
#include <PacketHandler.h>

void setup() {
  SetupRawHID();
  SetupPacketHandler();
  SetupMatrix();
  SetupLed();
}

void loop() {
  RunLed();
  RunRawHID();
  RunPacketHandler();
  RunMatrix();
}