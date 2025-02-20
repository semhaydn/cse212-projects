public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Insert a value into the tree. Only unique values are allowed.
    /// </summary>
    public void Insert(int value)
    {
        // Only insert unique values.
        if (value == Data)
        {
            return; // Duplicate found; do nothing.
        }

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Determine if the tree contains a given value using recursion.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        else // value > Data
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    /// <summary>
    /// Get the height of the tree.
    /// The height is 1 plus the maximum height of the left or right subtree.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + System.Math.Max(leftHeight, rightHeight);
    }
}
