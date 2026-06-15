namespace Algoritms.DataStructures;

/// <summary>
/// LeetCode 380 - Insert Delete GetRandom O(1).
/// Implement the RandomizedSet class:
///   - RandomizedSet() initializes the object.
///   - bool Insert(int val) inserts val into the set if not present. Returns true if it was not
///     present, false otherwise.
///   - bool Remove(int val) removes val from the set if present. Returns true if it was present,
///     false otherwise.
///   - int GetRandom() returns a random element from the current set. Each element must have the
///     same probability of being returned. It is guaranteed that at least one element exists when
///     GetRandom is called.
/// Every operation must run in average O(1) time.
///
/// Idea: keep a List for O(1) random access by index, and a Dictionary mapping value -> its index
/// in the List so Insert/Remove can be O(1). The trick for Remove is to avoid shifting the List:
/// swap the element being removed with the last element, fix the moved element's index in the map,
/// then pop the last slot.
///
/// Example:
///   Insert(1)   -> true   list=[1]
///   Remove(2)   -> false  (not present)
///   Insert(2)   -> true   list=[1,2]
///   GetRandom() -> 1 or 2 (uniformly random)
///   Remove(1)   -> true   list=[2]  (2 swapped into index 0)
///   Insert(2)   -> false  (already present)
///   GetRandom() -> 2
/// </summary>
public class RandomizedSet
{
    private Dictionary<int, int> map;   // value -> index of that value inside `list`
    private List<int> list;             // the actual elements, for O(1) random access
    private Random random;

    public RandomizedSet()
    {
        map = new Dictionary<int, int>();
        list = new List<int>();
        random = new Random();
    }

    /// <summary>Inserts val if absent. O(1). Returns false when val is already present.</summary>
    public bool Insert(int val)
    {
        if (map.ContainsKey(val))
            return false;

        list.Add(val);

        map[val] = list.Count - 1;

        return true;
    }

    /// <summary>
    /// Removes val if present. O(1). Instead of removing from the middle of the list (which would be
    /// O(n) because of shifting), we overwrite the slot with the list's last element and shrink.
    /// Returns false when val is not present.
    /// </summary>
    public bool Remove(int val)
    {
        if (!map.ContainsKey(val))
            return false;

        int index = map[val];

        int lastValue = list[list.Count - 1];

        // move last element to deleted position
        list[index] = lastValue;

        // update moved element index
        map[lastValue] = index;

        // remove last
        list.RemoveAt(list.Count - 1);

        // remove deleted value
        map.Remove(val);

        return true;
    }

    /// <summary>Returns a uniformly random element. O(1) via random index into the list.</summary>
    public int GetRandom()
    {
        int index = random.Next(list.Count);

        return list[index];
    }
}
