using Microsoft.AspNetCore.Mvc;

namespace FiloKiralama_UI.ViewComponents.Layout
{
    public class _RentCarDetailViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
