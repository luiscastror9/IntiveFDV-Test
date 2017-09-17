using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_Test
{
    public class Rental
    {
        private static Rental instance = null;

        public Guid idRental { get; set; }
        public DateTime startdateRental { get; set; }
        public DateTime enddateRental { get; set; }
        public const double hourTimeRentalPrice = 5;
        public const double dayTimeRentalPrice = 20;
        public const double weekTimeRentalPrice = 60;

        public double totalRental { get; set; }

        public static Rental GetInstance()
        {
            if (instance == null)
                instance = new Rental();

            return instance;
        }
        public Rental RentTotal(DateTime start,DateTime end)
        {

            Rental Rent = new Rental();
            Rent.idRental = new Guid();
            TimeSpan diff = end.Subtract(start);
            //DateTime dt = Convert.ToDateTime(diff.ToString());
            Rent.startdateRental = start;
            Rent.enddateRental = end;
            Rent.totalRental= Convert.ToDouble(Rent.RentalByDays(diff.Days).totalRental + Rent.RentalByHour(diff.Hours).totalRental + (diff.Days >= 7 ? Rent.RentalByWeeks(diff.Days / 7).totalRental : 0));
            return Rent;
        }

        public Rental RentalByHour(int Hours)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Hours * hourTimeRentalPrice;

            return Rent;
        }
        public Rental RentalByDays(int Days)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Days * dayTimeRentalPrice;

            return Rent;
        }
        public Rental RentalByWeeks(int Weeks)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Weeks * weekTimeRentalPrice;

            return Rent;
        }
    }
    public class FamilyRental
    {
        private static FamilyRental instance = null;

        private const int MinLimit = 3;
        private const int MaxLimit = 5;

        public int idFamilyRental { get; set; }
        public List<Rental> Rentals { get; set; }
        public double discountRental { get; set; }

        public double totalRental { get; set; }

        public static FamilyRental GetInstance()
        {
            if (instance == null)
            {
                instance = new FamilyRental();
                instance.Rentals = new List<Rental>();
            }
            return instance;
        }

        public double GetDiscount(ICollection<Rental> Rentals)
        {
            double discount = 0;
            const int discountPercentFamilyRental = 30;
            if (Rentals.Count() > MinLimit && Rentals.Count() <= MaxLimit)
                discount = Rentals.Sum(z => Convert.ToDouble(z.totalRental))*discountPercentFamilyRental /100;
            
            return discount;
    }
    }

    

   
   
}

   

