internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] image = new int[][] {new int[]{1,1,1}, new int[]{1,1,0}, new int[]{1,0,1}};
        int sr = 1;
        int sc = 1;
        int color = 2;
        Console.WriteLine(solution.FloodFill(image, sr, sc, color));
    }
}