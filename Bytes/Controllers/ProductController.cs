using Bytes.DAL;
using Bytes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytes.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult GetAllProducts()
        {
            ProductDAL proDAL = new ProductDAL();
            ModelState.Clear();
            return View(proDAL.GetAllProducts());
        }

        
        public ActionResult AddProduct()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult AddProduct(Product obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDAL proDAL = new ProductDAL();
                    if (proDAL.AddProduct(obj))
                    {
                        ViewBag.Message = "New product successfully added";
                    }
                }
                return View();
            }

            catch
            {
                return View();
            }
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductDAL proDAL = new ProductDAL();
            return View(proDAL.GetAllProducts().Find(ProductItem => ProductItem.ProductID == id));
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product obj)
        {
            try
            {

                ProductDAL proDAL = new ProductDAL();
                proDAL.UpdateProduct(obj);
                return RedirectToAction("GetAllProducts");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            try
            {
                ProductDAL proDAL = new ProductDAL();
                if (proDAL.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product successfully deleted";
                }
                return RedirectToAction("GetAllProducts");
            }

            catch 
            {
                return View();
            }
            
        }

    }
}
