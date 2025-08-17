//https://leetcode.com/problems/fruit-into-baskets/

/*
You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.

You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:

You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.
Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
Given the integer array fruits, return the maximum number of fruits you can pick.
*/

//Basically find the longest cont. subarray - new element introduced means empty out first basket 
public class Solution {
    public int TotalFruit(int[] fruits) {
        if (fruits.Length <= 2)
            return fruits.Length;

        //window size is 2
        var window = new HashSet<int>();
        var left = 0;

        window.Add(fruits[0]);
        var totalFruitsInWindow = window.Count;
        var maxSize = totalFruitsInWindow;

        int last = fruits[0];
        int lastBasketSize = 1; 

        for (int right = 1; right < fruits.Length; right++) {
            var fruit = fruits[right];

            if (window.Contains(fruit) || window.Count < 2) {
                window.Add(fruit);
                totalFruitsInWindow++;

                if (fruit == last){
                    lastBasketSize++;
                }
                else { 
                    last = fruit; 
                    lastBasketSize = 1; 
                }
            }
            else { // third fruit seen - slide window 
                maxSize = Math.Max(totalFruitsInWindow, maxSize);

                // keep the the previous basket + the current fruit
                totalFruitsInWindow = lastBasketSize + 1;
                left = right - 1;

                window.Clear();
                window.Add(fruits[left]);
                window.Add(fruit);        

                last = fruit;
                lastBasketSize = 1;
            }
        }

        return Math.Max(totalFruitsInWindow, maxSize);
    }

}

