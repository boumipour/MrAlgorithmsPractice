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

### Explain it to a kid 🧒

Let's play with a pile of plates, doing one action at a time:

1. **Push `1`** → pile is `[1]`, top = `1`.
2. **Push `2`** → pile is `[1, 2]`, top = `2`.
3. **Push `3`** → pile is `[1, 2, 3]`, top = `3`.
4. **Peek** → just *look* at the top → it's `3` (pile unchanged).
5. **Pop** → take the top off → returns `3`, pile is `[1, 2]`.
6. **Pop** → returns `2`, pile is `[1]`.

The last plate you put on is always the first one you take off. (And if the pile outgrows its shelf,
you swap in a shelf twice as big and keep stacking.)
