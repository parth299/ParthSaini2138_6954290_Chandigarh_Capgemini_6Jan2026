class LongestSubstring {
    public static int longestSubstringWithoutRepeating(string s) {
        int l = 0;
        int e = 0;

        int longestLength = 0;

        Dictionary<char, int> lastIndex = new Dictionary<char, int>();   
        while(e<s.Length) {
            char ch = s[e];
            if(lastIndex.ContainsKey(ch)) {
                l = lastIndex[ch] + 1;
                lastIndex[ch] = e;
            }
            else {
                lastIndex[ch] = e;
            }

            e++;
            if(longestLength < e-l) {
                longestLength = e-l;
            }
        }

        return longestLength;
    }
}