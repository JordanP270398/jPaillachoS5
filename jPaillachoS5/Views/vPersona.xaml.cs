using jPaillachoS5.Models;

namespace jPaillachoS5.Views;

public partial class vPersona : ContentPage
{

    private int? _personaEnEdicionId;
    public vPersona()
    {
        InitializeComponent();
    }

    private void btbAgregar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        if (_personaEnEdicionId is not int id)
        {
            App._personRepo.AddNewPerson(txtNombre.Text);
            lblMessage.Text = App._personRepo.Message;
            return;
        }

        string nombre = txtNombre.Text?.Trim() ?? string.Empty;
        if (nombre.Length is 0 or > 25)
        {
            lblMessage.Text = "Ingresa un nombre de 1 a 25 caracteres.";
            return;
        }

        try
        {
            bool actualizada = App._personRepo.UpdatePerson(id, nombre);
            SalirDeEdicion();
            ListaPersonas.ItemsSource = App._personRepo.GetAllPerson();
            lblMessage.Text = actualizada
                ? "Persona actualizada correctamente."
                : "La persona ya no existe.";
        }
        catch (SQLite.SQLiteException)
        {
            lblMessage.Text = "No se pudo actualizar la persona.";
        }
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        if (sender is not Button { CommandParameter: Persona persona })
            return;

        _personaEnEdicionId = persona.Id;
        txtNombre.Text = persona.Name;
        btbAgregar.Text = "Guardar cambios";
        btnCancelarEdicion.IsVisible = true;
        lblMessage.Text = "";
        txtNombre.Focus();
    }

    private void btnCancelarEdicion_Clicked(object sender, EventArgs e)
    {
        SalirDeEdicion();
        lblMessage.Text = "";
    }

    private void SalirDeEdicion()
    {
        _personaEnEdicionId = null;
        txtNombre.Text = "";
        btbAgregar.Text = "Agregar Persona";
        btnCancelarEdicion.IsVisible = false;
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
            if (eliminada && _personaEnEdicionId == id)
            {
                SalirDeEdicion();
            }
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