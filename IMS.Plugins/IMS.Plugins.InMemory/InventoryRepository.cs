using IMS.Entities;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {

        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 40 },
                new Inventory { InventoryId = 2, InventoryName = "Space Jam", Quantity = 2, Price = 40 },
                new Inventory { InventoryId = 3, InventoryName = "Megaman", Quantity = 5, Price = 80 }
            
            };
        }




        public async Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            //returns ienumarable cuz where
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));



        }
    }
}
