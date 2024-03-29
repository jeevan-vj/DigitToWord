﻿using System;
using System.Windows.Input;
using DigitToWord.DigitToWordService;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace DigitToWord.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageModel:FreshBasePageModel
    {
        public string Number { get; set; }
        public string Word { get; set; }
        public string ErrorMessage { get; set; }

        private const double MaxInputLimit = 1000000000000000000;


        private readonly NumberReader numberReader;

        public MainPageModel()
        {
            Word = "";
            numberReader = new NumberReader();
        }

        ICommand numberToWordCommand;
        public ICommand NumberToWordCommand
        {
            get
            {
                return numberToWordCommand ?? (numberToWordCommand = new Command(() => StartStopPlaying()));
            }
        }

        ICommand copyText;
        public ICommand CopyText => copyText ?? (copyText = new Command(async () => await CopyTextToClipBoard()));

        private void StartStopPlaying()
        {
            try
            {
                if (string.IsNullOrEmpty(Number))
                {
                    Word = string.Empty;
                    return;
                }

                var number = Convert.ToDouble(Number);

                if(number >= MaxInputLimit)
                {
                    Number = Number.Remove(Number.Length - 1);
                    number = Convert.ToDouble(Number);
                }

                Word = numberReader.Read(number);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
            }

        }

        private async Task CopyTextToClipBoard()
        {
            await Clipboard.SetTextAsync(Word);
        }
    }
}
