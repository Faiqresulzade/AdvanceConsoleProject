using Core;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Abstract
{
    public interface IAcountService
    {
        void Login();
        void Register(Employe employe);
    }
}
