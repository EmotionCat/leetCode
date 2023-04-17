internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        string number = "29985893539178727148145992379911745134766237563959921352125461279593429746287123295957716729119144713";
        char digit = '3';
        Console.WriteLine(solution.RemoveDigit(number, digit));
    }
}