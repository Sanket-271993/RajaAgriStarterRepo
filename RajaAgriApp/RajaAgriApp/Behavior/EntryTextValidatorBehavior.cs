using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace RajaAgriApp.Behavior
{
    public class EntryTextValidatorBehavior : Behavior<Entry>
    {
        const string numberRegex = @"^[a-zA-Z]+$";

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EntryTextValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));

            if (e.NewTextValue.Length > 0)
            {
                ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
          
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }

    }
}
