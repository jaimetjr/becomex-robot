﻿using becomex_robot_api.Models;
using becomex_robot_api.Services.ArmService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace becomex_robot_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private const string LeftArm = "leftArm";
        private const string RightArm = "rightArm";
        private const string Head = "Head";

        private Arm? _leftArm;
        private Arm? _rightArm;
        private Head? _head;

        private IMemoryCache _memory;

        public HomeController(IMemoryCache memory)
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
            if (!_memory.TryGetValue(Head, out _head))
            {
                _head = new Head();
                _memory.Set(Head, _head);
            }
        }


        [HttpGet("GetArmStatus")]
        public IActionResult GetArmStatus(string armDirection)
        {
            if (string.IsNullOrEmpty(armDirection))
                return BadRequest("Nenhuma direção informada");
            if (armDirection == "Esquerdo")
                return Ok(_leftArm);
            if (armDirection == "Direito")
                return Ok(_rightArm);
            return BadRequest();
        }

        [HttpGet("GetHeadStatus")]
        public IActionResult GetHeadStatus()
        {
            if (_memory.TryGetValue(Head, out _head))
                return Ok(_head);
            return BadRequest("Status da cabeça invalido");
        }
    }
}
