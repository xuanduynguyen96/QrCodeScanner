using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.Models
{
    public class BarcodeInfo
    {
        public ZXing.Result Code { get; set; }

        public string Text
        {
            get
            {
                if (Code != null)
                {
                    return Code.Text;
                }
                return null;
            }
        }

        public bool IsHyperLink
        {
            get
            {
                return Uri.IsWellFormedUriString(Text, UriKind.Absolute);
            }
        }

        public bool hasGotten
        {
            get
            {
                return !string.IsNullOrEmpty(Text);
            }
        }

        public BarcodeInfo()
        {
        }

        public BarcodeInfo(ZXing.Result code) : this()
        {
            Code = code;
        }
    }
}
