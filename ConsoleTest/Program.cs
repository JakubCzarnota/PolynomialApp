using PolynomialCore;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input polynomial: ");

            string input = Console.ReadLine()!;
            
            Polynomial w1 = new Polynomial(input);

            w1.findRoots();


            Console.WriteLine("W(x)=" + w1);

            Console.WriteLine("Roots: ");


            foreach (var root in w1.Roots!)
            {
                Console.Write(root.Value.ToString("F5") + ", ");
            }

        }
    }
}
