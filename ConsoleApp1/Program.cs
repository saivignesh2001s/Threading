namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Function1);
            Thread t2 = new Thread(Function2);
            //t1.IsBackground = true;
            t1.Start();
            t2.Start();

            Console.WriteLine("I am exited");
        }
        
        public static void Function1()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Execution from function 1 {i}");
                Thread.Sleep(4000);
            }


        }
        public static void Function2()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Execution from function 2 {i}");
                Thread.Sleep(4000);
            }
            

        }
    }
}