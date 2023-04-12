internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] image = new int[][] {new int[]{1,1,0,0}, new int[]{1,0,0,1}, new int[]{0,1,1,1}, new int[]{1,0,1,0}};
        Console.WriteLine(solution.FlipAndInvertImage(image));
    }
}