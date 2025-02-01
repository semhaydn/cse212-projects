public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
{
    if (_queue.Count == 0) // Verify the queue is not empty
    {
        throw new InvalidOperationException("The queue is empty.");
    }

    // Find the index of the item with the highest priority to remove
    int highPriorityIndex = 0;
    for (int index = 1; index < _queue.Count; index++)
    {
        // Only update if the current item has a strictly higher priority.
        // This way, if items have equal priority, the first (FIFO) is kept.
        if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
        {
            highPriorityIndex = index;
        }
    }

    // Retrieve the value of the highest priority item
    var value = _queue[highPriorityIndex].Value;
    // Remove that item from the queue
    _queue.RemoveAt(highPriorityIndex);
    return value;
}


    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}