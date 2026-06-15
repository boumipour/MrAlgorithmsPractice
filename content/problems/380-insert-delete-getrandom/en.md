Design a set that supports **insert**, **remove**, and **getRandom**, each in *average* **O(1)** time.

```text
RandomizedSet() — initialize the set.
bool Insert(int val) — add val if absent; return true if it was added, false if already present.
bool Remove(int val) — delete val if present; return true if it was deleted, false if absent.
int  GetRandom()      — return a uniformly random element (each equally likely).
```

The catch is doing **all three** in O(1). Individually they pull in opposite directions:

- A **hash set** gives O(1) `Insert`/`Remove` but cannot pick a uniformly random element in O(1)
  (you can't index into a hash set).
- An **array / list** gives O(1) random access by index, but `Remove(val)` is normally O(n) because
  you have to find the value and then shift everything after it.

The solution uses **both together**:

- `List<int> list` — holds the elements so `GetRandom` can pick a random **index** in O(1).
- `Dictionary<int,int> map` — maps each **value → its index** inside `list`, so `Insert`/`Remove`
  can find any value in O(1).

### Insert

Check `map` for the value. If present, return `false`. Otherwise append to the end of `list` and
record its index (`list.Count - 1`) in `map`. Appending and a dictionary write are both O(1).

### Remove — the interesting part 🎯

We must delete from `list` *without* shifting the tail (shifting would be O(n)). The trick: the only
position in a list you can delete in O(1) is the **last** one. So we move the doomed element to the
end first, by **swapping it with the current last element**:

1. Look up `index = map[val]` — where the value currently sits in `list`.
2. Read `lastValue = list[^1]` — the element at the end of the list.
3. **Overwrite** the slot being removed with that last value: `list[index] = lastValue`. Now
   `lastValue` appears at `index`, and the value we want gone only exists at the very end.
4. **Fix the moved element's bookkeeping:** `map[lastValue] = index`, because `lastValue` lives at
   `index` now, not at the end.
5. **Pop the tail:** `list.RemoveAt(list.Count - 1)` — removing the last slot is O(1) (no shifting).
6. **Drop the value from the map:** `map.Remove(val)`.

Order matters: update `map[lastValue]` *before* (or independent of) removing `val` from the map, and
do the list overwrite before the `RemoveAt`. One subtle case that still works: when `val` **is** the
last element, `index` already points at the end — step 3 harmlessly writes the value back onto
itself, step 4 re-points it to the same index, and step 5 pops it. Correct either way.

### GetRandom

Pick `random.Next(list.Count)` and return `list[index]`. Because `list` is kept *gap-free* (Remove
always backfills the hole with the last element), every element occupies a valid index and each is
equally likely. O(1).

### Complexity

- **Insert / Remove / GetRandom:** average **O(1)** (amortized for the list's occasional growth).
- **Space:** O(n) — every element is stored once in the list and once as a key in the map.

### Explain it to a kid 🧒

Imagine numbered lockers in a row and a notebook that says which locker holds each toy.

- **Insert a toy:** put it in the next empty locker and write its locker number in the notebook.
- **Remove a toy:** instead of leaving an empty locker in the middle, you grab the toy from the
  **last** locker, drop it into the now-empty spot, update the notebook for that moved toy, and throw
  away the last (now empty) locker. No gaps, no sliding everything over.
- **Random toy:** roll a die for a locker number and open that locker. Since there are never any gaps,
  every toy has a fair chance.
