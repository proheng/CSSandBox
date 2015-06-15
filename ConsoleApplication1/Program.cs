using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static DateTime dataTime;
        private static string t1;
        private static string result = "empty string";

        private static void Main(string[] args)
        {
            #region value type of datetime

            Console.WriteLine(dataTime == default(DateTime));
            Console.WriteLine(t1 == default(string));

            #endregion

            #region linq

            int[] numbers = {1, 2, 3, 4, 5, 6, 7};


            Console.WriteLine(numbers.Where(new test().Predicate).Take(3).Sum());
            Console.WriteLine(numbers.Count(i => i%2 == 0));

            #endregion

            #region decimal 

            var x = 5.0;

            var y = 5;
            var z = new decimal(5.000);


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

            Thread.Sleep(2000);
                //if the current main thread running longer than the new thread. It is wasted of the new thread. 
//            Thread.Sleep(1000); //if the current main thread running longer than the new thread. It is wasted of the new thread. 

            Console.WriteLine("DOING OTHER THING. NO DELAY.");
            Console.WriteLine(result);

            task.Wait(); // Same as task.Result, rather no need to introduce variable.

            Console.WriteLine(result);

            #endregion

            #region inheritance

            var f1 = new Foo();
            f1.M();

            Foo b = new Bar();
            b.M();

            var b1 = new Bar();
            b1.M();

            A a = new A();
            Console.WriteLine(a);
            B bb = new B();
            Console.WriteLine(bb);
            Console.WriteLine("TEST Method" + bb.test());
            A bbb = new B();
            Console.WriteLine(bbb);
            Console.WriteLine("TEST Method" + bbb.test());

            #endregion

            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static async Task<string> SaySomething()
        {
            await Task.Delay(1500);
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

    internal class Foo
    {
        public void M()
        {
            Console.WriteLine("Foo.M");
        }
    }

    internal class Bar : Foo
    {
        public new void M()
        {
            Console.WriteLine("Bar.M");
        }
    }

    class A
    {
        /*public virtual string ToString() Won't work
        {
            return "A";
        }*/
        public override string ToString()
        {
            return "A";
        }

        public string test()
        {
            return "A";
        }
    }

    class B : A
    {
        /*public virtual string ToString()
        {
            return "B";
        }*/

        public override string ToString()
        {
            return "B";
        }

        public string test()
        {
            return "B";
        }
    }

    

}