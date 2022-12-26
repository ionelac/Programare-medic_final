using Programare_medic_final.Models;

namespace Programare_medic_final;

public partial class ProgramarePage : ContentPage
{
	public ProgramarePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Programare)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveProgramareAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(slist);
        await Navigation.PopAsync();
    }
}