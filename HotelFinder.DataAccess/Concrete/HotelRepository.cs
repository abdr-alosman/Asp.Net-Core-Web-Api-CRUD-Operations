using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbCotext())
            {
                
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbCotext())
            {
                var deleteHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deleteHotel);
                hotelDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (var hotelDbContext=new HotelDbCotext()) {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbCotext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }
        public Hotel GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbCotext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(x=>x.Name.ToLower()==name.ToLower());
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbCotext())
            {

                hotelDbContext.Hotels.Update(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
