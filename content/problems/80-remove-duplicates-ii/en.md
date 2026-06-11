Like problem 26, but each unique value may now appear **at most twice**. Remove the extras in place
and return the new length `k`.

### Key idea

When the array is sorted, a value at index `i` is allowed only if it is different from the value
**two positions back** in the result we are building. If `nums[i] == nums[k - 1]` *and*
`nums[i] == nums[k - 2]`, then it would be the third copy — so we drop it.

### Approach

The loop starts at `i = 2` because the first two elements are always allowed. The write index
effectively tracks the result, and the check `nums[i] != nums[i - 2]` decides whether the current
value extends the result without creating a third duplicate.

> This generalizes nicely: to allow each value at most `m` times, compare against `nums[k - m]`.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1) — in place.
