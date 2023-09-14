namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Function1);
            Thread t2 = new Thread(Function2);
           // t1.IsBackground = true;
           // t2.IsBackground = true;
            t1.Start();
            t2.Start();
            

            //Thread worker=new Thread(new ThreadStart(Function1));
            //worker.Start();
            Thread t;
            t=Thread.CurrentThread;
            Console.WriteLine(t.IsAlive);
            Thread.Sleep(10000);
            

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

            for (int i = 20; i > 10; i--)
            {
                Console.WriteLine($"Execution from function 2 {i}");
                Thread.Sleep(4000);
            }
            

        }
    }
}