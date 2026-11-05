using Microsoft.Extensions.DependencyInjection;

namespace jPaillachoS5
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository _personRepo {get; set;}
        public App(Repositories.PersonRepository personRepository)
        {
            InitializeComponent();
            _personRepo = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}