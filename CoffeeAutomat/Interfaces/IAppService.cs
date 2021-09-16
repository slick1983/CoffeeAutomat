using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAutomat.Interfaces
{
    public interface IAppService
    {
        void StartUp();
        void GetMenu();
        void Select();
        void Balance();
        void PickUpMoney();
        void Report();
        void Refill();
        void СashСollection();
    }
}
