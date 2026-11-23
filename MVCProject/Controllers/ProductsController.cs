using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    //CLR
    //[Route("[controller]/ahmed/[action]")]//-->Attribute Routing
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        //BaseURL/Products/GetproductById
        //Non-Static(Object Member Methods)
        public Product GetproductById(int id)
        {
            //logic -->connect to database and get product by id
            return new Product()
            {
                Id = 1,
                Name = "iPhone 16",
                Price = 999
            };
        }
        //Actions : Public Non-Static(  object member methods)
        //Action Results : Built-in DataType used as return type for action



        //BaseURL/Products/GetProducts
        [HttpGet]
        
        public JsonResult Getproducts()
        {
            return new JsonResult(new List<Product>()
            {
                new Product(){Id=1,Name="iPhone 16",Price=999},
                new Product(){Id=2,Name="Samsung Galaxy S23",Price=899},
                new Product(){Id=3,Name="Google Pixel 8",Price=799}
            });
        }
        //public List<Product> GetProducts()
        //{
        //    return new List<Product>()
        //    {
        //        new Product(){Id=1,Name="iPhone 16",Price=999},
        //        new Product(){Id=2,Name="Samsung Galaxy S23",Price=899},
        //        new Product(){Id=3,Name="Google Pixel 8",Price=799}
        //    };
        //}

        //verb-->Get,post,put,delete,patch


        [HttpGet("fun01")]
        public ViewResult Index()
        {
            return new  ViewResult();//HTML pages
        }
        [HttpGet]
        public FileContentResult DownloadFile()
        {
           var bytes=System.IO.File.ReadAllBytes("wwwroot/files/notes.txt");
            return new FileContentResult(bytes,"application/text");
        }
        [HttpGet]
        public RedirectResult RedirectToGoogle()
        {
            return new RedirectResult("https://www.google.com");
        }

        public RedirectToActionResult RedirectAction()
        {
            return new RedirectToActionResult("Index", "Products", null);
        }

        //public IActionResult Test(int id)
        //{
        //   if(id == 1)
        //    {
        //        return new ViewResult();
        //    }
        //    else if(id == 2)
        //    {
        //        return new JsonResult(new List<Product>()
        //        {
        //            new Product() { Id = 1, Name = "iPhone 16", Price = 999 }
        //        });
        //    }
        //    else if (id==3)
        //    {
        //        return new RedirectResult("https://www.google.com");
        //    }
        //   else
        //        return new ViewResult();
        //}
        public IActionResult Test(int id)
        {
            if (id == 1)
            {
                return  View();
            }
            else if (id == 2)
            {
                return  Json(new List<Product>()
                {
                    new Product() { Id = 1, Name = "iPhone 16", Price = 999 }
                });
            }
            else if (id == 3)
            {
                return  Redirect("https://www.google.com");
            }
            else
                return  View();
        }
    }
}
