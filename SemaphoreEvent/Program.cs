namespace SemaphoreEvent
{
    internal class Program
    {
        static Semaphore _semaphore=new Semaphore(2,2);
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
            Console.ReadKey();
        }
        static void Write()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is waiting");
            _semaphore.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} starts writing");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} completes writing");
            _semaphore.Release();
        }
    }
}