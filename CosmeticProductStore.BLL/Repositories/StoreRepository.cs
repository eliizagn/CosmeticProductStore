using CosmeticProductStore.DAL.Data.Models;
using CosmeticProductStore.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmeticProductStore.BLL.Models;

namespace CosmeticProductStore.BLL.Repositories;

internal class StoreRepositoryDb { };

public class StoreRepository : IStoreRepository
{
    private readonly StoreDbContext _dbContext;

    public StoreRepository(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Store GetStoreByCode(int id)
    {
        return _dbContext.Stores.FirstOrDefault(s => s.StoreCode == id);
    }

    public void CreateStore(CreateStore store)
    {
        var storeEntity = new Store();
        storeEntity.Name = store.Name;
        storeEntity.Address = store.Address;

        _dbContext.Stores.Add(storeEntity);
        _dbContext.SaveChanges();

    }
    public void DeleteStore(int code)
    {
        var storeToDelete = _dbContext.Stores.FirstOrDefault(s => s.StoreCode == code);

        if (storeToDelete != null)
        {
            _dbContext.Stores.Remove(storeToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new Exception("Store not found");
        }
    }
}
