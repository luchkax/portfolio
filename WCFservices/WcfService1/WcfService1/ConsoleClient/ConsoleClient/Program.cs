using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using ConsoleClient.ServiceReference1;



namespace ConsoleClient

{

    class Program

    {

        static void Main(string[] args)

        {
            CalculatorClient proxy = new CalculatorClient();

            Console.WriteLine("Please specify your action:");
            Console.WriteLine("1. Add; 2. Substract; 3. Multiply; 4. Divide");
            double action = Convert.ToInt32(Console.ReadLine());

            if(action == 1)
            {
                Console.WriteLine("Enter first number:");
                double number10 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double number20 = Convert.ToInt32(Console.ReadLine());

                double addResult = proxy.AddNumbers(number10, number20);
                Console.WriteLine("Result of Add Operation");
                Console.WriteLine(addResult);

            }
            else if( action == 2)
            {
                Console.WriteLine("Enter first number:");
                double number11 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double number21 = Convert.ToInt32(Console.ReadLine());

                double subResult = proxy.SubstractNumbers(number11, number21);
                Console.WriteLine("Result of Substract Operation");
                Console.WriteLine(subResult);
            }
            else if( action == 3)
            {
                Console.WriteLine("Enter first number:");
                double number12 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double number22 = Convert.ToInt32(Console.ReadLine());

                double mulResult = proxy.MultiplyNumbers(number12, number22);
                Console.WriteLine("Result of Multiply Operation");
                Console.WriteLine(mulResult);
            }
            else if (action == 4)
            {
                Console.WriteLine("Enter first number:");
                double number13 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double number23 = Convert.ToInt32(Console.ReadLine());

                double divResult = proxy.DivisionNumbers(number13, number23);
                Console.WriteLine("Result of Division Operation");
                Console.WriteLine(divResult);
            }
            else
            {
                Console.WriteLine("Yo have entered incorrect action!");
            }

            Console.ReadKey(true);
        }
    }

}