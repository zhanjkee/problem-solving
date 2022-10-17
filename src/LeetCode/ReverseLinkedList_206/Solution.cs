using System.Text;
using Xunit;

namespace ReverseLinkedList_206;

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
	public void Test1()
	{
		// Arrange.
		const string excepted = "54321";
		var head = new ListNode(1) {Next = new ListNode(2) { Next = new ListNode(3) { Next = new ListNode(4) { Next = new ListNode(5) } } } };

		// Act.
		var reversedList = Reverse(head);
		
		var sb = new StringBuilder();
		while (reversedList != null)
		{
			sb.Append(reversedList.Value);
			reversedList = reversedList.Next;
		}

		var actual = sb.ToString();
		
		// Assert.
		Assert.Equal(excepted, actual);
	}

	public ListNode? Reverse(ListNode? head)
	{
		if (head == null)
			return null;

		var current = head;
		ListNode? previous = null;

		while (current != null)
		{
			var nextNode = current.Next;
			current.Next = previous;
			previous = current;
			current = nextNode;
		}

		return previous;
	}
}