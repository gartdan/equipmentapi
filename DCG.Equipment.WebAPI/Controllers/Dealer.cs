using System;
using System.Collections.Generic;
using System.Linq;

namespace DCG.Equipment.WebAPI.Controllers
{
    public class Dealer
    {

        public string Id { get; set; }
        public string DealerName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        
        public static IList<Dealer> GetDealers()
        {
            return new List<Dealer>()
            {
                new Dealer() { Address = "1002 West Jefferson Street", City="ShoreWood", State = "IL" ,  DealerName= "Shorewood Home and Auto", Id="011110", ZipCode="60404"},
                new Dealer() { Address = "559 South Main", City="Elburn", State = "IL" ,  DealerName= "AHW, LLC", Id="022210", ZipCode="60404"},
                new Dealer() { Address = "1080 E Park Ave", City="Libertyville", State = "IL" ,  DealerName= "Buck Bros., Inc", Id="033010", ZipCode="60048"}

            };
        }

        public static Dealer GetRandomDealer()
        {
            return GetDealers().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

    }



}
    
