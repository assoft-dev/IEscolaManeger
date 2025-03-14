﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Desktop
{
    public class GlobalThemeMember
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;

            OnPropertyChanged(propertyName);
            return true;
        }

        private ThemeEscolas themeEscolas;
        public ThemeEscolas ThemeEscolas
        {
            get => themeEscolas;
            set => SetField(ref themeEscolas, value);
        }
    }
}
