internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        string s = "PAYPALISHIRING";
        int numRows = 4;
        Console.WriteLine(solution.Convert(s, numRows));
    }
}