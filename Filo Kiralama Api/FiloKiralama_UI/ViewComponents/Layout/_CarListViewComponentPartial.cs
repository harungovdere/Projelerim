using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FiloKiralama_UI.ViewComponents.Layout
{
    public class _CarListViewComponentPartial:ViewComponent
    {

        public async Task< IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
