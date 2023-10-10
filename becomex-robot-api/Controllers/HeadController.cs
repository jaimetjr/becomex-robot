using becomex_robot_api.Models;
using becomex_robot_api.Services.HeadService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace becomex_robot_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadController : ControllerBase
    {
        private const string Head = "Head";
        private IMemoryCache _memory;
        private readonly IHeadService _service;
        private Head _head;

        public HeadController(IMemoryCache memory, IHeadService service)
        {
            _memory = memory;
            _service = service;

            if (!_memory.TryGetValue(Head, out _head))
            {
                _head = new Head();
                _memory.Set(Head, _head);
            }
        }

        [HttpPost("HeadInclination")]
        public IActionResult HeadInclination([FromBody] string direction)
        {
            try
            {
                if (direction == "Up")
                {
                    _head.Inclination = _service.HeadUp(_head.Inclination);
                    _memory.Set(Head, _head);
                    return Ok(_head.Inclination);
                }

                if (direction == "Down")
                {
                    _head.Inclination = _service.HeadDown(_head.Inclination);
                    _memory.Set(Head, _head);
                    return Ok(_head.Inclination);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Direção inválida");
        }

        [HttpPost("HeadRotation")]
        public IActionResult HeadRotation([FromBody] string direction)
        {
            if (_head.Inclination == Helpers.HeadInclinationEnum.Down)
                return BadRequest("Inclinação da cabeça não pode ser para baixo");

            try
            {
                if (direction == "Left")
                {
                    _head.Rotation = _service.HeadRotationMinus(_head.Rotation);
                    _memory.Set(Head, _head);
                    return Ok(_head.Rotation);
                }

                if (direction == "Right")
                {
                    _head.Rotation = _service.HeadRotationPlus(_head.Rotation);
                    _memory.Set(Head, _head);
                    return Ok(_head.Rotation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Direção inválida");
        }
    }
}
