using BlaisePascal.SmartHouse.Domain.Devices.CCTVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVs.Abstractions.Mappers
{
    public static class CctvModeMapper
    {
        public static string ToDto(CctvMode mode)
        {
            return mode switch
            {
                CctvMode.Idle => "IDLE",
                CctvMode.Recording => "RECORDING",
                CctvMode.NightVision => "NIGHT_VISION",
                CctvMode.MotionDetection => "MOTION_DETECTION",
                CctvMode.Termic => "TERMIC",
                _ => "UNKNOWN"
            };
        }

        public static CctvMode ToDomain(string mode)
        {
            return mode switch
            {
                "IDLE" => CctvMode.Idle,
                "RECORDING" => CctvMode.Recording,
                "NIGHT_VISION" => CctvMode.NightVision,
                "MOTION_DETECTION" => CctvMode.MotionDetection,
                "TERMIC" => CctvMode.Termic,
                _ => CctvMode.Unknown
            };
        }
    }
}
