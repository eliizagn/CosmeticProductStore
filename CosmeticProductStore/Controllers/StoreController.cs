using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.BLL.Repositories;
using CosmeticProductStore.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticProductStore.Client.Controllers;
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    public static List<Store> Stores = new List<Store> { };


    public StoreController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    /// <summary>
    ///  метод получения магазина по идентификатору
    /// </summary>
    /// <param name="id">Наименование магазина</param>

    [HttpGet("{storeCode:int}")]
    public Store Get(int storeCode)
    {
        var store = _storeRepository.GetStoreByCode(storeCode);
        return store;
    }

    /// <summary>
    ///  метод получения информации о всех продуктах
    /// </summary>
    /// <param name="id">Идентификатор продукта</param>
    [HttpGet]
    public List<Store> GetAll() => Stores;

    /// <summary>
    /// метод создания магазина косметических продуктов
    /// </summary>
    /// <param name="body"></param>

    [HttpPost("{storeCode:int}")]
    public ActionResult Create(CreateStore store)
    {
        _storeRepository.CreateStore(store);
        return Ok();
    }

    /// <summary>
    /// метод удаления косметического продукта по идентификатору
    /// </summary>
    /// <param name="cosmeticId">Идентификатор продукта</param>

    [HttpDelete("storeCode:int")]
    public void Delete(int ID) => Stores.RemoveAt(ID);

}
