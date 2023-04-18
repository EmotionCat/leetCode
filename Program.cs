internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] height = new int[] {1,8,6,2,5,4,8,3,7};
        Console.WriteLine(solution.MaxArea(height));
    }
}