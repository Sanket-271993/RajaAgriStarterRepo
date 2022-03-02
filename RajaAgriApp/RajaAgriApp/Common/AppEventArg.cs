using RajaAgriApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajaAgriApp.Common
{
    public class DropDownEventArg:EventArgs
    {
        public  DropDownType DropDownType { get; set; }
        public DropDownModel SelectedData { get; set; }
    }

    public enum DropDownType
    {
        ProductName,
        ProductType,
        ElectricSghop,
        SelectedProduct,
        TypeProblem
    }
}
