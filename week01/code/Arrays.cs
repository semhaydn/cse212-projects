public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // 1) Create a new array of size 'length' to hold the multiples.
        // 2) Loop through each index (from 0 up to length - 1).
        // 3) For each index i, calculate the multiple of 'number' using (i + 1).
        //    - i=0 -> number * 1
        //    - i=1 -> number * 2
        //    - ...
        // 4) Store this value in the array at position i.
        // 5) Return the array after the loop is finished.

                // Implementation:
        double[] result = new double[length];  // Step 1

        for (int i = 0; i < length; i++)       // Step 2
        {
            result[i] = number * (i + 1);      // Step 3 & 4
        }

        return []; // TODO Problem 1 End
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
 // --- Step-by-Step Plan ---
    // 1) We want to move the last 'amount' of elements to the front.
    //    For example, if 'amount' = 3 and data is {1,2,3,4,5,6,7,8,9}, 
    //    then the last 3 elements {7,8,9} should move to the front, 
    //    resulting in {7,8,9,1,2,3,4,5,6}.

    // 2) Use GetRange to extract the slice of the list that we want 
    //    to move. The slice we want is from index: (data.Count - amount)
    //    and has a length of 'amount'.

    // 3) Remove those items from the end of the original list.

    // 4) Insert that slice at the front (index 0) of the original list.
     // --- Implementation ---
    // Step 2: Extract the slice (last 'amount' elements)
    List<int> slice = data.GetRange(data.Count - amount, amount);

    // Step 3: Remove that range from the end of 'data'
    data.RemoveRange(data.Count - amount, amount);

    // Step 4: Insert those elements at the front
    data.InsertRange(0, slice);

    // TODO Problem 2 End
    }
}
