internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = new int[] {2,3,8,9,10};
        int target = 16;
        Console.WriteLine(solution.ThreeSumClosest(nums, target));
    }
}