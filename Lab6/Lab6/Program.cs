//Этот алгоритм работает за O(n) по времени, так как мы обрабатываем каждую строку только один раз и не производим никаких сравнений между строками.
class Program
{
    static void Main()
    {
        // Чтение строк из стандартного ввода
        var input = Console.ReadLine();
        var strings = input.Split(' ');

        // Подготовка к сортировке
        var lengths = new Dictionary<int, List<string>>();
        foreach (var stringValue in strings)
        {
            var length = stringValue.Length;
            if (!lengths.ContainsKey(length))
            {
                lengths[length] = new List<string>();
            }
            lengths[length].Add(stringValue);
        }

        // Сортировка строк по длине
        foreach (var lengthAndStrings in lengths)
        {
            foreach (var stringValue in lengthAndStrings.Value)
            {
                Console.WriteLine(stringValue);
            }
        }
    }
}