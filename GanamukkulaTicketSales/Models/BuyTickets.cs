using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GanamukkulaTicketSales.Models
{
    public class BuyTickets
    {
        /*
         * *Created by Ganamukkula
         * 555555555555555555555555555
         * 
         */

        private const Double SR_DISCOUNT_RATE = 0.2D;

        public string? EventName { get; set; }
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Email is a required Field.")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        [Display(Name = "Email Address: ")]
        public string? Email {  get; set; }

        public double TicketPrice { get; set; }
        public string? SaleDate { get; set; }

        [Required(ErrorMessage = "Please ENter Number of Tickets.")]
        [Range(1, 10, ErrorMessage = "Number of tickets should be between 1 and 10")]
        public int NumberOfTickets { get; set; }

        [Display(Name = "Senior Discount: ")]
        public bool SeniorDiscount { get; set; }

        [Required(ErrorMessage = "Delivery Option is required.")]
        [Display(Name = "Select mode of delivery: ")]
        public string? DeliveryMode {  get; set; }

        public double SubTotal { get; set; }
        public double SaleDiscount { get; set; }
        public double DeliveryCharge { get; set; }
        public double AmountDue { get; set; }
        public List<SelectListItem> DeliveryOptions = new()
        {
            new SelectListItem { Text = "", Value = "None"},
            new SelectListItem { Text = "Mail", Value = "Mail"},
            new SelectListItem { Text = "Print at Home", Value = "Print"},
            new SelectListItem { Text = "Digital Ticket", Value = "Digital"},
            new SelectListItem { Text = "Will Call", Value = "Call"}
        };

        public BuyTickets()
        {
            //parameterless constructor for use with binding model
        }

        public BuyTickets(string? eventName, double ticketPrice)
        {
            this.EventName = eventName;
            this.TicketPrice = ticketPrice;
        }

        public void CalculateDiscount()
        {
            SaleDiscount = SubTotal * SR_DISCOUNT_RATE;
        }//CalculateDiscount()

        public void CalculateAmountDue()
        {
            //Calculates the amount due and sets the salesDate.
            SaleDate = DateTime.Today.ToShortDateString();
            SubTotal = TicketPrice * NumberOfTickets;
            //check if there is senior discount:
            if(SeniorDiscount)
            {
                CalculateDiscount();
            }
            if(DeliveryMode == "Mail")
            {
                DeliveryCharge = 3.95;
            }
            else
            {
                DeliveryCharge = 0;
            }
            AmountDue = SubTotal - SaleDiscount + DeliveryCharge;
        }
    }//Sale
}
