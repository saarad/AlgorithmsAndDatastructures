//https://leetcode.com/problems/product-of-the-last-k-numbers/description
/*
Design an algorithm that accepts a stream of integers and retrieves the product of the last k integers of the stream.

Implement the ProductOfNumbers class:

ProductOfNumbers() Initializes the object with an empty stream.
void add(int num) Appends the integer num to the stream.
int getProduct(int k) Returns the product of the last k numbers in the current list. You can assume that always the current list has at least k numbers.
The test cases are generated so that, at any time, the product of any contiguous sequence of numbers will fit into a single 32-bit integer without overflowing.
*/

//Keeping a dict of prefix sums - if k includes a zero product return 0
public class ProductOfNumbers {
    private readonly Dictionary<int, int> _stream;
    private int _cursor;
    private int _lastSeenZero;
    public ProductOfNumbers() {
        _stream = new();
        _cursor = 0;
        _lastSeenZero = -1;
    }
    
    public void Add(int num) {
        _cursor++;
        var currentProduct = num;
        if(_cursor > 1){
            var lastProduct = _stream[_cursor-1];
            if(lastProduct != 0){
                currentProduct *= lastProduct;
            }
        }
        
        if(currentProduct == 0){
                _lastSeenZero = _cursor;
        }

        _stream.Add(_cursor, currentProduct);
    }
    
    public int GetProduct(int k) {
        var lastProduct = _stream[_cursor];
        var limitCursor = _cursor-k;
        if(limitCursor < _lastSeenZero)
            return 0;
        if(limitCursor < 1)
            return lastProduct;
        
        var divident = _stream[limitCursor];
        if(divident == 0)
            return lastProduct;

        return lastProduct/divident;
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */
