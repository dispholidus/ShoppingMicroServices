using Microsoft.AspNetCore.Mvc;
using ShoppingMicroservices.Controller.Api;
using ShoppingMicroservices.Model;

namespace ShoppingMicroservices.Controller
{
    public class NotificationController : ControllerBase
    {
        public ActionResult SendNotification(Order order)
        {
            var message = order.ToString();
            return new JsonResult(message);
        }
    }
}
