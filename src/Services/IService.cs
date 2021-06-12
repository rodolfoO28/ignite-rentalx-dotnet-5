using System.Threading.Tasks;

namespace Rentalx.Services
{
    public interface IService<Request>
    {
        Task Execute(Request data);
    }

    public interface IService<Request, Response>
    {
        Task<Response> Execute(Request data);
    }
}