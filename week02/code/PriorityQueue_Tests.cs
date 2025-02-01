using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestPriorityQueue_BasicDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 20);
        priorityQueue.Enqueue("C", 15);
        
        // Expect "B" because it has the highest priority (20).
        Assert.AreEqual("B", priorityQueue.Dequeue());
        // Next, "C" (priority 15) should be returned.
        Assert.AreEqual("C", priorityQueue.Dequeue());
        // Finally, "A" (priority 10) is left.
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_TieBreakFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 10);
        
        // Since both have equal priority, "A" (enqueued first) should be dequeued first.
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}