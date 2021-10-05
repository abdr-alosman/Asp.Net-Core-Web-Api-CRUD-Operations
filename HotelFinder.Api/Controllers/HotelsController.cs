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
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{action}/{id}")] //api/hotels/GetHotelById/2
        public async Task <IActionResult> GetHotelById(int id)
        {
            var hotel= await _hotelService.GetHotelById(id);
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
        public async Task<IActionResult> GetHotelByName(string name)
        {

            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);   
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHotelByIdAndName(int id,string name)
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
        public async Task<IActionResult> CreateHotel([FromBody]Hotel hotel)
        {
            
                var createHotel =await _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get",new { id=createHotel.Id},createHotel); //201+data
            
           
           
        }
        /// <summary>
        /// Update The hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// Delete The Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
