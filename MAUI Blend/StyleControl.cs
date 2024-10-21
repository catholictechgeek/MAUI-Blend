namespace MAUI_Blend;

public class StyleControl : ContentView
{
	public StyleControl()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				},
				ControlFromString()
			}
		};
	}

	public string name
	{
		get;
		set;
	}

	private View ControlFromString()
	{
		//look for shorthand name so we don't have to search first
		switch (name)
		{
			case "Button": return new Button();
			default: return new ContentView();
		}
	}
}