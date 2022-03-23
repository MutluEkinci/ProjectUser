using BusinessLayer;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.PresentationLayer.Controllers
{
    public class ProductsController : Controller
    {
        private IRepositoryAPI<Product> _product;

        public ProductsController()
        {
            _product = new GenericRepositoryAPI<Product>("http://localhost:64765/api/product");
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetAll());
        }

    }
}
