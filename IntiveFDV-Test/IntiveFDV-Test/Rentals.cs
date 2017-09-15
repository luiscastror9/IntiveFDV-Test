using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_Test
{
    public class Rental
    {
        public int idRental { get; set; }
        public TypeRental TypeRental { get; set; }

    }
    public class TypeRental
    {
        public int idTypeRental { get; set; }
        public TimeRental TimeRental { get; set; }
        public double pricTypeRental { get; set; }

    }
    public class TimeRental
    {
        public int idTimeRental { get; set; }
        public string descTimeRental { get; set; }

    }
    public class FamilyRental
    {
        public int idTimeRental { get; set; }
        public List<Rental> Rentals{ get; set; }
        public double discountFamilyRental { get; set; }
    }
}
