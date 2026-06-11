Given an array `nums` and a value `val`, remove **all occurrences** of `val` in place and return the
number of remaining elements `k`. The order of the kept elements may change, and the first `k` slots
must contain them.

### Approach — two pointers

Keep a **write pointer** `k` that points to the next slot for a value we want to keep. Scan every
element with the read index `i`:

- If `nums[i] != val`, it should stay — copy it to `nums[k]` and advance `k`.
- If `nums[i] == val`, skip it (do not advance `k`).

Everything we keep is packed into the front of the array, and `k` is exactly how many we kept.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1) — in place.
