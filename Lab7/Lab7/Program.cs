class PartA { }
class PartB { }
class Module
{
    public PartA partA { get; set; }
    public PartB partB { get; set; }
}
class PartC { }

public class ProductionLine
{
    static Semaphore semaphoreA = new Semaphore(0, 1); // Семафор для детали А
    static Semaphore semaphoreB = new Semaphore(0, 1); // Семафор для детали В
    static Semaphore semaphoreC = new Semaphore(0, 1); // Семафор для детали С
    static Semaphore semaphoreModule = new Semaphore(0, 5); // Семафор для модуля

    // Имитация задержки изготовления деталей
    private static void Delay(int seconds)
    {
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }

    static void Main(string[] args)
    {
        // Запуск производства
        new Thread(() => MakePartA()).Start();
        new Thread(() => MakePartB()).Start();
        new Thread(() => MakePartC()).Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(() => AssembleModule()).Start(); // Сборка модуля из деталей А и В
            semaphoreModule.Release(); // Освобождение семафора после сборки модуля
        }
    }

    private static void MakePartA()
    {
        semaphoreA.WaitOne();
        Delay(1);
        Console.WriteLine("Деталь А готова");
        semaphoreA.Release();
    }

    private static void MakePartB()
    {
        semaphoreB.WaitOne();
        Delay(2);
        Console.WriteLine("Деталь В готова");
        semaphoreB.Release();
    }

    private static void MakePartC()
    {
        semaphoreC.WaitOne();
        Delay(3);
        Console.WriteLine("Деталь С готова");
        semaphoreC.Release();
    }

    // Сборка модуля из деталей А и В
    private static void AssembleModule()
    {
        Module module = new Module();

        module.partA = new PartA();
        semaphoreA.WaitOne(); // Ожидание готовности детали А
        module.partB = new PartB();
        semaphoreB.WaitOne(); // Ожидание готовности детали В

        // Имитация сборки модуля
        Delay(1);

        Console.WriteLine($"Модуль собран из деталей {module.partA} и {module.partB}");

        semaphoreModule.Release(); // Освобождение семафора после сборки модуля
    }
}