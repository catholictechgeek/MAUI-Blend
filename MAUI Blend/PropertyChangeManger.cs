using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class PropertyChangeManager
    {
        private static PropertyChangeManager session;
        private string ctrlname;
        private Dictionary<string, object> changes;
        public event EventHandler<XamlChangeEventArgs> rerenderhook;

        private PropertyChangeManager(string name)
        {
            changes = new Dictionary<string, object>();
            ctrlname = name;
        }

        public object this[string name]
        {
            get => changes[name];
            set
            {
                //try the rerender first, but if an exception is thrown, revert to old value
                rerenderhook?.Invoke(this, new XamlChangeEventArgs(GetStyleAString()));
                changes[name] = value;
            }
        }

        public static PropertyChangeManager Session => session;

        public static void NewSession(string name = "")
        {
            session = new PropertyChangeManager(name);
        }

        /*
        internal string GetXAMLString()
        {
            if (changes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder($"<{ctrlname} ");

            foreach (var pair in changes)
            {
                sb.Append($"{pair.Key}={pair.Value}");
            }
            sb.AppendLine("/>");
            return sb.ToString();
        }
        */
        public string GetStyleAString()
        {
            if (changes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder($"<Style TargetType=\"{ctrlname}>");
            sb.AppendLine();
            foreach (var pair in changes)
            {
                sb.AppendLine($"<Setter Property={pair.Key} Value={pair.Value} />");
            }
            sb.AppendLine("/Style>");
            return sb.ToString();
        }
    }
}
