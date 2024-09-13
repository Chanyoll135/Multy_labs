class MyThread
{
    public void Run() { }
}

public class Program
{
    static Thread parentThread = new Thread(Parent);
    static Thread childThread = new Thread(Child);

    // Мьютексы для синхронизации потоков
    static Mutex mutex1 = new Mutex();
    static Mutex mutex2 = new Mutex();

    static void Main(string[] args)
    {
        parentThread.Start();
    }

    private static void Parent()
    {
        while (true)
        {
            Console.WriteLine("Родительский поток");
            mutex1.WaitOne(); // Блокировка мьютекса 1 перед выполнением кода
            Thread.Sleep(100);
            childThread.Start();
            // Разблокировка мьютекса после выполнения кода
            mutex1.ReleaseMutex();
        }
    }

    // Дочерний поток
    private static void Child()
    {
        Console.WriteLine($"Дочерний поток");
        mutex2.WaitOne();
        Thread.Sleep(100);
        mutex1.ReleaseMutex();
    }
}
