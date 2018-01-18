using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        private static Input input = new Input();
        static void Main(string[] args)
        {
            input.CreatePlayer();

            input.PlayerMenu();

            Console.ReadKey();
        }

        
    }
}
