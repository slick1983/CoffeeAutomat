using CoffeeAutomat.Interfaces;
using System;

namespace CoffeeAutomat.Services
{
    public class AppService : IAppService
    {
        private readonly IAutomatService _automatService;

        public AppService(IAutomatService automatService)
        {
            _automatService = automatService;
            StartUp();
        }

        public void StartUp()
        {
            if (_automatService.IsMinimalMaterial())
            {
                Console.WriteLine("Автомат временно не работает");
            }
            HelloMessage();
            while (true)
            {
                string action = Console.ReadLine();
                if (action.Equals("0"))
                {
                    return;
                }
                if (action.Equals("1"))
                {
                    Console.WriteLine("Введите сумму в рублях");
                    string moneyString = Console.ReadLine();
                    if (int.TryParse(moneyString, out int money))
                    {
                        _automatService.SetDepositMoney(money);
                        GetMenu();
                    }
                    else
                    {
                        Console.WriteLine("Вводить только цифры");
                    }

                }
                HelloMessage();
            }
        }
        private static void HelloMessage()
        {
            Console.Clear();
            Console.WriteLine("Здравстуйте! введите номер действия!");
            Console.WriteLine("1) внести наличные");
            Console.WriteLine("0) Выход");
        }
        public void GetMenu()
        {
            MenuMessage();
            while (true)
            {
                string action = Console.ReadLine();
                if (action.Equals("0"))
                {
                    return;
                }
                if (action.Equals("1"))
                {
                    Select();
                    MenuMessage();
                }
                if (action.Equals("2"))
                {
                    Balance();
                }
                if (action.Equals("3"))
                {
                    PickUpMoney();
                }
                if (action.Equals("4"))
                {
                    Report();
                }
                if (action.Equals("5"))
                {
                    Refill();
                }
                if (action.Equals("6"))
                {
                    СashСollection();
                }
            }
        }
        private static void MenuMessage()
        {
            Console.Clear();
            Console.WriteLine("1) Выбрать напиток"); // Select
            Console.WriteLine("2) Баланс"); // Balance
            Console.WriteLine("3) Забрать сдачу"); // PickUpMoney
            Console.WriteLine("4) Остатки в автомате"); // Report
            Console.WriteLine("5) Пополнить автомат"); // Refill
            Console.WriteLine("6) Инкассация"); // СashСollection
            Console.WriteLine("0) Выход");
        }


        public void Select()
        {            
            while (true)
            {
                SelectMessage();
                string action = Console.ReadLine();
                if (action.Equals("0"))
                {
                    return;
                }
                if (action.Equals("1"))
                {
                    Console.WriteLine($"{_automatService.Espresso()}");
                }
                if (action.Equals("2"))
                {
                    Console.WriteLine($"{_automatService.Cappuccino()}");
                }
                Console.WriteLine("0) Предыдущее меню");
                while (true)
                {
                    string action1 = Console.ReadLine();
                    if (action1.Equals("0"))
                    {
                        break;
                    }
                }
                SelectMessage();
            }
        }
        private void SelectMessage()
        {
            Console.Clear();
            Console.WriteLine("Выберите напиток:");
            Console.WriteLine("1) Эспрессо:");
            Console.WriteLine("2) Капучино:");
            Console.WriteLine("0) Предыдущее меню:");
        }
        public void Balance()
        {
            Console.WriteLine($"Баланс:\t{_automatService.GetDepositMoney(),8}р.");
        }

        public void PickUpMoney()
        {
            Console.WriteLine($"Вы сняли деньги, ваш баланс:{_automatService.PickUpMoney()}");
        }

        public void Report()
        {
            Console.WriteLine(_automatService.Report());
        }

        public void Refill()
        {
            Console.Clear();
            Console.WriteLine("На сколько хотите пополнить?");
            Console.WriteLine("Воду:");
            string waterString = Console.ReadLine();
            _ = int.TryParse(waterString, out int water);
            Console.WriteLine("На сколько хотите пополнить?");
            Console.WriteLine("Молоко:");
            string milkString = Console.ReadLine();
            _ = int.TryParse(milkString, out int milk);
            Console.WriteLine("На сколько хотите пополнить?");
            Console.WriteLine("Стаканчики:");
            string cupsString = Console.ReadLine();
            _ = int.TryParse(cupsString, out int cups);
            Console.WriteLine("На сколько хотите пополнить?");
            Console.WriteLine("Зерна:");
            string coffeeBeansString = Console.ReadLine();
            _ = int.TryParse(coffeeBeansString, out int coffeeBeans);
            _automatService.Refill(water, milk, cups, coffeeBeans);
            while (true)
            {
                Console.WriteLine(_automatService.Report());
                Console.WriteLine();
                Console.WriteLine("0) Выход");
                string action = Console.ReadLine();
                if (action.Equals("0"))
                {
                    MenuMessage();
                    return;
                }
            }

        }

        public void СashСollection()
        {
            int coll = _automatService.СashСollection();
            if (coll == 0)
            {
                Console.WriteLine($"Нет денег для инкассации, наличные в автомате:{_automatService.GetMinimalMoney()}");
            }
            else
            {
                Console.WriteLine($"Инкассация на {coll}р., наличные в автомате:{_automatService.GetMinimalMoney()}");
            }
        }
    }
}
