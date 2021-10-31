namespace Optionality.Domain.Strategies
{
    public class BackStagePassesUpdateStrategy : IStockItemUpdateStrategy
    {
        ///"Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches;
        ///Quality increases by 2 when there are 10 days or less 
        ///and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        public void UpdateItem(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50) item.Quality++;

            if (item.SellIn < 10)  // Quality increases by 2 when there are 10 days or less
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 5) //and by 3 when there are 5 days or less
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 0) //Quality drops to 0 after the concert
            {
                item.Quality = 0;
            }
        }
    }
}