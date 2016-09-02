using System;

public class Frog
{
    public static Int64 NumberOfWays(int n)
    {
        // Maximum possible jumps (blue only) for one full traversal.
        int maxJumps = n / 2;

        // Count of combinations for red only traversal.
        long count = 1;

        // Add all possible combinations of jump-step 
        for (int jumps = 1; jumps <= maxJumps; jumps++)
        {
            // Remaining steps (red) for current jumps.
            int steps = n - 2 * jumps;

            // For any number of jumps, compute total combination of jump-steps
            checked
            {
                // Total ordered reds.
                Int64 s = factorial(steps);

                // Total ordered blues.
                Int64 j = factorial(jumps);

                // Total ordered combined.
                Int64 sj = factorial(steps + jumps);

                // Total combined red-blue for unordered red-blue. 
                count += sj / (s * j);
            }
        }
        
        return count;
    }

    /// <summary>
    /// Factorial grows rapidy causing overflow exxception to be thrown.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static Int64 factorial(int n)
    {
        checked
        {
            Int64 fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }

    public static void Main(String[] args)
    {
        try { 
            Console.WriteLine("Enter a number");
            string s = Console.ReadLine();
            Console.WriteLine("The answer is: " + NumberOfWays(int.Parse(s)));
        }
        catch(OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.Read();
        }
    }
}
