using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MAUI_Blend
{
    public class StyleViewModel
    {
        public StyleViewModel() {
            UnsetProperties = new ObservableCollection<Property>();
            SetProperties = new ObservableCollection<Property>();
        }

        public ObservableCollection<Property> UnsetProperties { get; }

        public ObservableCollection<Property> SetProperties { get; }

        public int SetForAdd { get; set; }

        public void AddSelectedForEditing()
        {
            if (SetForAdd < 0)
            {
                return;
            }

            var index = SetForAdd;

            SetProperties.Add(UnsetProperties[index]);
            UnsetProperties.RemoveAt(index);
        }
    }
}
