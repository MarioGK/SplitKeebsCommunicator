/*
  Copyright (c) 2014-2015 NicoHood
  See the readme for credit to other people.
  Advanced RawHID example
  Shows how to send bytes via RawHID.
  Press a button to send some example values.
  Every received data is mirrored to the host via Serial.
  See HID Project documentation for more information.
  https://github.com/NicoHood/HID/wiki/RawHID-API
*/

// Include guard
#pragma once

#include <Arduino.h>
#include "HID.h"
#include "HID-Settings.h"

// RawHID might never work with multireports, because of OS problems
// therefore we have to make it a single report with no ID. No other HID device will be supported then.
#undef RAWHID_USAGE_PAGE
#define RAWHID_USAGE_PAGE	0xFFC0 // recommended: 0xFF00 to 0xFFFF

#undef RAWHID_USAGE
#define RAWHID_USAGE		0x0C00 // recommended: 0x0100 to 0xFFFF

// Keep one byte offset for the reportID if used
#if (HID_REPORTID_RAWHID)
#define RAWHID_SIZE (USB_EP_SIZE-1)
#error RAWHID does not work properly with a report ID and multiple reports.
#error Please remove this manually if you know what you are doing.
#else
#define RAWHID_SIZE (USB_EP_SIZE)
#endif

#undef RAWHID_TX_SIZE
#define RAWHID_TX_SIZE RAWHID_SIZE

#undef RAWHID_RX_SIZE
#define RAWHID_RX_SIZE RAWHID_SIZE

typedef union{
	// a RAWHID_TX_SIZE byte buffer for tx
	uint8_t whole8[0];
	uint16_t whole16[0];
	uint32_t whole32[0];
	uint8_t buff[RAWHID_TX_SIZE];
} HID_RawKeyboardTXReport_Data_t;

typedef union{
	// a RAWHID_TX_SIZE byte buffer for rx
	uint8_t whole8[0];
	uint16_t whole16[0];
	uint32_t whole32[0];
	uint8_t buff[RAWHID_RX_SIZE];
} HID_RawKeyboardRXReport_Data_t;

class RawHID_ : public PluggableUSBModule, public Stream
{
public:
	RawHID_(void);

    void setFeatureReport(void* report, int length){
        if(length > 0){
            featureReport = (uint8_t*)report;
            featureLength = length;

            // Disable feature report by default
            disableFeatureReport();
        }
    }

    int availableFeatureReport(void){
        if(featureLength < 0){
            return featureLength & ~0x8000;
        }
        return 0;
    }

    void enableFeatureReport(void){
        featureLength &= ~0x8000;
    }

    void disableFeatureReport(void){
        featureLength |= 0x8000;
    }

	void begin(void* report, int length){
        if(length > 0){
            data = (uint8_t*)report;
            dataLength = length;
            dataAvailable = 0;
        }
	}

	void end(void){
		disable();
		dataLength = 0;
	}

	void enable(void){
		dataAvailable = 0;
	}

	void disable(void){
		dataAvailable = -1;
	}

	virtual int available(void){
		if(dataAvailable < 0){
			return 0;
		}
		return dataAvailable;
	}

	virtual int read(){
		// Check if we have data available
		if(dataAvailable > 0)
		{
			// Get next data byte (from the start to the end)
			return data[dataLength - dataAvailable--];
		}
		return -1;
	}

	virtual int peek(){
		// Check if we have data available
		if(dataAvailable > 0){
			return data[dataLength - dataAvailable];
		}
		return -1;
	}

	virtual void flush(void){
		// Writing will always flush by the USB driver
	}

	// Wrapper for a single byte
	using Print::write;
	virtual size_t write(uint8_t b){
		return write(&b, 1);
	}

	virtual size_t write(uint8_t *buffer, size_t size){
		return USB_Send(pluggedEndpoint | TRANSFER_RELEASE, buffer, size);
	}

protected:
    // Implementation of the PUSBListNode
    int getInterface(uint8_t* interfaceCount);
    int getDescriptor(USBSetup& setup);
    bool setup(USBSetup& setup);

    EPTYPE_DESCRIPTOR_SIZE epType[1];
    uint8_t protocol;
    uint8_t idle;

	// Buffer pointers to hold the received data
	int dataLength;
	int dataAvailable;
	uint8_t* data;

	uint8_t* featureReport;
	int featureLength;
};
extern RawHID_ RawHID;