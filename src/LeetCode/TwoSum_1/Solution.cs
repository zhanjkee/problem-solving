using System;
using System.Collections.Generic;
using Xunit;

namespace TwoSum_1;

// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// You can return the answer in any order.

// Example 1:
// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

// Example 2:
// Input: nums = [3,2,4], target = 6
// Output: [1,2]

// Example 3:
// Input: nums = [3,3], target = 6
// Output: [0,1]

public class Solution
{
	[Theory]
	[InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
	[InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
	[InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
	public void Check(int[] input, int target, int[] excepted)
	{
		// Arrange.
		
		// Act.
		var result = TwoSum(input, target);
		
		// Assert.
		Assert.Equal(excepted, result);
	}

	// Time complexity: O(n).
	// Space complexity: O(n).
	public int[] TwoSum(int[] nums, int target)
	{
		var dict = new Dictionary<int, int>();
		for (var i = 0; i < nums.Length; i++)
		{
			var complement = target - nums[i];
			if (dict.ContainsKey(complement))
				return new[] { dict[complement], i };

			dict.TryAdd(nums[i], i);
		}

		return Array.Empty<int>();
	}
}