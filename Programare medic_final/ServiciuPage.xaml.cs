using Programare_medic_final.Models;

namespace Programare_medic_final;

public partial class ServiciuPage : ContentPage
{
    Programare prg;
    public ServiciuPage(Programare prog)
    {
        InitializeComponent();
        prg = prog;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(serviciu);
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(serviciu);
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Serviciu s;
        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as Serviciu;
            var ls = new ListServiciu()
            {
                ProgramareID = prg.ID,
                ServiciuID = s.ID
            };
            await App.Database.SaveListServiciuAsync(ls);
            s.ListServicii = new List<ListServiciu> { ls };
            await Navigation.PopAsync();
        }
    }
}