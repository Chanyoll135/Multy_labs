class Program
{
    static void Main()
    {
        List<string[]> lines = new List<string[]>();
        lines.Add(new string[] { "Line 1", "Line 2", "Line 3" });
        lines.Add(new string[] { "Line A", "Line B", "Line C" });
        lines.Add(new string[] { "Line X", "Line Y", "Line Z" });
        lines.Add(new string[] { "Line !", "Line @", "Line #" });

        Parallel.ForEach(lines, (line) =>
        {
            foreach (string message in line)
            {
                Console.WriteLine(message);
                Thread.Sleep(100); // Имитация длительной работы
            }
        });
    }
}