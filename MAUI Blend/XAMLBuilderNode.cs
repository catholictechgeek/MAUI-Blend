using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MAUI_Blend
{
    internal enum BuilderNodeType { Simple, Object, Binding }
    internal class XAMLBuilderNode
    {
        private BuilderNodeType nodeType;
        private object? val;
        private string nomine;
        private BindingConfiguration? config;


        public XAMLBuilderNode(string name, string value) {
            nomine = name;
            val = value;
        }

        public XAMLBuilderNode(string name, object value) {
            nomine = name;
            val = value;
        }

        public XAMLBuilderNode(string name, BindingConfiguration configuration)
        {
            nomine = name;
        }


        internal string GetXAMLString()
        {
            if(nodeType == BuilderNodeType.Simple)
            {
                return $"{nomine}={val}";
            }
            else if (nodeType == BuilderNodeType.Binding)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

    }
}
