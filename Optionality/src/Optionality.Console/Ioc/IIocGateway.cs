namespace Optionality.ConsoleApp.Ninject
{
    public interface IIocGateway
    {
        T Resolve<T>();
    }
}