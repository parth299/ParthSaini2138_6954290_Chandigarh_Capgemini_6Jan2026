class UserProgramCode {
    public static int getDonations(string[] arr, int num) {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach(string str in arr) {
            if(str.Contains("@") || str.Contains("!") || str.Contains("#") || str.Contains("$") || str.Contains("%") || str.Contains("^") || str.Contains("&") || str.Contains("*")) {
                return -2;
            }   
            else {  
                if(dict.ContainsKey(str)) {
                    return -1;
                }
                else {
                    dict[str] = 1;
                }
            }
        }

        int totalDonations = 0;
        foreach(string str in arr) {
            int toCompare = int.Parse(str.Substring(3, 3));
            if(toCompare == num) {
                totalDonations += int.Parse(str.Substring(6, 3));
            }
        }

        return totalDonations;
    }
}