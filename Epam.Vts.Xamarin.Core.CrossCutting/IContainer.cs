namespace Epam.Vts.Xamarin.Core.CrossCutting
{
    public interface IContainer
    {
        TService Resolve<TService>();
        void Register<TInterface, TClass>() where TClass : TInterface;
        void UnRegister<TInterface>();
        void Register<TInterface, TClass>(TClass instance) where TClass : TInterface;
    }
}
