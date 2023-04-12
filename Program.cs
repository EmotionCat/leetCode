internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] matrix = new int[][] {new int[]{1,2}, new int[]{2,2}};
        Console.WriteLine(solution.IsToeplitzMatrix(matrix));
    }
}