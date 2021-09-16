using CoffeeAutomat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAutomat.Services
{
    public class AutomatService : IAutomatService
    {
        private const int minimalMoney = 300; // минимальная сумма для сдач, р

        private int water = 5000; // вода, мл
        private int milk = 1000; // молоко, мл
        private int cups = 1000; // стаканчики, шт
        private int coffeeBeans = 1000; // кофейные зерна, гр
        private int boxMoney = 300; // наличные в автомате, р        
        private int DepositMoney = 0; // внесенные наличные, р

        public AutomatService()
        {
        }
        public void SetDepositMoney(int depositMoney)
        {
            DepositMoney = depositMoney;
        }
        public int GetDepositMoney()
        {
            return DepositMoney;
        }

        public int PickUpMoney()
        {
            DepositMoney -= DepositMoney;
            return DepositMoney;
        }

        public string Report()
        {
            return $"В автомате - Воды: {water}мл, Молока: {milk}мл, Кофейных зерен: {coffeeBeans}гр, Стаканчиков: {cups}шт, Денег: {boxMoney + DepositMoney}р";
        }

        public int СashСollection()
        {
            if (boxMoney >= minimalMoney)
            {
                return boxMoney - minimalMoney;
            }
            return 0;
        }

        public int GetMinimalMoney()
        {
            return minimalMoney;
        }

        public void Refill(int inwater, int inmilk, int incups, int incoffeeBeans)
        {
            water += inwater;
            milk += inmilk;
            cups += incups;
            coffeeBeans += incoffeeBeans;
        }

        public string Espresso()
        {
            int needWater = 30;
            int needCoffeeBeans = 10;
            int needMoney = 40;
            if (water < needWater)
            {
                return "Не хватает воды, пополните автомат!";
            }
            if (cups == 0)
            {
                return "Не хватает стаканчиков, пополните автомат!";
            }
            if (coffeeBeans < needCoffeeBeans)
            {
                return "Не хватает кофейных зерен, пополните автомат!";
            }
            if (DepositMoney < needMoney)
            {
                return "Не хватает денег, пополните автомат!";
            }
            water -= needWater;
            cups -= 1;
            coffeeBeans -= needCoffeeBeans;
            DepositMoney -= needMoney;
            boxMoney += needMoney;
            return "Эспрессо готово!";
        }

        public string Cappuccino()
        {
            int needWater = 50;
            int needMilk = 100;
            int needCoffeeBeans = 80;
            int needMoney = 70;
            if (water < needWater)
            {
                return "Не хватает воды, пополните автомат!";
            }
            if (milk < needMilk)
            {
                return "Не хватает молока, пополните автомат!";
            }
            if (cups == 0)
            {
                return "Не хватает стаканчиков, пополните автомат!";
            }
            if (coffeeBeans < needCoffeeBeans)
            {
                return "Не хватает кофейных зерен, пополните автомат!";
            }
            if (DepositMoney < needMoney)
            {
                return "Не хватает денег, пополните автомат!";
            }
            water -= needWater;
            milk -= needMilk;
            cups -= 1;
            coffeeBeans -= needCoffeeBeans;
            DepositMoney -= needMoney;
            boxMoney += needMoney;
            return "Капучино готово!";
        }

        public bool IsMinimalMaterial()
        {
            if (water < 50 || milk < 100 || cups == 0 || coffeeBeans < 50)
            {
                return false;
            }
            return true;
        }
    }
}
