using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveFDV_Test
{
    /// <summary>
    /// 
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static Rental instance = null;

        /// <summary>
        /// Gets or sets the identifier rental.
        /// </summary>
        /// <value>
        /// The identifier rental.
        /// </value>
        public Guid idRental { get; set; }
        /// <summary>
        /// Gets or sets the startdate rental.
        /// </summary>
        /// <value>
        /// The startdate rental.
        /// </value>
        public DateTime startdateRental { get; set; }
        /// <summary>
        /// Gets or sets the enddate rental.
        /// </summary>
        /// <value>
        /// The enddate rental.
        /// </value>
        public DateTime enddateRental { get; set; }
        /// <summary>
        /// The hour time rental price
        /// </summary>
        public const double hourTimeRentalPrice = 5;
        /// <summary>
        /// The day time rental price
        /// </summary>
        public const double dayTimeRentalPrice = 20;
        /// <summary>
        /// The week time rental price
        /// </summary>
        public const double weekTimeRentalPrice = 60;

        /// <summary>
        /// Gets or sets the total rental.
        /// </summary>
        /// <value>
        /// The total rental.
        /// </value>
        public double totalRental { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static Rental GetInstance()
        {
            if (instance == null)
                instance = new Rental();

            return instance;
        }
        /// <summary>
        /// Rents the total.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Rentals the by hour.
        /// </summary>
        /// <param name="Hours">The hours.</param>
        /// <returns></returns>
        public Rental RentalByHour(int Hours)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Hours * hourTimeRentalPrice;

            return Rent;
        }
        /// <summary>
        /// Rentals the by days.
        /// </summary>
        /// <param name="Days">The days.</param>
        /// <returns></returns>
        public Rental RentalByDays(int Days)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Days * dayTimeRentalPrice;

            return Rent;
        }
        /// <summary>
        /// Rentals the by weeks.
        /// </summary>
        /// <param name="Weeks">The weeks.</param>
        /// <returns></returns>
        public Rental RentalByWeeks(int Weeks)
        {
            Rental Rent = new Rental();
            Rent.totalRental = Weeks * weekTimeRentalPrice;

            return Rent;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FamilyRental
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static FamilyRental instance = null;

        /// <summary>
        /// The minimum limit
        /// </summary>
        private const int MinLimit = 3;
        /// <summary>
        /// The maximum limit
        /// </summary>
        private const int MaxLimit = 5;

        /// <summary>
        /// Gets or sets the identifier family rental.
        /// </summary>
        /// <value>
        /// The identifier family rental.
        /// </value>
        public int idFamilyRental { get; set; }
        /// <summary>
        /// Gets or sets the rentals.
        /// </summary>
        /// <value>
        /// The rentals.
        /// </value>
        public List<Rental> Rentals { get; set; }
        /// <summary>
        /// Gets or sets the discount rental.
        /// </summary>
        /// <value>
        /// The discount rental.
        /// </value>
        public double discountRental { get; set; }

        /// <summary>
        /// Gets or sets the total rental.
        /// </summary>
        /// <value>
        /// The total rental.
        /// </value>
        public double totalRental { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static FamilyRental GetInstance()
        {
            if (instance == null)
            {
                instance = new FamilyRental();
                instance.Rentals = new List<Rental>();
            }
            return instance;
        }

        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="Rentals">The rentals.</param>
        /// <returns></returns>
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

   

