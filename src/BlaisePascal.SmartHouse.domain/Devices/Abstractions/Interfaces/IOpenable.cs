using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions.Interfaces
{
    public interface IOpenable
    {
        bool IsOpen { get; }
        void Open();
        void Close();
    }
}
