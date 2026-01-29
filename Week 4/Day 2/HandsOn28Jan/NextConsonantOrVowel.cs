using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string result = UserProgramCode.nextString(input);
        Console.WriteLine(result);
    }
}

class UserProgramCode
{
    public static string nextString(string input1)
    {
        StringBuilder result = new StringBuilder();
        string vowels = "aeiou";

        foreach (char ch in input1)
        {
            if (!char.IsLetter(ch))
                return "Invalid input";

            bool isUpper = char.IsUpper(ch);
            char c = char.ToLower(ch);

            if (vowels.Contains(c))
            {
                // Next consonant
                char next = (char)(c + 1);
                while (vowels.Contains(next))
                {
                    next++;
                }
                result.Append(isUpper ? char.ToUpper(next) : next);
            }
            else
            {
                // Next vowel
                char next = c;
                while (!vowels.Contains(next))
                {
                    next++;
                    if (next > 'z')
                        next = 'a';
                }
                result.Append(isUpper ? char.ToUpper(next) : next);
            }
        }

        return result.ToString();
    }
}
