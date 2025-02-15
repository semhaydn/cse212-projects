using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;    // Link the current tail to the new node.
            newNode.Prev = _tail;    // Set the new node's previous pointer.
            _tail = newNode;         // Update tail to point to the new node.
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail = _tail.Prev;
            if (_tail is not null)
                _tail.Next = null;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return; // Insert only once.
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        if (_head is null)
            return;
        
        // If head is the one to remove, call RemoveHead.
        if (_head.Data == value)
        {
            RemoveHead();
            return;
        }

        // Traverse starting from the second node.
        Node? curr = _head.Next;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it's the tail node, remove via RemoveTail.
                if (curr.Next is null)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Remove only the first occurrence.
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace them with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
                curr.Data = newValue;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list (forward iteration).
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate backward through the linked list.
    /// </summary>
    public IEnumerable Reverse()
    {
        Node? curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // For testing.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // For testing.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

// Extension method to support AsString calls on non-generic IEnumerable.
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        List<string> items = new List<string>();
        foreach (var item in array)
        {
            items.Add(item?.ToString());
        }
        return "<IEnumerable>{" + string.Join(", ", items) + "}";
    }
}
