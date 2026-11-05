using System;
using System.Collections.Generic;
using System.Text;
using IMS.Entities;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;


namespace IMS.UseCases.Inventories
{
    public class ViewInventoryByName : IViewInventoryByName
    {
        private readonly IInventoryRepository inventoryRepository;
        public ViewInventoryByName(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRepository.GetInventoryByNameAsync(name);
        }

    }
}
