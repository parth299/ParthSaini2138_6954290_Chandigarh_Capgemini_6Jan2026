class Anagram {
    public static bool IsAnagram(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        char[] a1 = s1.ToCharArray();
        char[] a2 = s2.ToCharArray();

        Array.Sort(a1);
        Array.Sort(a2);

        return new string(a1) == new string(a2);
    }
}