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
    public class PulseController : ControllerBase
    {
        private const string LeftArm = "leftArm";
        private const string RightArm = "rightArm";

        private readonly IArmService _service;
        private Arm? _leftArm;
        private Arm? _rightArm;

        private IMemoryCache _memory;

        public PulseController(IMemoryCache memory, IArmService service)
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

        [HttpPost("RiseArmPulse")]
        public IActionResult RiseArmPulse(string direction)
        {
            PulseEnum nextState;
            if (direction == "left")
            {
                if (_leftArm.Elbow != ElbowEnum.StronglyContracted)
                    return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                nextState = _service.RisePulse(_leftArm.Pulse);
                _leftArm.Pulse = nextState;
                _memory.Set(LeftArm, _leftArm);
                return Ok(nextState);
            }

            if (direction == "right")
            {
                if (_rightArm.Elbow != ElbowEnum.StronglyContracted)
                    return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                nextState = _service.RisePulse(_rightArm.Pulse);
                _rightArm.Pulse = nextState;
                _memory.Set(RightArm, _rightArm);
                return Ok(nextState);
            }

            return BadRequest("Erro ao mexer pulso");
        }

        [HttpPost("DescendArmPulse")]
        public IActionResult DescendArmPulse(string direction)
        {
            PulseEnum nextState;
            if (direction == "left")
            {
                if (_leftArm.Elbow != ElbowEnum.StronglyContracted)
                    return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                nextState = _service.DescendPulse(_leftArm.Pulse);
                _leftArm.Pulse = nextState;
                _memory.Set(LeftArm, _leftArm);
                return Ok(nextState);
            }

            if (direction == "right")
            {
                if (_rightArm.Elbow != ElbowEnum.StronglyContracted)
                    return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                nextState = _service.DescendPulse(_rightArm.Pulse);
                _rightArm.Pulse = nextState;
                _memory.Set(RightArm, _rightArm);
                return Ok(nextState);
            }

            return BadRequest("Erro ao mexer pulso");
        }
    }
}
