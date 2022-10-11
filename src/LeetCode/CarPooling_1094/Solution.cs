using System;
using Xunit;

namespace CarPooling_1094;

// There is a car with capacity empty seats. The vehicle only drives east (i.e., it cannot turn around and drive west).
// You are given the integer capacity and an array trips where trips[i] = [numPassengersi, fromi, toi] indicates that the
// ith trip has numPassengersi passengers and the locations to pick them up and drop them off are fromi and toi respectively.
// The locations are given as the number of kilometers due east from the car's initial location.
// Return true if it is possible to pick up and drop off all passengers for all the given trips, or false otherwise.

// Example 1:
// Input: trips = [[2,1,5],[3,3,7]], capacity = 4
// Output: false

// Example 2:
// Input: trips = [[2,1,5],[3,3,7]], capacity = 5
// Output: true

// A good method to solve this problem is to create an array arr which has a size equal to the largest value of right.
// In this case, it would be max(trip[2]) for all trip in trips. Then, iterate over input - for each value, in this case
// numPassengers, increment arr[left] (in this case arr[from]) by the value, and decrement arr[right] (in this case arr[to]) by the value.

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
				Input = new[]
				{
					new[] { 2, 1, 5 },
					new[] { 3, 3, 7 }
				},
				Capacity = 4,
				Excepted = false
			},
			new
			{
				Input = new[]
				{
					new[] { 2, 1, 5 },
					new[] { 3, 3, 7 }
				},
				Capacity = 5,
				Excepted = true
			},
		};

		foreach (var inlineData in inlineDataList)
		{
			// Act.
			var result = CarPooling(inlineData.Input, inlineData.Capacity);

			// Assert.
			Assert.Equal(inlineData.Excepted, result);
		}
	}

	public bool CarPooling(int[][] trips, int capacity)
	{
		int farthest = 0;
		for (int i = 0; i < trips.Length; i++)
			farthest = Math.Max(farthest, trips[i][2]);

		int[] arr = new int[farthest + 1];
		for (int i = 0; i < trips.Length; i++)
		{
			int value = trips[i][0], left = trips[i][1], right = trips[i][2];

			arr[left] += value;
			arr[right] -= value;
		}

		int curr = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			curr += arr[i];
			if (curr > capacity)
				return false;
		}

		return true;
	}
}