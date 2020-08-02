#include "RawHID.h"

// Buffer to hold RawHID data.
// If host tries to send more data than this,
// it will respond with an error.
// If the data is not read until the host sends the next data
// it will also respond with an error and the data will be lost.
uint8_t rawhidData[255];

void SetupRawHID()
{
  // Set the RawHID OUT report array.
  // Feature reports are also (parallel) possible, see the other example for this.
  RawHID.begin(rawhidData, sizeof(rawhidData));
}

void LoopRawHID() {
  // Send data to the host
  if (Serial.read() == 'a') {

    // Create buffer with numbers and send it
    uint8_t megabuff[100];
    for (uint8_t i = 0; i < sizeof(megabuff); i++) {
      megabuff[i] = i;
    }
    RawHID.write(megabuff, sizeof(megabuff));

    // Simple debounce
    delay(300);
  }


  // Check if there is new data from the RawHID device
  auto bytesAvailable = RawHID.available();
  if (bytesAvailable)
  {
    // Mirror data via Serial
    while (bytesAvailable--) {
      Serial.println(RawHID.read());
    }
  }
}