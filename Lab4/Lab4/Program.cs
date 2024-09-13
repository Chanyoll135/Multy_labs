class Program
{
    static void Main()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = cancellationTokenSource.Token;

        Task.Factory.StartNew(() => ChildThread(token), token);

        Thread.Sleep(2000); // Ждем две секунды

        cancellationTokenSource.Cancel(); // Отменяем задачу

        Console.ReadKey();
    }

    static void ChildThread(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Console.WriteLine("Дочерний поток печатает текст...");
            Thread.Sleep(1000);
        }
    }
}