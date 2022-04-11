using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PZCheeseria.Repository.Interface;
using System;

namespace PZCheeseria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheeseController : ControllerBase
    {
        private readonly ILogger<CheeseController> _logger;
        private readonly ICheeseRepository _cheeseRepository;

        public CheeseController(ILogger<CheeseController> logger, ICheeseRepository cheeseRepository)
        {
            _logger = logger;
            _cheeseRepository = cheeseRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try {
               return Ok(_cheeseRepository.GetAllCheese());
            }
            catch(Exception ex)
            {
                _logger.LogError("Something went woring when trying to get all cheese.", ex);
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result =_cheeseRepository.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went woring when trying to get a cheese with Id: {id}. Error: {ex}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
