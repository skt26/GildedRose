using Optionality.Domain.Factory;
using Optionality.Domain.Strategies;
using Ninject;

namespace Optionality.ConsoleApp.Ninject
{
    public class Ioc : IIocGateway
    {
        private IKernel ninjectKernel;

        public Ioc()
        {
            ninjectKernel = new StandardKernel();
            Register();
        }
        
        public T Resolve<T>()
        {
            return ninjectKernel.Get<T>();
        }
        
        private void Register()
        {
            ninjectKernel.Bind<IUpdateItemStrategyFactory>().To<UpdateItemStrategyFactory>().InSingletonScope();
            ninjectKernel.Bind<IStockItemUpdateStrategy>().To<AgedBrieUpdateStrategy>().InTransientScope();
            ninjectKernel.Bind<IStockItemUpdateStrategy>().To<BackStagePassesUpdateStrategy>().InTransientScope();
            ninjectKernel.Bind<IStockItemUpdateStrategy>().To<ConjuredUpdateStrategy>().InTransientScope();
            ninjectKernel.Bind<IStockItemUpdateStrategy>().To<LegendaryItemsUpdateStratgey>().InTransientScope();
            ninjectKernel.Bind<IStockItemUpdateStrategy>().To<StandardItemsUpdateStrategy>().InTransientScope();
        }
    }
}
