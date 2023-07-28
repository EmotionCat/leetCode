using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        // string s = "PAYPALISHIRING";
        // int numRows = 4;
        // Console.WriteLine(!true&true);
        int[][] nums = new int[][]{new int[]{1, 2, 4, 3}, new int[]{5, 4, 6, 2}, new int[]{0, 1, 5, 2}};
        Console.WriteLine(solution.DeleteGreatestValue(nums));
        
    }
}