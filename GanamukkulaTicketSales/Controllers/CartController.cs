using GanamukkulaTicketSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace GanamukkulaTicketSales.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Buy(int id)
        {
            EventsService eventsService = new EventsService();
            Event selectedEvent = eventsService.GetEvent(id);

            BuyTickets buyTickets = new BuyTickets(selectedEvent.Title, selectedEvent.TicketPrice);
            return View(buyTickets);
        }

        public IActionResult Confirmation(BuyTickets model) { 
            if(ModelState.IsValid)
            {
                model.CalculateAmountDue();
                return View(model);
            }
            return View("Buy", model);
        }
    }
}
