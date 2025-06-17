//https://leetcode.com/problems/maximum-difference-by-remapping-a-digit/description/

/*
You are given an integer num. You know that Bob will sneakily remap one of the 10 possible digits (0 to 9) to another digit.
Return the difference between the maximum and minimum values Bob can make by remapping exactly one digit in num.
*/

//Wanted to try without string casting
public class Solution {
    public int MinMaxDifference(int num) {
        var max = -1;
        var min = -1;
        var mapMax = new Dictionary<int, int>();
        var mapMin = new Dictionary<int, int>();

        var count = (int)Math.Floor(Math.Log10(num)) + 1; //number of digits
        for(int i = 0; i<count; i++){
            var posFromRight = count - i - 1;
            var pow = (int)Math.Pow(10, posFromRight);
            var currentDigit = (num/pow) % 10;
            

            //max
            var currentMaxValue = num;
            if(mapMax.TryGetValue(currentDigit, out var changedMaxNum)) //digit has already been changed
            {
                currentMaxValue = changedMaxNum;
            }

            var newMaxValue = ChangeDigit(currentMaxValue, posFromRight, 9, currentDigit, pow, count);
            max = max == -1 ? newMaxValue : Math.Max(max, newMaxValue);
            if(mapMax.ContainsKey(currentDigit)){
                mapMax[currentDigit] = newMaxValue;
            }
            else{
                mapMax.Add(currentDigit, newMaxValue);
            }

            //min
            var currentMinValue = num;
            if(mapMin.TryGetValue(currentDigit, out var changedMinNum)) //digit has already been changed
            {
                currentMinValue = changedMinNum;
            }

            var newMinValue = ChangeDigit(currentMinValue, posFromRight, 0, currentDigit, pow, count);
            min = min == -1 ? newMinValue : Math.Min(min, newMinValue);
            if(mapMin.ContainsKey(currentDigit)){
                mapMin[currentDigit] = newMinValue;
            }
            else{
                mapMin.Add(currentDigit, newMinValue);
            }
        }

        return max-min;
    }

    private int ChangeDigit(int num, int posFromRight, int newNum, int currentDigit, int pow, int count){
        num -= currentDigit * pow;
        num += newNum * pow;

        return num;
    }
}
