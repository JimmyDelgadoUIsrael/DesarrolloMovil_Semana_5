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

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            lblInfo.Text = "Por favor ingrese un nombre.";
            return;
        }

        if (txtNombre.BindingContext is Models.Persona personaExistente)
        {
            personaExistente.Nombre = txtNombre.Text;
            App.personaRepo.UpdatePersona(personaExistente);
            lblInfo.Text = App.personaRepo.statusMessage;

            txtNombre.BindingContext = null;
        }
        else
        {
            App.personaRepo.AddPersona(txtNombre.Text);
            lblInfo.Text = App.personaRepo.statusMessage;
        }

        txtNombre.Text = string.Empty;
        listPersonas.ItemsSource = App.personaRepo.GetPersonas();
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblInfo.Text = "";
        List<Models.Persona> personas = App.personaRepo.GetPersonas();
        listPersonas.ItemsSource = personas;

    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button?.CommandParameter as Models.Persona;

        if (persona is null)
            return;

        txtNombre.Text = persona.Nombre;
        txtNombre.BindingContext = persona;
        lblInfo.Text = $"Editando ID: {persona.Id}";
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button?.CommandParameter as Models.Persona;

        if (persona is null)
            return;

        App.personaRepo.DeletePersona(persona.Id);
        lblInfo.Text = App.personaRepo.statusMessage;
        listPersonas.ItemsSource = App.personaRepo.GetPersonas();
    }
}