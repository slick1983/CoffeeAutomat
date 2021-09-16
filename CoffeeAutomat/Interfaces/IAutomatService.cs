using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAutomat.Interfaces
{
    public interface IAutomatService
    {
        void SetDepositMoney(int depositMoney);
        int GetDepositMoney();
        int PickUpMoney();
        string Report();
        int СashСollection();
        int GetMinimalMoney();
        void Refill(int water, int milk, int cups, int coffeeBeans);
        string Espresso();
        string Cappuccino();
        bool IsMinimalMaterial();
    }
}
