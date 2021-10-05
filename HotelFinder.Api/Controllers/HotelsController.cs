using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        ///  Get all Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{id}")] //api/hotels/GetHotelById/2
        public IActionResult GetHotelById(int id)
        {
            var hotel= _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel);
            }
            return NotFound();
           
        }
        /// <summary>
        /// Get Hotel By Name
        /// </summary>
        /// <param name='id'></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{name}")] //api/hotels/GetHotelByName/hotelName
        public IActionResult GetHotelByName(string name)
        {

            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);   
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotelByIdAndName(int id,string name)
        {

                return Ok();
        }
        /// <summary>
        /// Create New Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {
            
                var createHotel = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get",new { id=createHotel.Id},createHotel); //201+data
            
           
           
        }
        /// <summary>
        /// Update The hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// Delete The Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
