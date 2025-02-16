using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubFast.Api.Repositories;
using SubFast.Models;
using SubFast.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SubFast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _customerRepository.GetCustomers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var res = await _customerRepository.GetCustomer(id);
                if (res == null) {
                    return NotFound("No record found.");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCustomerDto model)
        {
            try
            {
                var customerAdded = await _customerRepository.AddCustomer(new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    DateOfBrith = model.DateOfBrith,
                    Gender = model.Gender
                });

                return CreatedAtAction(nameof(GetSingle), new { id = customerAdded.CustomerId }, customerAdded);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCustomerDto model)
        {
            try
            {
                var result = await _customerRepository.GetCustomer(id);
                if (result != null)
                {
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Email = model.Email;
                    result.DateOfBrith = model.DateOfBrith;
                    result.Gender = model.Gender;
                    result.PhotoPath = model.PhotoPath;

                    var updateResult = await _customerRepository.UpdateCustomer(result);
                    if(updateResult)
                        return Ok(updateResult);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return BadRequest("Failed! Could not update record.");
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _customerRepository.DeleteCustomer(id);
                if(res)
                    return Ok("Success! Record deleted.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return BadRequest("Failed! Could not delete record.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name, Gender? gender)
        {
            try
            {
                var result = await _customerRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
