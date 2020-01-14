using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrassTesting.Entity;
using GrassTesting.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrassTesting.Controllers
{
    [Route("api/[controller]")]
    public class ObserverController : Controller
    {
        private readonly ITravianPlayersService service;

        public ObserverController(ITravianPlayersService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNextViewer()
        {
            var res = await service.GetNextViewer();
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendInfo([FromBody] TravianPlayerHistory dto)
        {
            await service.SendInfo(dto);
            return Ok();
        }
    }
}
