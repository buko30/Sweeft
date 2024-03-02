using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    //     1
    public static bool checkPalindrome(string text)
    {
        char[] c = text.ToCharArray();
        Array.Reverse(c);
        return new string(c).Equals(text);
    }



    //     2
    public static int MinSplit(int amount)
    {
        int[] coins = [50, 20, 10, 5, 1];
        int counter = 0;
        foreach (int i in coins)
        {
            if (i > amount)
            {
                continue;
            }
            else
            {
                counter += amount / i;
                amount = amount % i;
            }
        }
        return counter;
    }


    //        3
    public static int NotContains(int[] array)
    {
        HashSet<int> noDuplicates = new HashSet<int>(array);
        int min = 1;
        while (noDuplicates.Contains(min))
        {
            min += 1;
        }
        return min;
    }



    //        4
    public static bool IsProperly(string sequence)
    {
        int counter = 0;
        foreach (char c in sequence)
        {
            if (c == '(')
            {
                counter++;
            }
            else if (c == ')')
            {
                counter--;
                if (counter < 0)
                {
                    return false;
                }
            }
        }
        return counter == 0;
    }

    public static int countCombinations(int n)
    {
        if (n <= 0)
        {
            return 1;
        }
        else if(n == 1)
        {
            return 1;
        }
        else if(n == 2)
        {
            return 2;
        }
        else
        {
            return countCombinations(n - 1) + countCombinations(n - 2);
        }
    }


    private static void Main(string[] args)
    {
 
        Console.WriteLine(countCombinations(6));
    }
}