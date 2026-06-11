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
