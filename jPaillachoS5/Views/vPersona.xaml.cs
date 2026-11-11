using jPaillachoS5.Models;

namespace jPaillachoS5.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private void btbAgregar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        App._personRepo.AddNewPerson(txtNombre.Text);
        lblMessage.Text = App._personRepo.Message;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        List<Persona> people = App._personRepo.GetAllPerson();
        ListaPersonas.ItemsSource = people;

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button { CommandParameter: int id })
            return;

        bool confirmar = await DisplayAlertAsync(
            "Eliminar persona",
            "¿Deseas eliminar a la persona seleccionada?",
            "Eliminar",
            "Cancelar");

        if (!confirmar)
            return;

        try
        {
            bool eliminada = App._personRepo.DeletePerson(id);
            ListaPersonas.ItemsSource = App._personRepo.GetAllPerson();

            lblMessage.Text = eliminada
                ? "Persona eliminada correctamente."
                : "La persona ya no existe.";
        }
        catch (SQLite.SQLiteException)
        {
            lblMessage.Text = "No se pudo eliminar la persona.";
        }
    }

}