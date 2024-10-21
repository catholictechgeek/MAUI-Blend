using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class XamlChangeEventArgs
    {
        private string xamlnew;

        public XamlChangeEventArgs(string newxamlstring)
        {
            xamlnew = newxamlstring;
        }

        public string NewXaml => xamlnew;
    }
}
