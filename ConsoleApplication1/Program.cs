using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static DateTime dataTime;
        private static String t1;

        private static void Main(string[] args)
        {
            #region value type of datetime

            Console.WriteLine(dataTime == default(DateTime));
            Console.WriteLine(t1 == default(string));

            #endregion

            #region linq

            int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7};


            Console.WriteLine(numbers.Where(new test().Predicate).Take(3).Sum());
            Console.WriteLine(numbers.Count(i=>i%2==0));

            #endregion

            #region decimal 

            double x = 5.0;

            int y = 5;
            decimal z = new decimal(5.000);


            float f = 10;

            Console.WriteLine(x == y);
            Console.WriteLine(z);
            Console.WriteLine(f/2);

            #endregion

            #region function argement 

            var circle = new Circle();
            circle.Calculate(new test().op);
            circle.Calculate(r => Math.PI*r*r);
            circle.Calculate((r, r1) => Math.PI*r*r);

            #endregion

            

            #region await sync

            var task = SaySomething(); //This is where the action start in a new thread.

            Thread.Sleep(2000); //if the current main thread running longer than the new thread. It is wasted of the new thread. 
//            Thread.Sleep(1000); //if the current main thread running longer than the new thread. It is wasted of the new thread. 

            Console.WriteLine("DOING OTHER THING. NO DELAY.");
            Console.WriteLine(result);

            task.Wait(); // Same as task.Result, rather no need to introduce variable.
            
            Console.WriteLine(result);

            #endregion

            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static string result = "empty string";

        private static async Task<string> SaySomething()
        {
            await System.Threading.Tasks.Task.Delay(1500);
            result = "Hello world!";
            return "Something";
        }
    }

    internal class test
    {
        public bool Predicate(int i)
        {
            return i%2 == 0;
        }

        public double op(double radius)
        {
            return Math.PI*Math.Pow(radius, 2);
        }
    }

    public sealed class Circle
    {
        private double radius;

        public double Calculate(Func<double, double> op)
        {
            return op(radius);
        }

        public double Calculate(Func<double, double, double> op)
        {
            return op(radius, radius);
        }
    }
}