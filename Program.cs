internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] arr = {2,2,2,2};
        int m = 2;
        int k = 3;
        Console.WriteLine(solution.ContainsPattern(arr,m, k));
    }
}