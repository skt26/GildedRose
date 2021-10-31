using Optionality.ConsoleApp;
using Optionality.ConsoleApp.Ninject;
using Optionality.Domain;
using Optionality.Domain.Factory;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Optionality.Console
{
    public class Program
    {
        IUpdateItemStrategyFactory UpdateStrategyFactory { get; set; }
        public IList<Item> Items;

        public Program(IUpdateItemStrategyFactory strategyFactory)
        {
            UpdateStrategyFactory = strategyFactory;
        }

        static void Main(string[] args)
        {

            var ioc = new Ioc();
            var updateStrategy = ioc.Resolve<IUpdateItemStrategyFactory>();
            bool continueOperation = true;
            var app = new Program(updateStrategy);
            while (continueOperation)
            {
                System.Console.WriteLine($"Enter 1 for first time Use. {Environment.NewLine}Enter 2 To resume from yesterdays Data. {Environment.NewLine}Enter 3 to list Current Inventory.{Environment.NewLine}Enter 4 for Specific Item. {Environment.NewLine}Enter 0 to Exit. ");
                var inputKey = System.Console.ReadKey();
                System.Console.WriteLine();
                switch (inputKey.Key)
                {
                    case ConsoleKey.D1:
                        app.Items = GetDefaultInventory();
                        app.UpdateQuality();
                        app.EndOFDay();
                        app.PrintData();
                        break;
                    case ConsoleKey.D2:
                        app.StartOFDay();
                        if (app.Items != null)
                        {
                            app.UpdateQuality();
                            app.EndOFDay();
                            app.PrintData();
                        }
                        break;
                    case ConsoleKey.D3:
                        app.PrintData();
                        break;
                    case ConsoleKey.D4:
                       var itemName= System.Console.ReadLine();
                        app.PrintData(itemName);
                        break;
                    case ConsoleKey.D0:
                        continueOperation = false;
                        break;
                }
                
            }
            
            

        }

        public static List<Item> GetDefaultInventory()
        {
            return new List<Item>
                {
                new Item {Name = "Sword", Category="Weapon", SellIn = 30, Quality = 50},
                new Item {Name = "Axe", Category="Weapon", SellIn = 40, Quality = 50},
                new Item {Name = "Halberd", Category="Weapon", SellIn = 60, Quality = 50},
                new Item {Name = "Halberd", Category="Weapon", SellIn = 60, Quality = 40},
                new Item {Name = "Aged Brie", Category="Food", SellIn = 50, Quality = 10},
                new Item {Name = "Aged Milk", Category="Food", SellIn = 20, Quality = 20},
                new Item {Name = "Mutton", Category="Food", SellIn = 10, Quality = 10},
                new Item {Name = "Hand of Ragnaros", Category="Sulfuras", SellIn = 80, Quality = 80},
                new Item {Name = "I am Murloc", Category="Backstage Passes", SellIn = 20, Quality = 10},
                new Item {Name = "Raging Ogre", Category="Backstage Passes", SellIn = 10, Quality = 10},
                new Item {Name = "Giant Slayer", Category="Conjured", SellIn = 15, Quality = 50},
                new Item {Name = "Storm Hammer", Category="Conjured", SellIn = 20, Quality = 50},
                new Item {Name = "Belt of Giant Strength", Category="Conjured", SellIn = 20, Quality = 40},
                new Item {Name = "Cheese", Category="Food", SellIn = 5, Quality = 5},
                new Item {Name = "Potion of Healing", Category="Potion", SellIn = 10, Quality = 10},
                new Item {Name = "Bag of Holding", Category="Misc", SellIn = 10, Quality = 50},
                new Item {Name = "TAFKAL80ETC Concert", Category="Backstage Passes", SellIn = 15, Quality = 20},
                new Item {Name = "Elixir of the Mongoose", Category="Potion", SellIn = 5, Quality = 7},
                new Item {Name = "+5 Dexterity Vest", Category="Armor", SellIn = 10, Quality = 20},
                new Item {Name = "Full Plate Mail", Category="Armor", SellIn = 50, Quality = 50},
                new Item {Name = "Wooden Shield", Category="Armor", SellIn = 10, Quality = 30}

                };
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var strategy = UpdateStrategyFactory.Create(item);
                strategy.UpdateItem(item);
            }
        }
        public void PrintData(string specificItem="")
        {
            System.Console.WriteLine($"Total Items in Stock: {Items.Count}");
            if(!string.IsNullOrEmpty(specificItem))
            {
                var foundItem = Items.Where(item => item.Name.Equals(specificItem));
                if(foundItem!=null)
                {
                    PrintItem(foundItem.FirstOrDefault());
                }
                else
                {
                    System.Console.WriteLine(specificItem + " : NOT FOUND");
                }
            }
            else
            {
                foreach (var item in Items)
                {
                    PrintItem(item);
                }
            }
            
        }
        public void PrintItem(Item item)
        {
            System.Console.WriteLine(item.Name + " : " + item.Quality.ToString());
        }
        public void EndOFDay()
        {
            var activity = new DailyActivity();
            activity.EndOFDay(Items);
        }
        public void StartOFDay()
        {
            var activity = new DailyActivity();
            Items=activity.StartOfDay();
        }
    }
}