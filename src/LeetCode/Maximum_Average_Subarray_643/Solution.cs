using System;
using Xunit;

namespace Maximum_Average_Subarray_643;

// You are given an integer array nums consisting of n elements, and an integer k.
// Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.
// Any answer with a calculation error less than 10-5 will be accepted.

// Example 1:
// Input: nums = [1,12,-5,-6,50,3], k = 4
// Output: 12.75000
// Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

// Example 2:
// Input: nums = [5], k = 1
// Output: 5.00000

public class Solution
{
	[Theory]
	[InlineData(new [] {1,12,-5,-6,50,3}, 4, 12.75000)]
	[InlineData(new []{5}, 1, 5.00000)]
	public void Check(int[] input, int k, double excepted)
	{
		// Arrange.
		
		// Act.
		var result = FindMaxAverage(input, k);
		
		// Assert.
		Assert.Equal(excepted, result);
	}

	public double FindMaxAverage(int[] nums, int k)
	{
		double sum = 0;

		for (int i = 0; i < k; i++)
			sum += nums[i];

		double result = sum;

		for (int i = k; i < nums.Length; i++)
		{
			sum += nums[i] - nums[i - k];
			result = Math.Max(sum, result);
		}

		return result / k;
	}
}