using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Converters;
using CommunityToolkit.Maui.Converters;
using System.ComponentModel;

namespace MAUI_Blend
{
    public class ConversionManager
    {
        private Dictionary<Type, object> conversionmap;
        private static ConversionManager instance;

        static ConversionManager()
        {
            instance = new ConversionManager();
        }
        private ConversionManager()
        {
            conversionmap = new Dictionary<Type, object>();
        }
        public static ConversionManager Instance { get { return instance; } }

        private object GetConverter(Type type)
        {
            //var converter = new ThicknessTypeConverter();
            return conversionmap[type];
            /*
            if(converter is TypeConverter)
            {

            }
            else if(converter is IValueConverter)
            {

            }
            else
            {
                return null;
            }
            */
        }

        private bool IsString(Type type)
        {
            return type == typeof(string);
        }

        private bool IsBoolean(Type type)
        {
            return type == typeof(bool);
        }

        private bool IsNumber(Type type)
        {
            return IsNormalNumberType(type) || IsUnsignedNumberType(type);
        }

        private bool IsNormalNumberType(Type type)
        {
            return type == typeof(int) || type == typeof(double) || type == typeof(long) || type == typeof(float) || type == typeof(decimal) || type == typeof(short) || type == typeof(Single) || type == typeof(Half) || type == typeof(sbyte);
        }

        private bool IsUnsignedNumberType(Type type)
        {
            return type == typeof(byte) || type == typeof(uint) || type == typeof(ulong);
        }
    }
}
    