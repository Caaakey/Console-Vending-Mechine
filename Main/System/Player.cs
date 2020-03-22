using System;
using System.Collections.Generic;

public class Player
{
    private static Player instance = null;
    public static Player Get
    {
        get
        {
            if (instance == null) instance = new Player();
            return instance;
        }
    }

    public int money = 5000;
    public Dictionary<string, int> inventory = new Dictionary<string, int>
    {
        { "Cola", 0 },
        { "Sida", 0 },
    };

    public void BuyDrink(string name, int cost)
    {
        if (!inventory.ContainsKey(name))
            inventory.Add(name, 0);

        money -= cost;
        inventory[name]++;
    }

    public bool IsCheck(int cost)
    {
        if (money >= cost) return true;
        return false;
    }

    public void PrintInventory()
    {
        MachineCore.PrintLine();
        Console.WriteLine(" Inventory list");
        foreach (KeyValuePair<string, int> i in inventory)
        {
            Console.WriteLine($"{i.Key} = {i.Value}");
        }
        MachineCore.PrintLine();
    }

    public void PrintMoney()
    {
        Console.WriteLine($"My Money ?\t{money.ToString()}");
    }

}
