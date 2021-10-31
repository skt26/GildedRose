using Optionality.Domain.Strategies;

namespace Optionality.Domain.Factory
{
    public interface IUpdateItemStrategyFactory
    {
        IStockItemUpdateStrategy Create(Item item);
    }
}