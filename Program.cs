internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = {1,1,1,3,5};
        Console.WriteLine(solution.CountQuadruplets(nums));
    }
}