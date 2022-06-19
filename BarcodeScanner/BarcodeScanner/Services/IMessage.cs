using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.Services
{
    public interface IMessage
    {
        void LongMessage(string message);
        void ShortMessage(string message);
    }
}
