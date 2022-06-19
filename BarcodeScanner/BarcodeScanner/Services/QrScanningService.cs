using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace BarcodeScanner.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<ZXing.Result> ScanAsync()
        {
            var scanningOption = new MobileBarcodeScanningOptions
            {
                TryHarder = true
            };

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scanning the code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(scanningOption);
            return scanResult;
        }
    }
}
