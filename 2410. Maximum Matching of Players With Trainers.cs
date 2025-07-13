/*
You are given a 0-indexed integer array players, where players[i] represents the ability of the ith player. You are also given a 0-indexed integer array trainers, where trainers[j] represents the training capacity of the jth trainer.

The ith player can match with the jth trainer if the player's ability is less than or equal to the trainer's training capacity. Additionally, the ith player can be matched with at most one trainer, and the jth trainer can be matched with at most one player.

Return the maximum number of matchings between players and trainers that satisfy these conditions.
*/

public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        return WithSort(players, trainers);
    }

    private int WithSort(int[] players, int[] trainers) {
        RadixSort16(players);
        RadixSort16(trainers);

        var player = 0;
        var trainer = 0;

        var matches = 0;
        while(player < players.Length && trainer < trainers.Length){
            if(players[player]<=trainers[trainer]){
                matches++;
                player++;
                trainer++;
            }
            else{
                trainer++;
            }
        }

        return matches;
    }

    private void RadixSort16(int[] a) {
        var n = a.Length;
        var buf = new int[n];
        const int B = 1 << 16;      // 65 536
        var count = new int[B];

        // sort by low 16 bits
        Array.Clear(count, 0, B);
        foreach (var x in a)
            count[x & 0xFFFF]++;
        for (int i = 1; i < B; i++)
            count[i] += count[i - 1];
        for (int i = n - 1; i >= 0; i--) {
            var x = a[i], b = x & 0xFFFF;
            buf[--count[b]] = x;
        }

        // sort by high 16 bits
        Array.Clear(count, 0, B);
        foreach (var x in buf)
            count[(x >> 16) & 0xFFFF]++;
        for (int i = 1; i < B; i++)
            count[i] += count[i - 1];
        for (int i = n - 1; i >= 0; i--) {
            int x = buf[i], b = (x >> 16) & 0xFFFF;
            a[--count[b]] = x;
        }
    }
}
