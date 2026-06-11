Return the element that appears **more than ⌊n / 2⌋ times**. The problem guarantees such an element
exists.

### Boyer–Moore Voting

Keep a `candidate` and a `count`:

- When `count == 0`, adopt the current value as the new `candidate`.
- If the current value equals the candidate, `count++`; otherwise `count--`.

Each non-candidate value cancels out one candidate vote. Because the true majority occurs more than
half the time, it can never be fully cancelled — so it survives as the final `candidate`.

This beats the hash-map counting approach on space: **O(1)** instead of O(n).

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1).
