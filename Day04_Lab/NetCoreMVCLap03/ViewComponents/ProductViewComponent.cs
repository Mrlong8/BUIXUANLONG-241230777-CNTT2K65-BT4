using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLap03.Models;

namespace NetCoreMVCLap03.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Product product = new Product();
            var products = product.GetListproduct();
            return View(products);
        }
    }
}
