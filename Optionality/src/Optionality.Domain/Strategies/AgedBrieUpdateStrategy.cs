namespace Optionality.Domain.Strategies
{
    public class AgedBrieUpdateStrategy : IStockItemUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            //"Aged Brie" actually increases in Quality the older it gets
            item.SellIn--;
            if (item.Quality < 50) item.Quality++; //The Quality of an item is never more than 50
        }
    }
}