using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Models.Repos;
using BikeStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepo _repo;
        private readonly IMapper _mapper;

        public HomeController(IProductsRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        [Route("")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            var bikes = _repo.GetProducts();
            var bikesCard = bikes.Select(b => _mapper.Map<BikeCardViewModel>(b));
            return View(bikesCard);
        }
    }
}