using GrassTesting.Entity;
using System.Threading.Tasks;

namespace GrassTesting.Interfaces
{
    public interface ITravianPlayersService
    {
        Task<int?> GetNextViewer();

        Task SendInfo(TravianPlayerHistory dto);
    }
}
