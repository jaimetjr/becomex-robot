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

        [HttpPost("RotatePlusPulse")]
        public IActionResult RotatePlusPulse([FromBody] string direction)
        {
            try
            {
                if (direction == "Esquerdo")
                {
                    if (_leftArm.Elbow != ElbowEnum.StronglyContracted)
                        return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                    _leftArm.Pulse = _service.RotatePlusPulse(_leftArm.Pulse);
                    _memory.Set(LeftArm, _leftArm);
                    return Ok(_leftArm.Pulse);
                }

                if (direction == "Direito")
                {
                    if (_rightArm.Elbow != ElbowEnum.StronglyContracted)
                        return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                    _rightArm.Pulse = _service.RotatePlusPulse(_rightArm.Pulse);
                    _memory.Set(RightArm, _rightArm);
                    return Ok(_rightArm.Pulse);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Erro ao mexer pulso");
        }

        [HttpPost("RotateMinusPulse")]
        public IActionResult RotateMinusPulse([FromBody] string direction)
        {
            try
            {
                if (direction == "Esquerdo")
                {
                    if (_leftArm.Elbow != ElbowEnum.StronglyContracted)
                        return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                    _leftArm.Pulse = _service.RotateMinusPulse(_leftArm.Pulse);
                    _memory.Set(LeftArm, _leftArm);
                    return Ok(_leftArm.Pulse);
                }

                if (direction == "Direito")
                {
                    if (_rightArm.Elbow != ElbowEnum.StronglyContracted)
                        return BadRequest("Pulso só pode ser movimentado com Cotovelo fortemente contraído");
                    _rightArm.Pulse = _service.RotateMinusPulse(_rightArm.Pulse);
                    _memory.Set(RightArm, _rightArm);
                    return Ok(_rightArm.Pulse);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Erro ao mexer pulso");
        }
    }
}
