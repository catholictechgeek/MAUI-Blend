namespace MAUI_Blend;

public partial class MAUIStyleEditorPhone : TabbedPage
{
	public MAUIStyleEditorPhone()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var model = (StyleViewModel)sender;
		model.AddSelectedForEditing();
    }
}