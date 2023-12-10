using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories;
public interface IStoreRepository
{
    Store GetStoreByCode(int id);
    void CreateStore(CreateStore store);
    void DeleteStore(int code);
}