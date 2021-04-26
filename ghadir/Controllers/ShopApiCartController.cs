using ghadir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ghadir.Controllers
{
    [System.Web.Mvc.Route("Api/[Controller]")]
    public class ShopApiCart : ApiController
    {
        // GET api/<controller>
        public List<ShopCartViewModel> Get()
        {
            var baseController = new BaseController();
            MyContext db = new MyContext();
            List<ShopCartViewModel> list = new List<ShopCartViewModel>();
            var cartResult =  baseController.GetSession<List<ShopCartItem>>("ShopCart");
            if (cartResult is null) return new List<ShopCartViewModel>();

            foreach (var shopCartItem in cartResult)
            {
                var product = db.Products.Find(shopCartItem.ProductID);
                list.Add(new ShopCartViewModel()
                {
                    ProductID = shopCartItem.ProductID,
                    Count = shopCartItem.Count,
                    Title = product.ProductTitle,
                    Price = product.Price,
                    Sum = shopCartItem.Count * product.Price,
                    ImageName = product.ImageName

                });
            }
            return list;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}