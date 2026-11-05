using IMS.Entities;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByName
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}