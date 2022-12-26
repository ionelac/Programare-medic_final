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
        var prog = (Programare)BindingContext;
        prog.Date = DateTime.UtcNow;
        await App.Database.SaveProgramareAsync(prog);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var prog = (Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(prog);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage((Programare)
       this.BindingContext)
        {
            BindingContext = new Serviciu()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var prog = (Programare)BindingContext;

        listView.ItemsSource = await App.Database.GetListServiciiAsync(prog.ID);
    }

}