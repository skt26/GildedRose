namespace Optionality.Domain.Strategies
{
    public class ConjuredUpdateStrategy : IStockItemUpdateStrategy
    {
        /// <summary>
        /// "Conjured" items degrade in Quality twice as fast as normal items
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Item item)
        {
            
            item.Quality -= 2;
            if (item.SellIn > 0)
                item.SellIn--;
            if (item.SellIn <= 0)
                item.Quality -= 2;
        }
    }
}