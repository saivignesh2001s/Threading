namespace MonitorExample
{
    internal class Program
    {
        private static object _locker=new object();
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            
        }
        public static void Write()
        {
            try
            {
                Monitor.Enter(_locker);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");

            }
            catch
            {
               
            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
    }
}