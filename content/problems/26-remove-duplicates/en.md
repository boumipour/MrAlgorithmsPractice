Given an array sorted in non-decreasing order, remove the duplicates **in place** so that each
unique value appears only once, keeping the original relative order. Return the count `k` of unique
elements; the first `k` slots of the array must hold those values.

### Intuition

Because the array is already sorted, every group of equal values is contiguous. So a value is a
*new* unique value only when it differs from the previous unique one.

### Approach — two pointers

- `k` is a **write pointer** marking the last unique value placed at the front.
- `i` is a **read pointer** scanning the rest of the array.
- When `nums[i]` equals `nums[k]` it's a duplicate, so we skip it. Otherwise we advance `k` and copy
  the new value into `nums[k]`.

At the end the first `k + 1` positions hold the unique values, so we return `k + 1`.

### Complexity

- **Time:** O(n) — a single pass.
- **Space:** O(1) — done in place.
