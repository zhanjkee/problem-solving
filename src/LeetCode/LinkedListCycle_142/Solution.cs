using System;
using Xunit;

namespace LinkedListCycle_142;

public class ListNode
{
	public ListNode(int value)
	{
		Value = value;
	}

	public int Value { get; set; }
	public ListNode? Next { get; set; }
}

public class Solution
{
	[Fact]
	public void Check()
	{
		// Arrange.
		var head = GetCycledListNode(out var excepted);

		// Act.
		var result = DetectCycle(head);

		// Assert.
		Assert.Equal(excepted, result);
	}

	public ListNode? DetectCycle(ListNode? head)
	{
		if (head == null)
			return null;

		var intersect = GetIntersect(head);

		if (intersect == null)
			return null;

		var firstPointer = head;
		var secondPointer = intersect;

		while (firstPointer != secondPointer)
		{
			firstPointer = firstPointer?.Next;
			secondPointer = secondPointer?.Next;
		}

		return firstPointer;
	}

	private ListNode? GetIntersect(ListNode? head)
	{
		var fast = head;
		var slow = head;

		while (fast != null && fast.Next != null)
		{
			fast = fast.Next.Next;
			slow = slow?.Next;

			if (slow == fast) return slow;
		}

		return null;
	}

	private ListNode GetCycledListNode(out ListNode excepted)
	{
		var arr = new[] { 1, 2, 2, 2, 1 };
		Array.Sort(arr);
		var head = new ListNode(1);
		excepted = new ListNode(2);
		var third = new ListNode(3);
		var fourth = new ListNode(4);
		head.Next = excepted;
		excepted.Next = third;
		third.Next = fourth;
		fourth.Next = excepted;

		return head;
	}
}