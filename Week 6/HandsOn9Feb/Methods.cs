using System.Text;
using System.Text.RegularExpressions;

public class Solution {
    public static void InsertSingleCharacter(string s, char ch, int position) {
        Console.WriteLine("Original string: " + s);

        s = s.Insert(position, ch.ToString());
        Console.WriteLine("New string: " + s);
    }

    public static void DeleteAlternatingCharacters(string s) {
        var sb = new StringBuilder();
        Console.WriteLine("Before deleting alternate characters: " + s);

        for(int i=0; i<s.Length; i+=2) {
            sb.Append(s[i]);
        }

        string result = sb.ToString();
        Console.WriteLine("After deleteing alternate characters: " + result);
    }

    public static void MaximumDeletionsConsecutiveChars(string s) {
        //s = aabbcc;
        Stack<char> st = new Stack<char>();
        int count = 0;

        for(int i=0; i<s.Length; i++) {
            if(st.Count >= 1) {
                if(s[i] == st.Peek()) {
                    st.Pop();
                    count++;
                }
            }
            else {
                st.Push(s[i]);
            }
        }

        Console.WriteLine(
            "Count of the maximum deletions: " + count
        );
    }

    public static void SumOfDigits(int num) {
        int sum = 0;
        int temp = num;

        while(num > 0) {
            sum += num%10;
            num = num/10;
        }
        Console.WriteLine("Sum of digits of " + temp + " is " + sum);
    }

    public static void ClosedSquareRootNumber(int num) {
        // if num == 8 , its boundaries [4, 9]  -> closest is 9
        // if num == 18, its boundaries [16, 25] -> closest is 16

        if (num < 0)
            throw new ArgumentException("Negative numbers are not supported");

        int root = (int)Math.Sqrt(num);   

        int lowerSquare = root * root;
        int upperSquare = (root + 1) * (root + 1);

        if (num - lowerSquare <= upperSquare - num)
            Console.WriteLine("Closest square is " + lowerSquare);
        else
            Console.WriteLine("Closest square is " + upperSquare);
    }

    public static void CouplesInArray(int[] arr, int N) {
        int coupleSum = 0;
        int count = 0;
        for(int i=1; i<arr.Length; i++) {
            coupleSum = arr[i-1] + arr[i];
            if(coupleSum % N == 0) {
                count++;
            }
        }

        Console.WriteLine("Total couples in the array are : " + count);
    }

    public static void NeitherAnagramNorIdenticals(string[] strs) {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        List<string> result = new List<string>();

        foreach (var str in strs)
        {
            var key = new string(str.OrderBy(c => c).ToArray());

            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>();
            }

            dict[key].Add(str);
        }

        foreach(var p in dict) {
            if(p.Value.Count == 1) {
                result.Add(p.Value[0]);
            }
        }

        string[] ans = result.ToArray();
        Console.Write("Ans array is : ");
        foreach(var str in ans) {
            Console.Write(str + " ");
        }
        Console.WriteLine();
    }

    public static void LastOccurenceInString(string s, char toReplace, char replaced) {
        int index = 0;
        foreach(var ch in s) {
            if(ch == toReplace) {
                // replace that 
                // s = Regex.Replace(s, toReplace.ToString(), replaced.ToString(), 1);
                break;
            }
            index++;
        }

        Console.WriteLine("After replacing first occurence: " + s);
    }

    public static void FindScorePalindrome(string str) {
        int score = 0;
        // odd score;

        for(int i=0; i<str.Length; i++) {
            // expand
            int s = i-1, e = i+1;

            int currLength = 1;
            while(s >=0 && e<str.Length) {
                if(str[s] != str[e]) {
                    break;
                }
                s--; e++;
                currLength += 2;
            }

            if(currLength == 5) {
                Console.WriteLine("10 added ");
                score += 10;
            }
        }

        // even score
        for(int i=0; i<str.Length; i++) {
            int s=i, e=i+1;
            int currLength = 0;

            if(s>=0 && e<str.Length && str[s] == str[e]) {
                currLength += 2;
                s--; e++;
            }

            while(s>=0 && e<str.Length) {
                if(str[s] != str[e]) {
                    break;
                }
                s--; e++;
                currLength += 2;
            }



            if(currLength == 4) {
                Console.WriteLine("5 added");
                score += 5;
            }
        }
        Console.Write("Score is " + score);
    }
}