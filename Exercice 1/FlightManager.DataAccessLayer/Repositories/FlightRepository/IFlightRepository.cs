using FlightManager.DataAccessLayer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.DataAccessLayer.Repositories
{
    public interface IFlightRepository
    {
        Task<int> Create(Flight flight);
        Task Update(Flight flight);
        Task<bool> Delete(int id);
        IQueryable<Flight> GetAllFlights();
        Task<Flight> GetFlightById(int id);
    }
}
