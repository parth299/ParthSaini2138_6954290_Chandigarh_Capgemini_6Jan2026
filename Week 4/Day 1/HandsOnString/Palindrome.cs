class Palindrome {
    public static bool IsPalindrome(string s)
    {
        s = s.ToLower();
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
}