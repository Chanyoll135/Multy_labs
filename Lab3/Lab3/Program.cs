class PiCalculator
{
    public static double CalculatePi(int count)
    {
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += 4 * Math.Pow(-1, i) / (2 * i + 1);
        }
        return sum;
    }
}
public class Program
{
    static Thread piCalculatorThread = new Thread(CalculatePi);

    static void Main(string[] args)
    {
        piCalculatorThread.Start();
    }

    private static void CalculatePi()
    {
        while (true)
        {
            Console.WriteLine("Введите количество итераций для расчёта:");
            int count = int.Parse(Console.ReadLine());
            double approximation = PiCalculator.CalculatePi(count);
            Console.WriteLine($"Приближение числа Пи после {count} итераций: {approximation}");
        }
    }
}
