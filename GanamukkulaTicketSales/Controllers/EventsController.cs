using GanamukkulaTicketSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace GanamukkulaTicketSales.Controllers
{
    public class EventsController : Controller
    {
        /*
         * Created by Ganamukkula 
         * 7777777777777777777777777
         */

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult EventList(string id = "All")
        {
            //uses EventsService to get the events, either all by default if there is no incoming value, or based on the ID of the event.
            //Instantiate the EVentsService class:

            EventsService eventService = new EventsService();

            //List of categories:
            List<Category> categories = eventService.GetCategories();

            //List of Events:
            List<Event> events = new List<Event>();

            //get the events based on Category ID:
            if(id == "All")
            {
                //get all events:
                events = eventService.GetAllEvents();
            }
            else
            {
                //Based on Id fund the category being asked for, if Id is specified then use the category to return all events of that type.
                //variable to hold category id:
                int selectedCategoryId = 0;
                foreach (Category cat in categories)
                {
                    if(cat.CategoryName == id)
                    {
                        selectedCategoryId = cat.Id;
                    }//if
                }//foreach

                foreach(Event anEvent in eventService.GetAllEvents() )
                {
                    if(anEvent.CategoryID == selectedCategoryId)
                    {
                        events.Add(anEvent);
                    }//id
                }//loop for finding events.
            }//if//else
            //return ListViewModel as a ViewModel with a collection of events ListViewModel listViewModel = new ListViewModel(events, categories, id);
            ListViewModel listViewModel = new ListViewModel(events, categories, id);
            return View(listViewModel);

        }//EventList()

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Details(int id)
        {
            EventsService eventService = new EventsService();
            Event oneEvent = eventService.GetEvent(id);
            return View(oneEvent);
        }//Details()
    }//Controller
}//Namespace
