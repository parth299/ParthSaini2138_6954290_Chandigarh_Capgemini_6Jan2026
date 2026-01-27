class CountVowels {
    public static int Count(string s)
    {
        int count = 0;
        string vowels = "aeiouAEIOU";

        foreach (char c in s)
        {
            if (vowels.Contains(c))
                count++;
        }

        return count;
    }
}