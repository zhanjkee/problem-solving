using Xunit;

namespace NumberOfZeroFilledSubarrays_2348;

// Given an integer array nums, return the number of subarrays filled with 0.
// A subarray is a contiguous non-empty sequence of elements within an array.

// Example 1:
// Input: nums = [1,3,0,0,2,0,0,4]
// Output: 6
// Explanation: 
// There are 4 occurrences of [0] as a subarray.
// There are 2 occurrences of [0,0] as a subarray.
// There is no occurrence of a subarray with a size more than 2 filled with 0. Therefore, we return 6.

// Example 2:
// Input: nums = [0,0,0,2,0,0]
// Output: 9
// Explanation:
// There are 5 occurrences of [0] as a subarray.
// There are 3 occurrences of [0,0] as a subarray.
// There is 1 occurrence of [0,0,0] as a subarray.
// There is no occurrence of a subarray with a size more than 3 filled with 0. Therefore, we return 9.

// Example 3:
// Input: nums = [2,10,2019]
// Output: 0
// Explanation: There is no subarray filled with 0. Therefore, we return 0.

public class Solution
{
	[Theory]
	[InlineData(new[] { 1, 3, 0, 0, 2, 0, 0, 4 }, 6)]
	[InlineData(new[] { 0, 0, 0, 2, 0, 0 }, 9)]
	[InlineData(new[] { 2, 10, 2019 }, 0)]
	public void Check(int[] input, int excepted)
	{
		// Arrange.
		
		// Act.
		var result = ZeroFilledSubarray(input);
		
		// Assert.
		Assert.Equal(excepted, result);
	}

	// Time complexity: O(n).
	// Space complexity: O(1).
	public long ZeroFilledSubarray(int[] nums)
	{
		int ans = 0, subArray = 0;

		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] == 0)
				subArray++;
			else
				subArray = 0;

			ans += subArray;
		}

		return ans;
	}
}