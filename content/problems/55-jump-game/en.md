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

### Explain it to a kid 🧒

Let's cross the stones `[2, 3, 1, 1, 4]`, where each number is how many stones you may leap forward.
Keep one number: the **farthest** stone you can reach.

1. Stone 0 says `2` → from here you can reach stone `0 + 2 = 2`. Farthest = **2**.
2. Step to stone 1 (it says `3`) → you can reach `1 + 3 = 4`. Farthest = **4**.
3. Stone 4 is the last stone, and farthest is already 4 → you can reach the end. 🎉

(If the stones were `[3, 2, 1, 0, 4]`, farthest would get stuck at stone 3 and never reach 4 — that's
when the answer is "no, you can't make it.")
