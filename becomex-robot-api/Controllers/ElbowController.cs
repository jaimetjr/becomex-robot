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
        public IActionResult RiseArmElbow(string direction)
        {
            ElbowEnum nextState;
            if (direction == "left")
            {
                nextState = _service.RiseElbow(_leftArm.Elbow);
                _leftArm.Elbow = nextState;
                _memory.Set(LeftArm, _leftArm);
                return Ok(nextState);
            }

            if (direction == "right")
            {
                nextState = _service.RiseElbow(_rightArm.Elbow);
                _rightArm.Elbow = nextState;
                _memory.Set(RightArm, _rightArm);
                return Ok(nextState);
            }

            return BadRequest("Erro ao levantar cotovelo");
        }

        [HttpPost("DescendArmElbow")]
        public IActionResult DescendArmElbow(string direction)
        {
            ElbowEnum nextState;
            if (direction == "left")
            {
                nextState = _service.DescendElbow(_leftArm.Elbow);
                _leftArm.Elbow = nextState;
                _memory.Set(LeftArm, _leftArm);
                return Ok(nextState);
            }

            if (direction == "right")
            {
                nextState = _service.DescendElbow(_rightArm.Elbow);
                _rightArm.Elbow = nextState;
                _memory.Set(RightArm, _rightArm);
                return Ok(nextState);
            }

            return BadRequest("Erro ao levantar cotovelo");
        }
    }
}
