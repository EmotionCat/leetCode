internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] arr1 = new int[] {28,6,22,8,44,17};
        int[] arr2 = new int[] {22,28,8,6};
        Console.WriteLine(solution.RelativeSortArray(arr1, arr2));
    }
}