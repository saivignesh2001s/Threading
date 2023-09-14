namespace Lock
{
    internal class Program
    {
        private static object _locker=new object();
        static void Main(string[] args)
        {
            for(int i=0;i<5;i++)
            {
                new Thread(Write).Start();
            }
        }
        public static void Write()
        {
            lock (_locker)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");
            }

        }
    }
}