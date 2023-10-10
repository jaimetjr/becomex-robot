using becomex_robot_api.Helpers;
using becomex_robot_api.Models;
using becomex_robot_api.Services.ArmService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace becomex_robot_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElbowController : ControllerBase
    {
        private const string LeftArm = "leftArm";
        private const string RightArm = "rightArm";

        private readonly IArmService _service;
        private Arm? _leftArm;
        private Arm? _rightArm;

        private IMemoryCache _memory;

        public ElbowController(IMemoryCache memory, IArmService service)
        {
            _memory = memory;

            if (!_memory.TryGetValue(LeftArm, out _leftArm))
            {
                _leftArm = new Arm();
                _memory.Set(LeftArm, _leftArm);
            }
            if (!_memory.TryGetValue(RightArm, out _rightArm))
            {
                _rightArm = new Arm();
                _memory.Set(RightArm, _rightArm);
            }
            _service = service;
        }


        [HttpPost("RiseArmElbow")]
        public IActionResult RiseArmElbow([FromBody] string direction)
        {
            try
            {
                if (direction == "Esquerdo")
                {
                    _leftArm.Elbow = _service.RiseElbow(_leftArm.Elbow);
                    _memory.Set(LeftArm, _leftArm);
                    return Ok(_leftArm.Elbow);
                }

                if (direction == "Direito")
                {
                    _rightArm.Elbow = _service.RiseElbow(_rightArm.Elbow);
                    _memory.Set(RightArm, _rightArm);
                    return Ok(_rightArm.Elbow);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Direção inválida");
        }

        [HttpPost("DescendArmElbow")]
        public IActionResult DescendArmElbow([FromBody] string direction)
        {
            try
            {
                if (direction == "Esquerdo")
                {
                    _leftArm.Elbow = _service.DescendElbow(_leftArm.Elbow);
                    _memory.Set(LeftArm, _leftArm);
                    return Ok(_leftArm.Elbow);
                }

                if (direction == "Direito")
                {
                    _rightArm.Elbow = _service.DescendElbow(_rightArm.Elbow);
                    _memory.Set(RightArm, _rightArm);
                    return Ok(_rightArm.Elbow);
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
