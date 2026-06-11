You start at index 0. Each `nums[i]` is the **maximum** jump length from that position. Return
whether you can reach the last index.

### Greedy intuition

Track the **farthest** index reachable so far. Walk left to right; at each index `i`, if `i` is still
within reach, update `farthest = max(farthest, i + nums[i])`. If you ever stand on an index that is
beyond `farthest`, there's a gap you can't cross, so return `false`.

If the loop finishes without hitting an unreachable index, the end is reachable.

### Why greedy works

You don't need to know *which* jumps to take — only whether the reachable frontier ever stalls
before the end. Keeping the single farthest value is enough.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1).
