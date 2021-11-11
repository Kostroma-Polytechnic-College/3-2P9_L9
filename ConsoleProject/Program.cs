using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    class Owner
    {
        public int X;
        public Owner(int x)
        {
            X = x;
            Console.WriteLine($"Owner({x})");
        }
        public void Test(int x)
        {
            Console.WriteLine($"Owner.Test({x})");
        }
    }
    class Children : Owner
    {
        int y;
        public int Y
        {
            get
            {
                return (X % 2 == 0) ? X / 2 : 3 * X + 1;
            }
        }
        public Children(int x, int y)
            : base(x)
        {
            this.y = y;
            Console.WriteLine($"Children({y})");
        }

        public void Test(int x, int y)
        {
            base.Test(x);
            Console.WriteLine($"Children.Test({y})");
        }
    }

    

    class Program
    {
        static string KvUr(int a, int b, int c, out double d, out double x1, out double x2)
        {
            d = b * b - 4 * a * c;
            if (d < 0)
            {
                x1 = 0;
                x2 = 0;
                return "d<0, нет корней";
            }
            x1 = (-b + Math.Sqrt(d)) / 2 * a;
            if (d == 0)
            {
                x2 = x1; 
                return "d=0, 1 корень";
            }
            x2 = (-b - Math.Sqrt(d)) / 2 * a;
            return "d>0, 2 кореня";
        }
        static int F(int x)
        {
            return (x % 2 == 0) ? x / 2 : 3 * x + 1;
        }

        static int Inc(int x)
        {
            return ++x;
        }

        static int Inc(ref int x)
        {
            return ++x;
        }

        static void Ex(int x)
        {
            if (x < 0)
                throw new Exception("Запрещено использовать отрицательные значения");
        }

        static void Main(string[] args)
        {
            Children ch = new Children(1, 5);
            ch.Test(3, 4);
            double d, x1, x2;
            Console.WriteLine(
                $"{KvUr(-1,2,3, out d, out x1, out x2)} D={d}, x1={x1}, x2={x2}");
            int z = 2;
            Console.WriteLine($"{Inc(z)}, {z}");
            Console.WriteLine($"{Inc(ref z)}, {z}");
            try
            {
                Ex(-2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
            while (true)
            {
                int x = 5;
                while (!int.TryParse(Console.ReadLine(), out x)) ;

                do
                {
                    int y = F(x);
                    Console.WriteLine($"F({x})={y}");
                    x = y;
                } while (x != 1);

            }
        }
    }
}
