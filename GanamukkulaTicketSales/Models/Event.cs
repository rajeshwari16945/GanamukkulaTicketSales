namespace GanamukkulaTicketSales.Models
{
    /*
     * Created by Ganamukkula
     * 222222222222222222222222222222
     * This class creates a type for Events.
     * Each Event has an event name (Title property), description for the event, the category of the event, and has an image to disokay.
     */
    public class Event
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int  CategoryID { get; set; }
        public double TicketPrice { get; set; }
        public string? Description { get; set; }
        public string? ImageId { get; set; }
    }//event class
}//namespace TicketSales2023.Models
