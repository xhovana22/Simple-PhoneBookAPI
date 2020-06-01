using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.SL.DTO;
using PhoneBook.SL.Interface;

namespace PhoneBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _service;


        public PhoneBookController(IPhoneBookService service)
        {
            _service = service;
        }


        /// <summary>
        /// Get all Phone Books Ordered
        /// </summary>
        /// <param name="orderByName"> Name or Surname </param>
        /// <param name="asc"> True for asc and false for desc </param>
        /// <returns>List of phone books</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PhoneDTO>> Get(bool orderByName = true, bool asc = true)
        {
            var list = _service.GetAllOrdered(orderByName, asc).ToList();
            return list;
        }


        /// <summary>
        /// Create a new Phone Book Entry
        /// </summary>
        /// <param name="phoneBook"> Phone Book Entry </param>
        /// <returns> Created Phone Book </returns>
        // POST api/values
        [HttpPost]
        public ActionResult<PhoneDTO> Post([FromBody] PhoneDTO phoneBook)
        {
            return _service.Post(phoneBook);
        }



        /// <summary>
        /// Update Phone book
        /// </summary>
        /// <param name="id"> Phone Book id </param>
        /// <param name="phoneBook"> Phone Book Entry </param>
        /// <returns> Update phone book </returns>
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<PhoneDTO> Put(int id, [FromBody] PhoneDTO phoneBook)
        {
            if (id != phoneBook.Id)
            {
                 return new BadRequestObjectResult("Id-s do not match!!!");
            }

            return _service.Put(phoneBook);
        }


        /// <summary>
        /// Delete Phone Book 
        /// </summary>
        /// <param name="id"> Phone Book Id </param>
        /// <returns> True if deleted </returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}

