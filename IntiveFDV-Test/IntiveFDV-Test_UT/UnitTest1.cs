using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IntiveFDV_Test_UT
{
    [TestClass]
    public class UnitTestIntiveFDV_Test
    {
        [TestMethod]
        public void TestMethodBasic()
        {
            IntiveFDV_Test.Rental Rent = new IntiveFDV_Test.Rental();
         
        }

        [TestMethod]
        public void TestMethodDate()
        {
            DateTime startdate = new DateTime(2017, 09, 15, 09, 15, 25);
            DateTime enddate = new DateTime(2017, 09, 30, 09, 15, 25);


            double rs;
            IntiveFDV_Test.Rental Rent = new IntiveFDV_Test.Rental();
            TimeSpan diff = enddate.Subtract(startdate);
            //DateTime dt = Convert.ToDateTime(diff.ToString());
            rs = Convert.ToDouble(Rent.RentalByDays(diff.Days).totalRental+ Rent.RentalByHour(diff.Hours).totalRental + (diff.Days>=7 ? Rent.RentalByWeeks(diff.Days / 7).totalRental : 0) );
            //Assert.AreEqual(60, rs);
            System.Diagnostics.Debug.WriteLine(rs);

            //return rs;
        }
        [TestMethod]
        public void TestMethodDateDetailed()
        {
            DateTime startdate = new DateTime(2017, 09, 15, 09, 15, 25);
            DateTime enddate = new DateTime(2017, 09, 30, 09, 15, 25);


            double rs;
            IntiveFDV_Test.Rental Rent = new IntiveFDV_Test.Rental().RentTotal(startdate, enddate);
           // Rent.RentTotal(startdate, enddate);
            System.Diagnostics.Debug.WriteLine("Rental ID:"+Rent.idRental);
            System.Diagnostics.Debug.WriteLine("Rental Start Date:" + Rent.startdateRental);
            System.Diagnostics.Debug.WriteLine("Rental End Date:" + Rent.enddateRental);
            System.Diagnostics.Debug.WriteLine("Rental Total:" + Rent.totalRental);

            //return rs;
        }

        [TestMethod]
        public void TestMethodTotalDiscount()
        {
            DateTime startdate = new DateTime(2017, 09, 15, 09, 15, 25);
            DateTime enddate = new DateTime(2017, 09, 30, 09, 15, 25);

            IntiveFDV_Test.FamilyRental fR =  IntiveFDV_Test.FamilyRental.GetInstance();
            IntiveFDV_Test.Rental Rent = new IntiveFDV_Test.Rental().RentTotal(startdate, enddate);
            fR.Rentals.Add(Rent);
            //fR.Rentals.Add(Rent);
            //fR.Rentals.Add(Rent);
            fR.Rentals.Add(Rent);
            fR.discountRental = IntiveFDV_Test.FamilyRental.GetInstance().GetDiscount(fR.Rentals);
            fR.totalRental =fR.Rentals.Sum(z => Convert.ToDouble(z.totalRental))-fR.discountRental;
            System.Diagnostics.Debug.WriteLine("Family Rental ID:" + fR.idFamilyRental);

            foreach (IntiveFDV_Test.Rental rnt in fR.Rentals)
            {
                System.Diagnostics.Debug.WriteLine("Rental ID:" + rnt.idRental);
                System.Diagnostics.Debug.WriteLine("Rental Start Date:" + rnt.startdateRental);
                System.Diagnostics.Debug.WriteLine("Rental End Date:" + rnt.enddateRental);
                System.Diagnostics.Debug.WriteLine("Rental Total:" + rnt.totalRental);
            }
            System.Diagnostics.Debug.WriteLine("Family Rental Discount:" + fR.discountRental);
            System.Diagnostics.Debug.WriteLine("Family Rental Total:" + fR.totalRental);
        }
    }
}
