using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.BLL.Repositories;
using CosmeticProductStore.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticProductStore.Client.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public static List<Product> Products = new List<Product> { };
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        ///  метод получения продукта по идентификатору
        /// </summary>
        /// <param name="id">Наименование продукта</param>

        [HttpGet("{Id:int}")]
        public Product Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product;
        }

        /// <summary>
        /// метод создания косметических продуктов
        /// </summary>
        /// <param name="body"></param>

        [HttpPost("{Id:int}")]
        public ActionResult Create(CreateProduct product)
        {
            _productRepository.CreateProduct(product);
            return Ok();
        }

        /// <summary>
        /// метод удаления косметического продукта по идентификатору
        /// </summary>
        /// <param name="cosmeticId">Идентификатор продукта</param>


        [HttpDelete("Id:int")]
        public void Delete(int ID) => Products.RemoveAt(ID);

    }
}
