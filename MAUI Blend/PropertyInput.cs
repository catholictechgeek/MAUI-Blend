using Maui.ColorPicker;
using Microsoft.Maui.Controls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MAUI_Blend;

public class PropertyInput : ContentView
{
    private View ctrl;
	private Binding binding;

	public PropertyInput()
	{
        ctrl = ValueInputFromString();

        Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				},
				ctrl
			}
		};
	}

	public object Value { get; set; }

    private View ValueInputFromString()
    {
		var bingding = new Binding("PropertyValue");
		if(Value.GetType().IsEnum)
		{
			var enumvalues = Value.GetType().GetEnumNames();
			var control = new Picker() { ItemsSource = enumvalues };
			control.SetBinding(Picker.SelectedItemProperty, bingding);
			return control;
		}
		else if(Value is Color)
		{
            var control = new ColorPicker() { ColorFlowDirection = ColorFlowDirection.Horizontal };
			control.SetBinding(ColorPicker.PickedColorProperty, bingding);

            return control;
        }
		else if (Value is bool)
		{
			var control = new CheckBox();
			control.SetBinding(CheckBox.IsCheckedProperty, bingding);
			return control;
		}
		else if (double.TryParse(Value.ToString(), out _))
		{
            var control = new Entry() { Keyboard = Keyboard.Numeric };
			control.SetBinding(Entry.TextProperty, bingding);
            return control;
        }
		else
		{
            var control = new Entry();
            control.SetBinding(Entry.TextProperty, bingding);
            return control;
        }
    }

	public void Clear()
	{
		ClearBinding();
		Value = null;
	}

	private void ClearBinding()
	{
        if (ctrl is ColorPicker)
		{
			(ctrl as ColorPicker).RemoveBinding(ColorPicker.PickedColorProperty);
        }
		else if (ctrl is Picker)
        {
            (ctrl as Picker).RemoveBinding(Picker.SelectedItemProperty);
        }
        else
        {
			(ctrl as Entry).RemoveBinding(Entry.TextProperty);
        }
    }
}