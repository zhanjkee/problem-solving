using Xunit;

namespace LinkedListCycle_141;

// Given head, the head of a linked list, determine if the linked list has a cycle in it.
// There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
// Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
// Return true if there is a cycle in the linked list. Otherwise, return false.

// Example 1:
// Input: head = [3,2,0,-4], pos = 1
// Output: true
// Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

// Example 2:
// Input: head = [1,2], pos = 0
// Output: true
// Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

// Example 3:
// Input: head = [1], pos = -1
// Output: false
// Explanation: There is no cycle in the linked list.

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
		var inlineDataList = new[]
		{
			new
			{
				Input = Example1(),
				Excepted = true
			},
			new
			{
				Input = Example2(),
				Excepted = true
			},
			new
			{
				Input = Example3(),
				Excepted = false
			}
		};
			
		foreach (var inlineData in inlineDataList)
		{
			// Act.
			var result = HasCycle(inlineData.Input);

			// Assert.
			Assert.Equal(inlineData.Excepted, result);
		}
	}

	public bool HasCycle(ListNode? head)
	{
		if (head == null)
			return false;

		var slow = head;
		var fast = head;

		while (fast != null && fast.Next != null)
		{
			slow = slow?.Next;
			fast = fast.Next.Next;
			if (slow == fast) return true;
		}

		return false;
	}

	private ListNode Example1()
	{
		var head = new ListNode(1);
		var second = new ListNode(2);
		var third = new ListNode(3);
		var fourth = new ListNode(4);
		head.Next = second;
		second.Next = third;
		third.Next = fourth;
		fourth.Next = second;

		return head;
	}
	
	private ListNode Example2()
	{
		var head = new ListNode(1);
		var second = new ListNode(2);
		head.Next = second;
		second.Next = head;

		return head;
	}

	private ListNode Example3()
	{
		return new ListNode(1);
	}
}