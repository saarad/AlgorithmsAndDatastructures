//https://leetcode.com/problems/find-the-number-of-distinct-colors-among-the-balls/description
/*
You are given an integer limit and a 2D array queries of size n x 2.

There are limit + 1 balls with distinct labels in the range [0, limit]. Initially, all balls are uncolored. For every query in queries that is of the form [x, y], you mark ball x with the color y. After each query, you need to find the number of distinct colors among the balls.

Return an array result of length n, where result[i] denotes the number of distinct colors after ith query.

Note that when answering a query, lack of a color will not be considered as a color.
*/
public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        var seenColors = new Dictionary<int, int>();
        var seenBalls = new Dictionary<int, int>();

        var result = new int[queries.Length];
        var initialBall = queries[0][0];
        var initialColor = queries[0][1];
        seenBalls.Add(initialBall, initialColor);
        seenColors.Add(initialColor, 1);
        result[0] = 1;

        for(int i = 1; i<queries.Length; i++){
            var query = queries[i];
            var ball = query[0];
            var color = query[1];
            var queryResult = result[i-1];
            
            if(seenBalls.ContainsKey(ball)){ //ball has already been colored - remove old coloring and add new one
                var prevColor = seenBalls[ball];
                seenColors[prevColor]--;

                if(seenColors[prevColor] == 0){ //no balls have this color - remove from cache
                    queryResult--;
                    seenColors.Remove(prevColor);
                }

                seenBalls[ball] = color;
                if(seenColors.ContainsKey(color)){ //other balls have this color already
                    seenColors[color]++;
                }
                else{ //new color - add to cache
                    seenColors.Add(color, 1);
                    queryResult++;
                }
                result[i] = queryResult;
            }
            else{ //new ball
                seenBalls.Add(ball, color);
                if(seenColors.ContainsKey(color)){ //other balls have this color already
                    seenColors[color]++;
                }
                else{ //new color - add to cache
                    seenColors.Add(color, 1);
                    queryResult++;
                }

                result[i] = queryResult;
            }
        }


        return result;
    }
}
