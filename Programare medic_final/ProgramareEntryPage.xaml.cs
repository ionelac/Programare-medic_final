using Programare_medic_final.Models;

namespace Programare_medic_final;

public partial class ProgramareEntryPage : ContentPage
{
	public ProgramareEntryPage()
	{
		InitializeComponent();

	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProgramariAsync();
    }
    async void OnProgramareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramarePage
        {
            BindingContext = new Programare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProgramarePage
            {
                BindingContext = e.SelectedItem as Programare
            });
        }
    }
}