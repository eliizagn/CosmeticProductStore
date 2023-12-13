using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.BLL.Repositories;
using CosmeticProductStore.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmeticProductStore.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockItemController : ControllerBase    
    {
        private readonly IStockItem _stockitemRepository;
        public static List<StockItem> StockItems = new List<StockItem> { };

        public StockItemController(IStockItem stockitemRepository)
        {
            _stockitemRepository = stockitemRepository;
        }

        [HttpGet]
        public StockItem Get(int storeCode, int productId)
        {
            var item = _stockitemRepository.GetStockItem(storeCode,productId);
            return item;
        }

        [HttpPut]
        public IActionResult Put(ChangeStockItem change)
        {
            _stockitemRepository.ChanginProductsinStore(change);
            return Ok();
        }

        [HttpGet("MinCost")]
        public IActionResult FindMinCost(int productId)
        {
            string cheapestStore = _stockitemRepository.FindMinCost(productId);

            if (cheapestStore == null)
            {
                return NotFound();
            }

            return Ok(cheapestStore); 
        }

        /// <summary>
        /// метод завезти партию косметических продуктов в магазин
        /// </summary>
        /// <param name="body"></param>
        /// 
        [HttpPost("")]
        public ActionResult Create(CreateStockItem stockitem)
        {
            _stockitemRepository.CreateStorewithProducts(stockitem);
            return Ok();
        }

        [HttpGet("WhatCanIBuy")]
        public IActionResult WhatCanIBuy(int storeCode, decimal budget)
        {
                var affordableProducts = _stockitemRepository.WhatCanIBuy(storeCode, budget);
                return Ok(affordableProducts);
        }

        [HttpPost("m")]
        public IActionResult BuyItemsInStore (BatchofProducts batch)
        {
            var price = _stockitemRepository.BuyItemsInStore(batch);
            return Ok(price);
        }
    }
}


