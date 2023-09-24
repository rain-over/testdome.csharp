namespace testdome;

/*
 * Implement function CountNumbers that accepts a sorted array of unique integers and (efficiently with respect to time used)
 * counts the number of array elements that are less than the parameter lessThan
 * 
 * For example, 
 * 
 * | SortedSearch.CountNumbers(new int[]{1,3,5,7},4) 
 * 
 * should return 2 because there are two array elements less than 4.
 */

/*
 * Various small arrays.
 * Performance test when sortedArray contains lessThan.
 * Performance test when sortedArray doesn't contain lessThan.
 */

internal class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        /*
         * 
         * 50% correct
           
            int index = Array.BinarySearch(sortedArray, lessThan);
            if (Array.BinarySearch(sortedArray, lessThan) < 0)
            {
                return sortedArray[..(Math.Abs(index) - 1)].Length;
            }
            return sortedArray[..index].Length;
        *
        */



        int left = 0, right = sortedArray.Length - 1, count = 0;
        // Console.WriteLine($"start");
        while (left <= right)
        {
            int mid = (left + right) / 2; // get middle index
            //Console.WriteLine($"left: {left}, right: {right}, mid: {mid}, current: {sortedArray[mid]}, target: {lessThan}");
            if (sortedArray[mid] < lessThan) // if mid[index] value less than 'lessThan' 
            {
                count = mid + 1; // set count to mid index + 1 (including index 0)
                left = mid + 1; // add 1 to get ceiling of divide (middle of array)
            }
            else
            {
                //right -= 1;
                right = mid - 1; // right to minus 1 of middle for sorted[mid] == lessThan values.
            }
        }
        return count;
    }

    public static void CountNumbers()
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 8, 9, 10, 12 }, 9));

        //int[] test1 = { 1001, 1002, 1004 };
        //int[] test = Enumerable.Range(1, 1000).ToArray();

        //Console.WriteLine(SortedSearch.CountNumbers(test.Union(test1).ToArray(), 1003));
    }
}
