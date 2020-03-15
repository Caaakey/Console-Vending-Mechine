using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.Load();

            MachineCore core = new MachineCore();
            core.Run();
        }
    }
}
