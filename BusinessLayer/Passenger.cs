using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Passenger
    {
        public string name { get; set; }
        public string city { get; set; }
        public string singleConfig { get; set; }
        public string date { get; set; }
        public int ticketNumbers { get; set; }
        public string mobileNumber { get; set; }
        public string address { get; set; }
        public string toCity { get; set; }
        public string roundTrip { get; set; }
        public string toDate { get; set; }
        public string insuranceOpt { get; set; }
        public string email { get; set; }
    }
}
