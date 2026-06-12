Same setup as Jump Game, but now you're guaranteed to reach the end — return the **minimum number of
jumps** to get there.

### Greedy "BFS by levels"

Think of the indices reachable with the same number of jumps as one *level*. We expand level by
level:

- `currentEnd` is the farthest index reachable with the jumps taken so far (the edge of the current
  level).
- `farthest` is the farthest index reachable by jumping from anywhere inside the current level.
- When the scan index `i` reaches `currentEnd`, we've exhausted the current level: we must take one
  more jump, so increment `jumps` and move the boundary out to `farthest`.

The loop stops at `nums.Length - 1` so we don't count an extra jump after already reaching the end.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1).

### Explain it to a kid 🧒

Same stones `[2, 3, 1, 1, 4]`, but now count the **fewest leaps** to the end.

1. You start on stone 0, which says `2` → your first leap can land on stone 1 or stone 2. So the edge
   of "what one leap reaches" is stone **2**.
2. Before you must leap again, peek at the stones you can land on: stone 1 says `3` → reaches stone
   `1 + 3 = 4`; stone 2 says `1` → reaches stone 3. The best is stone **4**.
3. Take leap #1. Now the edge is stone 4 — that's the end! That took leap #2 in the count.

Total: **2** leaps. You only spend a leap when you've run out of the ground your last leap unlocked.
