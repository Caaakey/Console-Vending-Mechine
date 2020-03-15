using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class MachineCore
{
    public static void PrintLine()
        => Console.WriteLine("=======================================");

    public enum DrinkType : int
    {
        Cola = 1,
        Sida
    }

    public void Run()
    {
        Dictionary<string, int> buyList = new Dictionary<string, int>
        {
            { "Cola", 500 },
            { "Sida", 750 },
        };

        while (true)
        {
            Console.Clear();
            PrintLine();
            Console.WriteLine("\t\tVending Machine Project");
            PrintLine();
            Player.Get.PrintInventory();

            Console.WriteLine(" Buy list");
            int index = 1;
            foreach (KeyValuePair<string, int> n in buyList)
            {
                Console.WriteLine($" - {index++.ToString()} {n.Key} : {n.Value}");
            }
            PrintLine();
            Player.Get.PrintMoney();
            Console.WriteLine("\n원하는 번호를 선택해주세요");

            string input = Console.ReadLine();
            if (input.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
            {

                break;
            }

            if (!int.TryParse(input, out int select)) continue;
            DrinkType type = (DrinkType)select;

            switch (type)
            {
                case DrinkType.Cola:
                    if (Player.Get.IsCheck(buyList["Cola"]))
                        Player.Get.BuyDrink("Cola", buyList["Cola"]);
                    break;

                case DrinkType.Sida:
                    if (Player.Get.IsCheck(buyList["Sida"]))
                        Player.Get.BuyDrink("Sida", buyList["Sida"]);
                    break;
            }

            //  자판기를 구현하시면 됩니다
            //  인벤토리, 지갑 등 플레이어 정보 클래스 새로 만들어서 싱글턴화
            //  음료수 (상속을 이용해서 구현해보기)

            Thread.Sleep(500);
        }

        FileUtility.Save(Player.Get.inventory, Player.Get.money);
    }
}
