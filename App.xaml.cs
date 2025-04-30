namespace jdelgadoS5A
{
    public partial class App : Application
    {
        public static Repositories.PersonaRepositorio personaRepo { get; set; } //Para usar en todas las clases hijas de la app
        public App(Repositories.PersonaRepositorio personaRepositorio)
        {
            InitializeComponent();
            personaRepo = personaRepositorio; //Para usar en todas las clases hijas de la app
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vHome());

        }
    }
}