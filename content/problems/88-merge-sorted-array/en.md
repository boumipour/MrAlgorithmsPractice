`nums1` has `m` real values followed by `n` empty slots; `nums2` has `n` values. Both are sorted.
Merge them into `nums1`, sorted.

### This solution — copy then sort

Copy every element of `nums2` into the empty tail of `nums1`, then sort the whole array.

- **Time:** O((m + n) log(m + n)) from the sort.
- **Space:** O(1) extra (ignoring the sort's internals).

It's short and clearly correct — a fine first pass.

### The optimal alternative — merge from the back

Because the tail of `nums1` is free, you can place the **largest** remaining value at the end and
walk three pointers backward (one in each input, one at the write position). That avoids overwriting
unread data and runs in **O(m + n)** with no sort. Worth knowing for interviews even though the
simple version is implemented here.

### Complexity

- **Time:** O((m + n) log(m + n)) as written.
- **Space:** O(1).

### Explain it to a kid 🧒

Let's merge `nums1 = [1, 2, 3, _, _, _]` (three real kids, three empty spaces) with `nums2 = [2, 5,
6]`, both already short-to-tall. We fill the **empty back spaces** starting from the tallest.

1. Compare the tallest leftovers: `3` (from nums1) vs `6` (from nums2). `6` is taller → put `6` in
   the last empty spot → `[1, 2, 3, _, _, 6]`.
2. Compare `3` vs `5`. `5` is taller → `[1, 2, 3, _, 5, 6]`.
3. Compare `3` vs `2`. `3` is taller → `[1, 2, _, 3, 5, 6]`.
4. nums1 has `1, 2` left and nums2 has `2`. Compare `2` vs `2` → drop the `2` from nums2 →
   `[1, _, 2, 3, 5, 6]`, then `2` from nums1 → `[1, 2, 2, 3, 5, 6]`. Done!

Filling from the back means we never step on a kid we haven't looked at yet.
