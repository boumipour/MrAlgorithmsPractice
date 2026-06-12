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

### Explain it to a kid 🧒

Let's count the winner in `[2, 2, 1, 1, 1, 2, 2]`. Keep a **leader** and a **score** that starts at 0.

1. See `2`, score is 0 → make `2` the leader, score = 1.
2. See `2`, same as leader → score = 2.
3. See `1`, different → score = 1.
4. See `1`, different → score = 0.
5. See `1`, score is 0 → make `1` the leader, score = 1.
6. See `2`, different → score = 0.
7. See `2`, score is 0 → make `2` the leader, score = 1.

The leader left standing at the end is `2` — and indeed `2` shows up more than half the time. 🏆
