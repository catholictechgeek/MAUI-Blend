using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class DataSource
    {
        public string source {  get; set; }

        public object[] items { get; private set; }
    }
}
