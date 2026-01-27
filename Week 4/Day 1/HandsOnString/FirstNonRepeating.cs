class FirstNonRepeating {
    public static char? FirstNonRepeatingChar(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        foreach (char c in s)
        {
            if (freq[c] == 1)
                return c;
        }

        return null;
    }
}