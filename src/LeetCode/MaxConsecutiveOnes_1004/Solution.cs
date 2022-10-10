using Xunit;

namespace MaxConsecutiveOnes_1004;

// Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

// Example 1:
// Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
// Output: 6
// Explanation: [1,1,1,0,0,1,1,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

// 	Example 2:
// Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
// Output: 10
// Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

public class Solution
{
	[Theory]
	[InlineData(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
	[InlineData(new[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3, 10)]
	public void Check(int[] input, int k, int excepted)
	{
		// Arrange.

		// Act.
		var result = LongestOnes(input, k);

		// Assert.
		Assert.Equal(excepted, result);
	}

	public int LongestOnes(int[] nums, int k)
	{
		int left = 0, right;

		for (right = 0; right < nums.Length; right++)
		{
			if (nums[right] == 0)
				k--;

			if (k >= 0) continue;
			k += 1 - nums[left];
			left++;
		}

		return right - left;
	}
}

// [1,1,1,0,0,0,1,1,1,1,0] k = 2;
