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
