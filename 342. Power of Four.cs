//https://leetcode.com/problems/power-of-four/description

/*
Given an integer n, return true if it is a power of four. Otherwise, return false.

An integer n is a power of four, if there exists an integer x such that n == 4x.
*/
public class Solution {
    // must be positive, only one bit set, and that bit must be in an odd position
    public bool IsPowerOfFour(int n) {
        return n > 0
            && (n & (n - 1)) == 0          // power of two
            && (n & 0x55555555) != 0;      // bit in odd position → power of 4
    }
}
