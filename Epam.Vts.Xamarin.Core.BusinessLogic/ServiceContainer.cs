using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Core.Data;
using Epam.Vts.Xamarin.Core.Data.DAC.Login;
using Epam.Vts.Xamarin.Core.Data.DAC.Person;
using Epam.Vts.Xamarin.Core.Data.DAC.Vacation;
using Ninject;

namespace Epam.Vts.Xamarin.Core.BusinessLogic
{
    public class ServiceContainer: IContainer
    {
        private readonly IKernel _kernel = new StandardKernel();

        public ServiceContainer()
        {
            Init();
        }

        public TService Resolve<TService>()
        {
            return _kernel.Get<TService>();
        }

        public void Register<TInterface, TClass>() where TClass : TInterface
        {
            _kernel.Bind<TInterface>().To<TClass>().InSingletonScope();
        }

        public void UnRegister<TInterface>()
        {
            _kernel.Unbind<TInterface>();
        }

        public void Register<TInterface, TClass>(TClass instance) where TClass : TInterface
        {
            _kernel.Bind<TInterface>().ToConstant(instance);
        }

        private void Init()
        {
            Register<ILoginProvider, LoginProvider>();
            Register<IVacationProvider, VacationProvider>();
            Register<ILoginAccessComponent, LoginAccessComponent>();
            Register<IPersonAccessComponent, PersonAccessComponent>();
            Register<IVacationAccessComponent, VacationAccessComponent>();
            Register<IConnectionProvider, FakeConnectionProvider>(); //Register<IConnectionProvider, ConnectionProvider>();
            Register<IRestService, RestService>();
        }
    }
}
