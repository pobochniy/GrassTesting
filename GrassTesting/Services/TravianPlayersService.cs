using GrassTesting.Entity;
using GrassTesting.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GrassTesting.Services
{
    public class TravianPlayersService : ITravianPlayersService
    {
        private ApplicationContext db;
        public TravianPlayersService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<int?> GetNextViewer()
        {
            var date = DateTime.UtcNow.Date;

            var query = from p in db.TravianPlayersId
                        let isExist = db.TravianPlayersHistory.Where(x => x.Id == p.Id && x.Date == date).Any()

                        where !isExist
                        select p.Id;

            var res = await query.FirstOrDefaultAsync();
            return res;
        }

        public async Task SendInfo(TravianPlayerHistory dto)
        {
            dto.Date = DateTime.UtcNow.Date;

            await db.AddAsync(dto);
            await db.SaveChangesAsync();
        }
    }
}
