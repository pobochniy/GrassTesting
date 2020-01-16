using GrassTesting.Entity;
using GrassTesting.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GrassTesting.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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
            return Ok(true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemovePlayer(int pid)
        {
            await service.RemovePlayer(pid);
            return Ok(true);
        }
    }
}
