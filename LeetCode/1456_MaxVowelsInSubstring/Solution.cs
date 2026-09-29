
public class Solution {
    public int MaxVowels(string s, int k) {
        
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        
        int currentVowels = 0;
        
        
        for (int i = 0; i < k; i++) {
            if (vowels.Contains(s[i])) {
                currentVowels++;
            }
        }
        
        int maxVowelsCount = currentVowels;
        
       
        for (int i = k; i < s.Length; i++) {
         
            if (vowels.Contains(s[i - k])) {
                currentVowels--;
            }
            
            
            if (vowels.Contains(s[i])) {
                currentVowels++;
            }
            
            
            if (currentVowels > maxVowelsCount) {
                maxVowelsCount = currentVowels;
            }
            
        
            if (maxVowelsCount == k) {
                return k;
            }
        }
        
        return maxVowelsCount;
    }
}