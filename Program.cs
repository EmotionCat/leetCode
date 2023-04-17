internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        string sequence = "aaabaaaabaaabaaaabaaaabaaaabaaaaba";
        string word = "aaaba";
        Console.WriteLine(solution.MaxRepeating(sequence, word));
    }
}