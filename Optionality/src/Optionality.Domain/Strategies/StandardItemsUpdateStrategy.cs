namespace Optionality.Domain.Strategies
{
    public class StandardItemsUpdateStrategy : IStockItemUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0) item.Quality--;
            if (item.SellIn < 0)  //Once the sell by date has passed, Quality degrades twice as fast
            {
                if (item.Quality > 0) item.Quality--; //The Quality of an item is never negative
            }
        }
    }
}