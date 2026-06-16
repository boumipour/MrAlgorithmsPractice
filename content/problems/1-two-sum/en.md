Find two indices in `nums` whose values sum to `target`. Each input has exactly one solution and
you may not reuse the same element twice.

### Brute force

The simplest idea: try every pair `(i, j)` with `j > i` and check `nums[i] + nums[j] == target`.
This is correct but costs **O(n²)** time — for an array of length 10 000 that is 50 million checks.

### Hash-map (one pass)

We can do this in a single pass with a `Dictionary<int, int>` that maps a value to its index.

For each element at position `i`:

1. Compute the **complement** we still need: `need = target - nums[i]`.
2. If `need` is already in the map, we found our pair — return `[map[need], i]`.
3. Otherwise store `nums[i] → i` and move on.

Because we check before inserting, we never accidentally match an element with itself.

### Why a Dictionary and not a HashSet?

A `HashSet<int>` only stores values; it cannot tell us the *index* of the complement. We need
`Dictionary<int, int>` (value → index) so we can return both positions.

### Complexity

| Approach | Time | Space |
| --- | --- | --- |
| Brute force | O(n²) | O(1) |
| Hash map | O(n) | O(n) |

### Explain it to a kid 🧒

Imagine you have a bag of numbered cards `[2, 7, 11, 15]` and you want two that add up to **9**.

**Slow way:** pick every pair and add them up — (2+7), (2+11), (2+15), (7+11) … that's a lot of
pairs.

**Fast way:** carry a sticky-note list. For each card you pick up, write down "I need **9 − this
card**" and check whether it is already on the list.
- Pick up **2**: I need 7. Not on the list yet. Write down "2 is at position 0".
- Pick up **7**: I need 2. **2 is on the list at position 0!** Done → return `[0, 1]`.
