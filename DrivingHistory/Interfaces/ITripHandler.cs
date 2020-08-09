using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistory.Interfaces
{
    interface ITripHandler
    {
        Dictionary<string, DriverInfo> ParseFileData(List<string> fileLines);
        List<string> GenerateTripOutput(Dictionary<string, DriverInfo> driverInfo);
        void DisplayOutput(List<string> output);
    }
}
