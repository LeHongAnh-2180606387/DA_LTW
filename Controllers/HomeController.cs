using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VoLeAnhTien_2180604444_Tuan6.Models;
using VoLeAnhTien_2180604444_Tuan6.Respository;

namespace VoLeAnhTien_2180604444_Tuan6.Controllers
{
    public class HomeController : Controller
    {
            private readonly IProductRepository _productRepository;
            private readonly ICategoryRepository _categoryRepository;
            public HomeController(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            // Hiển thị danh sách sản phẩm
            public async Task<IActionResult> Index()
            {
                var products = await _productRepository.GetAllAsync();
                return View(products);
            }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}