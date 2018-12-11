using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmoDBApp.Models
{
    public class ItemsSampleData
    {
       public static IEnumerable<Item> GetItems()
        {
            yield return new Item
            {
                Name = "groceries",
                Category = "personal",
                Description = "pick up apples and bananas",
                IsComplete = false
            };


            yield return new Item
            {
                Name = "groceries",
                Category = "personal",
                Description = "Get Milk",
                IsComplete = false
            };

            yield return new Item
            {
                Name = "Snacks",
                Category = "personal",
                Description = "buy chips and coke",
                IsComplete = false
            };
        }
    }
}
