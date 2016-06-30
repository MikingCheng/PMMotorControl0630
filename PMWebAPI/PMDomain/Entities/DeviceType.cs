using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public enum DeviceType
    {
        AC_Motor,
        DC_Motor,
        MotorLimitTool,
        WiredWallSwitch,
        HandleHeldRemote,
        SmallTouchScreenController,
        LargeTouchScreenController,
        SmartPhone,
        WiredNetworkSplitter,
        CentralController,
        SensorController,
        AVGateway,
        InteriorBrightnessSensor
    }

    public enum CommMode
    {
        Bluetooth,
        RS485,
        IR
    }

    public enum Orientation
    {
        Null,       // for unidentified
        East,
        South,
        West,
        North,
        Southeast,
        Southwest,
        Northeast,
        Northwest
    }

    public enum MotorDiameter
    {
        D35,
        D45
    }

    public enum MotorTorque
    {
        T6,
        T9,
        T12
    }

    public enum MotorVoltage
    {
        V220_50,
        V110_60
    }
}
