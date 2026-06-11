A **stack** is a *last-in, first-out* (LIFO) collection: the most recently pushed item is the first
one popped. This is a from-scratch generic implementation backed by a growable array.

### Design

- An internal array `_stack` holds the items; `_top` is the index of the current top element
  (`-1` when empty).
- **Push** writes at `_top + 1`. If the array is full it first **doubles** capacity via `Resize`,
  giving amortized O(1) pushes.
- **Pop** / **Peek** read at `_top`, throwing `InvalidOperationException` when the stack is empty.
- **Count** is `_top + 1`; **Clear** just resets `_top` to `-1` (no need to wipe the array).

### Complexity

- **Push:** amortized O(1) (O(n) only on the occasional resize).
- **Pop / Peek / Count / IsEmpty:** O(1).
