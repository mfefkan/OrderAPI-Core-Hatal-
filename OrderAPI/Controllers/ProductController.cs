using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.APIRequest;
using OrderAPI.APIResponseModels;
using OrderAPI.DTO;
using OrderAPI.Models.Context;
using OrderAPI.Models.Entities;

namespace OrderAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        MyContext _db;
        public ProductController(MyContext db)
        {
            _db = db;
        }
         
        [HttpGet]
        public ApiResponse GetProducts(string category = "")
        {
            ApiResponse response = new ApiResponse();

            if (category == "")
            {
                List<ProductDTO> productDTOs = _db.Products.Select(x => new ProductDTO
                {
                    Category = category,
                    Description = x.Description,
                    UnitPrice = x.UnitPrice,
                    Unit = x.Unit,
                    ID = x.ID
                }).ToList();
                response.Products = productDTOs;
            }
            else
            {
                List<ProductDTO> productDTOs = _db.Products.Where(x => x.Category == category).Select(x => new ProductDTO
                {
                    Category = category,
                    Description = x.Description,
                    UnitPrice = x.UnitPrice,
                    Unit = x.Unit,
                    ID = x.ID
                }).ToList();
                response.Products = productDTOs;
            }
            
            return response;

        }

        [HttpPost]
        public int CreateOrder(CreateOrderRequest newOrderReq) 
        {
            List<Product> products = new List<Product>();

            products = newOrderReq.Products.Select(x => new Product
            {
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                Unit = x.Unit,
                ID = x.ID,
                Category = x.Category
            }).ToList();

            Order newOrder = new Order
            {
                CustomerEmail = newOrderReq.CustomerEmail,
                CustomerName = newOrderReq.CustomerName,
                CustomerGSM = newOrderReq.CustomerGSM,
                Products = products
            };


            _db.Orders.Add(newOrder);

            return newOrder.ID;
        }

       

    }
}
