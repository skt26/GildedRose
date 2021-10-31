using Optionality.Domain.Strategies;
using System;

namespace Optionality.Domain.Factory
{
    public class UpdateItemStrategyFactory : IUpdateItemStrategyFactory
    {
        public IStockItemUpdateStrategy Create(Item item)
        {
            if (item == null){
                throw new ArgumentNullException(nameof(item));
            }

            switch (item.Category)
            {
                case "Food":
                    if(item.Name.Equals("Aged Brie"))
                    return new AgedBrieUpdateStrategy();
                    else return new StandardItemsUpdateStrategy();
                case "Backstage passes":
                    return new BackStagePassesUpdateStrategy();
                case "Sulfuras":
                    return new LegendaryItemsUpdateStratgey();
                case "Conjured":
                    return new ConjuredUpdateStrategy();
                default:
                    return new StandardItemsUpdateStrategy();
            }
        }
    }
}