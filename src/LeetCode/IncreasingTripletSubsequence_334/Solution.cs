using Xunit;

namespace IncreasingTripletSubsequence_334;

// Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k].
// If no such indices exists, return false.

// Example 1:
// Input: nums = [1,2,3,4,5]
// Output: true
// Explanation: Any triplet where i < j < k is valid.

// Example 2:
// Input: nums = [5,4,3,2,1]
// Output: false
// Explanation: No triplet exists.

// Example 3:
// Input: nums = [2,1,5,0,4,6]
// Output: true
// Explanation: The triplet (3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4 < nums[5] == 6.

public class Solution
{
	[Theory]
	[InlineData(new[] { 1, 2, 3, 4, 5 }, true)]
	[InlineData(new[] { 5, 4, 3, 2, 1 }, false)]
	[InlineData(new[] { 2, 1, 5, 0, 4, 6 }, true)]
	public void Check(int[] input, bool excepted)
	{
		// Arrange.

		// Act.
		var result = IncreasingTriplet(input);

		// Assert.
		Assert.Equal(excepted, result);
	}

	public bool IncreasingTriplet(int[] nums)
	{
		var n = nums.Length;
		if (n < 3) return false;

		int i = int.MaxValue, j = int.MaxValue;

		for (int k = 0; k < n; k++)
		{
			if (nums[k] <= i)
				i = nums[k];
			else if (nums[k] <= j)
				j = nums[k];
			else
				return true;
		}

		return false;
	}
}