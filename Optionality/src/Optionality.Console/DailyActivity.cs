using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Optionality.Domain;

namespace Optionality.ConsoleApp
{
    public class DailyActivity
    {
        /// <summary>
        /// Load Inventory
        /// </summary>
        public IList<Item> StartOfDay()
        {
            if(!System.IO.File.Exists("Inventory.txt"))
            {
                System.Console.WriteLine("No data found for previous day, please start fresh.");
                return null;
            }
            string[] lines = System.IO.File.ReadAllLines("Inventory.txt");
            var startOfDayData = new StringBuilder();
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                startOfDayData.Append("\t").Append(line);
            }
            return JsonConvert.DeserializeObject<IList<Item>>(startOfDayData.ToString());
        }
        /// <summary>
        /// Save Inventory
        /// </summary>
        public void EndOFDay(IList<Item> items)
        {

           var deleteItems= items.Where(item => item.Quality <= 0).ToList();
            if(deleteItems.Any())
            {
                deleteItems.ForEach(x => items.Remove(x));
            }

           string dataToSave=  JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText("Inventory.txt", dataToSave);

        }
    }
}
