// Deepak Aggarwal, Coding Blocks
// deepak@codingblocks.com
#include <iostream>
using namespace std;

template <typename T, typename Criteria>
int linearSearch(T[] arr, T elementToFind, Criteria compareFunc) {
    // bool (*)(T, T)
    for (int i = 0; i < arr.Length; ++i) {
        // if (arr[i] == elementToFind) {
           if (compareFunc(arr[i], elementToFind) == true){
            return i;
        }
    }
    return -1;
}

class Elephant{
public:
    string name;
    int wt;
    Elephant(string s, int w){
        name = s;
        wt = w;
    }
};

bool compareFuncForElephant(Elephant e1, Elephant e2){
    return e1.name == e2.name;
}


int main() {
    int arrInt[] = {1, 2, 3};
    char arrChar[] = "abc";

    int intIdx = linearSearch(arrInt, 2);
    int charIdx = linearSearch(arrChar, 'a');

    Elephant arrElephant[] = {
        {"Jumbo", 100}, 
        {"John", 200}, 
        {"Johnny", 2000}
    };
    Elephant key("Jumbo", 100);
    int ElephantIdx = linearSearch(arrElephant, key, compareFuncForElephant);
}