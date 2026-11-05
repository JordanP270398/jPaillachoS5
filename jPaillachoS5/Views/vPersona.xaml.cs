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
        List<Persona> people =App._personRepo.GetAllPerson();
        ListaPersonas.ItemsSource = people;

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}