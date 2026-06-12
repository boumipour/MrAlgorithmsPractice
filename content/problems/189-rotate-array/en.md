Rotate the array to the right by `k` steps, in place.

### Normalize k first

Rotating by `n` returns the array to itself, so only `k % n` matters. After that, `k == 0` means
there's nothing to do.

### The triple-reverse trick

Rotating right by `k` is the same as:

1. Reverse the **whole** array.
2. Reverse the **first `k`** elements.
3. Reverse the **remaining `n − k`** elements.

Example with `[1,2,3,4,5,6,7]`, `k = 3`:

| step | result |
| --- | --- |
| reverse all | `7,6,5,4,3,2,1` |
| reverse first 3 | `5,6,7,4,3,2,1` |
| reverse last 4 | `5,6,7,1,2,3,4` |

This gives an in-place rotation with **O(1)** extra space, versus the simpler copy-into-a-temp-array
approach which costs O(n) space.

### Complexity

- **Time:** O(n) — each element is moved a constant number of times.
- **Space:** O(1).

### Explain it to a kid 🧒

Let's slide the cards `[1, 2, 3, 4, 5, 6, 7]` three spots to the right (`k = 3`), so the ones that
fall off the end wrap to the front. Do it with three flips:

1. **Flip the whole row** → `[7, 6, 5, 4, 3, 2, 1]`.
2. **Flip just the first 3 cards** (`7, 6, 5` → `5, 6, 7`) → `[5, 6, 7, 4, 3, 2, 1]`.
3. **Flip the last 4 cards** (`4, 3, 2, 1` → `1, 2, 3, 4`) → `[5, 6, 7, 1, 2, 3, 4]`.

And `[5, 6, 7, 1, 2, 3, 4]` is exactly the row shifted right by 3 — no extra table needed.
