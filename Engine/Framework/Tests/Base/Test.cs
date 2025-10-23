namespace Hybrid
{
    public abstract class Test
    {
        public static void Display(string name, bool passed)
        {
            Console.WriteLine($"{(passed ? "PASS" : "FAIL")} Name: {name}");
        }

        public abstract void Perform();
    }
}