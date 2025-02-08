//https://leetcode.com/problems/design-a-number-container-system/description
/*
Design a number container system that can do the following:

Insert or Replace a number at the given index in the system.
Return the smallest index for the given number in the system.
Implement the NumberContainers class:

NumberContainers() Initializes the number container system.
void change(int index, int number) Fills the container at index with the number. If there is already a number at that index, replace it.
int find(int number) Returns the smallest index for the given number, or -1 if there is no index that is filled by number in the system.
*/

public class NumberContainers {
    private readonly Dictionary<int, SortedSet<int>> _numbers;
    private readonly Dictionary<int, int> _indexes;

    public NumberContainers() {
        _numbers = new();
        _indexes = new();    
    }
    
    public void Change(int index, int number) {
        if(_indexes.ContainsKey(index)){ //index is already filled - remove index from old number and overwrite
            var oldNumber = _indexes[index];
            _numbers[oldNumber].Remove(index);

            if(_numbers[oldNumber].Count == 0){ //no indexes have this number - remove from cache
                _numbers.Remove(oldNumber);
            }

            _indexes[index] = number;
        }
        else{
            _indexes.Add(index, number);
        }

        if(_numbers.ContainsKey(number)){ //number already exists - add index
            _numbers[number].Add(index);
        }
        else{ //new number
            var numberIndexes = new SortedSet<int>();
            numberIndexes.Add(index);
            _numbers.Add(number, numberIndexes);
        }
    }
    
    public int Find(int number) {
        if(_numbers.TryGetValue(number, out var indexes)){
            return indexes.Min;
        }

        return -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */
