namespace jdelgadoS5A.Views;

public partial class vHome : ContentPage
{
    public vHome()
    {
        InitializeComponent();
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        App.personaRepo.AddPersona(txtNombre.Text);
        lblInfo.Text = App.personaRepo.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        List<Models.Persona> personas = App.personaRepo.GetPersonas();
        listPersonas.ItemsSource = personas;

    }
}