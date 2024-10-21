using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class Property
    {
        private object val;
        private readonly string name;

        public Property(string name, object value) {
            this.name = name;
            PropertyType = value.GetType().FullName;
            PropertyValue = value;
        }

        public string PropertyName => name;
        public string PropertyType { get; private set; }
        public object PropertyValue
        {
            get => val;
            set
            {
                //value must match destination  
                /*
                if (!PropertyCheckSuccess(value))
                {
                    throw new InvalidOperationException("The given value must match the type of the property.");
                }
                */
                PropertyChangeManager.Session[PropertyName] = value;
                val = value;
            }
        }

        private bool PropertyCheckSuccess(object potential)
        {
            return potential.GetType().FullName == PropertyType;
        }
    }
}
