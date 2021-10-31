namespace Optionality.Domain.Strategies
{
    public class LegendaryItemsUpdateStratgey : IStockItemUpdateStrategy
    {
        ///"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        ///An item can never have its Quality increase above 50, however 
        ///"Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
        public void UpdateItem(Item item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }
    }
}