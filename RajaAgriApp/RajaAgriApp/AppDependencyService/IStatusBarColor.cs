using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.AppDependencyService
{
    public interface IStatusBarColor
    {
        void SetColoredStatusBar(string hexColor);
        void HideStatusBar();
        void ShowStatusBar();
    }
}
