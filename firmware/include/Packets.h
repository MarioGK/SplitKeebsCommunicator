#include "Enumerations/PacketIDs.h"

class BasePacket
{
private:
    
public:
    BasePacket(/* args */);
    ~BasePacket();
    PacketIDs PacketID;
};

class KeyboardInfo : public BasePacket
{
private:
    /* data */
public:
    KeyboardInfo(/* args */) {}
    ~KeyboardInfo() {
        PacketID = PacketIDs::KeyboardInfo;
    }
};
