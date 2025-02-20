using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2.
    /// If n <= 0, return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations (of length 'size') from the string 'letters'
    /// into the results list.  Each letter is assumed to be unique.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // If the current word has reached the desired size, add it to the results.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // For each letter in the available letters, choose it and continue recursively.
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            // Remove the chosen letter from the remaining letters.
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb 's' stairs when you can take 1, 2, or 3 steps.
    /// Uses memoization to improve performance for larger values of s.
    /// Base cases: 1 stair = 1 way, 2 stairs = 2 ways, 3 stairs = 4 ways.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary if needed.
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases:
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Return memoized result if available.
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive calculation using the recurrence relation.
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        // Store in the dictionary.
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Given a binary pattern that may contain '*' as a wildcard,
    /// use recursion to generate all possible binary strings that match
    /// the pattern and insert them into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            // No wildcards left, so add the pattern as a complete string.
            results.Add(pattern);
            return;
        }

        // Replace the first occurrence of '*' with '0' and '1', and recursively solve.
        string pattern0 = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string pattern1 = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);
        WildcardBinary(pattern0, results);
        WildcardBinary(pattern1, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to find all paths through a maze from the starting
    /// position (0,0) to the end square (where Maze.IsEnd returns true).
    /// The maze is represented by a Maze object. The currPath list holds the
    /// current path (a list of (x,y) tuples). Use backtracking to explore
    /// all possible moves.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        // Initialize the current path on the first call.
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Add the current position to the path.
        currPath.Add((x, y));

        // If the current cell is the end, record the complete path.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Define possible movements: right, down, left, up.
        int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        // Try each possible move.
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack: remove the current position before returning.
        currPath.RemoveAt(currPath.Count - 1);
    }
}
