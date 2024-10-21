using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class PropertyValueChangedEventArgs:EventArgs
    {
        public string PropertyName { get; private set; }
        public object PropertyValue { get; private set; }
    }
}
