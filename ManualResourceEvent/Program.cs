namespace ManualResourceEvent
{
    internal class Program
    {
        static ManualResetEvent _manual=new ManualResetEvent(false);
        static AutoResetEvent _auto=new AutoResetEvent(true);
        static void Main(string[] args)
        {
            Thread t2 = new Thread(Write);
            t2.Name = "Sai";
            t2.Start();
            for(int i=0;i<5;i++)
            {
               // new Thread(Read).Start();
               Thread t1=new Thread(Read);
                t1.Name =String.Concat("Thread -",i);
                t1.Start();
            }
            Console.ReadKey();
        }
        public static void Write()
        {
            
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} starts writing");
            _manual.Reset();
            string k = Thread.CurrentThread.Name+" is writing\n";
            File.AppendAllText("threadwriting.txt",k);
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} writing completed");
            _manual.Set();
        }
        public static void Read()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} waiting to Read");
            _manual.WaitOne();
            _auto.WaitOne();
            string[] lines=File.ReadAllLines("threadwriting.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reading completed");
            _auto.Set();
        }
    }
}