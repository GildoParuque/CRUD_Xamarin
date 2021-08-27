using CRUD_Xamarin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_Xamarin.ViewModels
{
    public class ButtonModel : ExtendedBindableObject
    {
        string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        bool _isEnable;
        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }

        ICommand _command;
        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        public ButtonModel(string title, ICommand command,bool isVisible = true, bool isEnabled = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnable = isEnabled;
        }

        public ButtonModel(string text, Action action, bool isVisible = true, bool isEnable = true)
        {
            Text = text;
            Command = new Command(action);
            IsEnable = isEnable;
            IsVisible = isVisible;
        }
    }
}
