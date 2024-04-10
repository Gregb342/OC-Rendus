using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICart _cart;
        private readonly IOrderService _orderService;
        private readonly IStringLocalizer<OrderController> _localizer;

        public OrderController(ICart pCart, IOrderService service, IStringLocalizer<OrderController> localizer)
        {
            _cart = pCart;
            _orderService = service;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            /*GRB : Modification de la méthode pour renvoyer vers les produits
             * si le panier est vide, avec affichage du message d'erreur correspondant.*/
            if (!((Cart)_cart).Lines.Any())
            {
                ModelState.AddModelError("", _localizer["CartEmpty"]);
                return RedirectToAction("Index", "Product");
            }

            return View(new Order());
        }
            
         
        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (!((Cart) _cart).Lines.Any())
            {
                ModelState.AddModelError("", _localizer["CartEmpty"]);
                return RedirectToAction("Index", "Product");
            }
            if (ModelState.IsValid)
            {
                order.Lines = (_cart as Cart)?.Lines.ToArray();
                _orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
