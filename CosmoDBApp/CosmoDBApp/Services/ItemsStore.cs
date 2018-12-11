using CosmoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmoDBApp.Services
{
    public class ItemsStore
    {
        public ItemsStore()
        {
            //intialize 
        }

        public Task InsertItems(IEnumerable<Item> items)
        {
            //modify this to insert sample items into cosmo db
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Item>> GetAllItems()
        {
            var result = Enumerable.Empty<Item>();
            return Task.FromResult(result);
        }
    }
}
