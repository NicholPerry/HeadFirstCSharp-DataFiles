using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoothItems;

namespace People
{
    /// <summary>
    /// The class which is used to represent a giving booth.
    /// </summary>
    public class GivingBooth : Booth
    {
        /// <summary>
        /// Initializes a new instance of the GivingBooth class.
        /// </summary>
        /// <param name="attendant"> The attendant of the booth.</param>
        public GivingBooth(Employee attendant)
            : base(attendant)
        {
            // Create 5 coupon books.
            for (int i = 0; i < 5; i++)
            {
                this.Items.Add(new CouponBook(DateTime.Now, DateTime.Now.AddYears(1), 0.8));
            }

            // Create 10 maps.
            for (int i = 0; i < 10; i++)
            {
                this.Items.Add(new Map(0.5, DateTime.Now));
            }
        }

        /// <summary>
        /// Gives a free coupon book.
        /// </summary>
        /// <returns> Returns the coupon book.</returns>
        public CouponBook GiveFreeCouponBook()
        {
            // Define variable to hold coupon book.
            CouponBook couponBook = null;

            try
            {
                couponBook = this.Attendant.FindItem(this.Items, typeof(CouponBook)) as CouponBook;
            }
            catch (MissingItemException ex)
            {
                throw new NullReferenceException("Coupon book not found.", ex);
            }

            return couponBook;
        }

        /// <summary>
        /// Gives a free map.
        /// </summary>
        /// <returns> Returns the map.</returns>
        public Map GiveFreeMap()
        {
            // Define variable to hold map.
            Map map = null;

            try
            {
                map = this.Attendant.FindItem(this.Items, typeof(Map)) as Map;
            }
            catch (MissingItemException ex)
            {
                throw new NullReferenceException("Map not found.", ex);
            }

            return map;
        }
    }
}
