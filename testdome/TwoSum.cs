namespace testdome;

/*
 * Write a function that, when passed a list and a target sum returns, (efficiently with respect to time used)
 * two distinct zero-based indices of any two of the numbers, whose sum is equal to the target sum.
 * If there are no two numbers the function should return null.
 * 
 * For example, FindTwoSum(new List<int>() {3, 1, 5, 7, 5, 9}, 10) should return a Tuple<int, int> 
 * containing any of the following pairs of indices.
 * 
 *  * 0 and 3 (or 3 and 0) as 3 + 7 = 10
 *  * 1 and 5 (or 5 and 1) as 1 + 9 = 10
 *  * 2 and 4 (or 5 and 2) as 5 + 5 = 10
 */

/*
 * Distinct numbers 
 * Duplicate numbers 
 * Performance test with a large list of numbers
 */

internal static class TwoSum
{
    public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
    {

        HashSet<int> set = new HashSet<int>(); //hashset to store unique values only

        for (int i = 0; i < list.Count; i++)
        {
            int diff = sum - list[i];

            if (set.Contains(diff))
            {
                Console.WriteLine($"[{i}, {list.IndexOf(diff)}]");
                return new Tuple<int, int>(i, list.IndexOf(diff));
            }
            set.Add(list[i]);
        }

        return null;
    }

    public static void FindTwoSum()
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}
