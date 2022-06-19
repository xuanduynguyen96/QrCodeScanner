using BarcodeScanner.Models;
using BarcodeScanner.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BarcodeScanner.ViewModels
{
    public class ReadingBarcodeViewModel : BaseViewModel
    {
        private BarcodeInfo _barcode;

        public ICommand StartReadingBarcodeCommand { get; }

        public ICommand CopyToClipBoardCommand { get; }

        public ICommand GotoCommand { get; }

        public BarcodeInfo Barcode
        {
            get { return _barcode; }
            set
            {
                SetProperty(ref _barcode, value);
            }
        }

        public ReadingBarcodeViewModel()
        {
            Title = "Reading Barcode";

            _barcode = new BarcodeInfo();

            StartReadingBarcodeCommand = new Command(StartScanBarcode);
            CopyToClipBoardCommand = new Command<string>(CopyToClipBoard);
            GotoCommand = new Command<string>(async link => await Browser.OpenAsync(link));
        }

        private async void StartScanBarcode()
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    Barcode = new BarcodeInfo(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void CopyToClipBoard(string copiedText)
        {
            var result = Clipboard.SetTextAsync(copiedText);
            if (result != null)
            {
                var toastMsg = DependencyService.Get<IMessage>();
                toastMsg.ShortMessage("Succesfully copy to clipboard");
            }
        }
    }
}
