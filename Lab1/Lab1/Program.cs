class Program
{
    static void Main()
    {
        // Создаём новый Task для выполнения задачи в отдельном потоке
        var task = new Task(() => PrintLines(10));
        task.Start();

        // Основной поток продолжает свою работу
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Line {i} from main thread");
            Thread.Sleep(1000); // Задержка для имитации длительной работы
        }

        // Ожидаем завершения дочернего потока
        task.Wait();
    }

    static void PrintLines(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Line {i} from child thread");
            Thread.Sleep(1000); // Задержка для имитации длительной работы
        }
    }
}