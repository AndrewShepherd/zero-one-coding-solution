using System;
using System.Collections.Generic;

public class Program
{
	private static IEnumerable<string> GenerateTrialValues(int digit, List<string> l)
	{
		if (l.Count == 0)
		{
			if (digit != 0)
			{
				yield return digit.ToString();
			}
		}
		else
		{
			foreach (var s in l)
			{
				yield return digit.ToString() + s;
			}
		}
	}

	public static int FirstNonBinaryIndex(UInt64 b)
	{
		var s = b.ToString();
		for (int i = 0; i < s.Length; ++i)
		{
			char c = s[s.Length - 1 - i];
			if ((c != '0') && (c != '1'))
			{
				return i - 1;
			}
		}
		return s.Length;
	}

	public static void Main()
	{
		// Change this value to any number you want to test the algorithm against
		UInt64 input = 3456;

		List<string> candidates = new List<string>();
		for (int digitIndex = 0; digitIndex < 20; ++digitIndex)
		{
			List<string> newCandidates = new List<string>();
			for (int digit = 0; digit < 10; ++digit)
			{
				foreach (string value in GenerateTrialValues(digit, candidates))
				{
					UInt64 product = UInt64.Parse(value) * input;
					var i = FirstNonBinaryIndex(product);
					if (i == product.ToString().Length)
					{
						Console.WriteLine(string.Format("*** Found Result: {0:N0} * {1} = {2}", UInt64.Parse(value), input, product));
						Console.WriteLine("Press any key...");
						Console.ReadKey();
						return;
					}
					else if (i >= digitIndex)
					{
						newCandidates.Add(value);
					}
				}
			}
			candidates = newCandidates;
			Console.WriteLine(string.Format("Iteration {0}, {1} candidates", digitIndex, candidates.Count));
		}
	}
}