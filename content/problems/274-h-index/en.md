Each number in `citations` is how many times one paper was cited. The **h-index** is the largest
`h` such that at least `h` papers each have **at least** `h` citations.

### Sort and scan

Sort the citations in **descending** order. Walk the list: at position `i` (0-based) you are looking
at the `(i+1)`-th most-cited paper, so you already have `i + 1` papers with at least
`citations[i]` citations. While `citations[i] >= i + 1`, that count of papers (`i + 1`) is a valid
`h`, so keep raising `h`. The moment a paper has fewer citations than the papers counted so far, you
can stop — nothing later can do better.

### Improved performance — counting sort

Sorting costs O(n log n). We can do better because no `h` can ever exceed `n`, the number of papers.

- Cap every citation count at `n` and tally papers into `n + 1` buckets (`buckets[k]` = papers with
  exactly `k` citations, with everything `>= n` landing in `buckets[n]`).
- Sweep from the highest bucket down, accumulating a running `count` of papers with **at least** `i`
  citations. The first `i` where `count >= i` is the h-index.

This trades the comparison sort for linear bucketing, giving **O(n)** time.

### Complexity

| Approach | Time | Space |
| --- | --- | --- |
| Sort and scan | O(n log n) | O(1) |
| Counting sort | O(n) | O(n) |

### Explain it to a kid 🧒

You drew **5** pictures and counted the stickers each one got: `[3, 0, 6, 1, 5]`. Your "h-number" is
the biggest `h` where you have `h` pictures that each got `h` or more stickers. Let's find it the fast
way with buckets.

1. You have 5 pictures, so no h-number can be bigger than 5 → make **buckets 0 to 5** and put any
   picture with 5+ stickers into bucket 5. Counts become: bucket 0 → one picture, bucket 1 → one,
   bucket 3 → one, bucket 5 → **two** (the 6 and the 5).
2. Now count **down** from the biggest bucket, adding up pictures as you go:
   - Bucket 5: 2 pictures have ≥5 stickers. Is 2 ≥ 5? No.
   - Bucket 4: still 2 pictures have ≥4. Is 2 ≥ 4? No.
   - Bucket 3: now 3 pictures have ≥3 stickers. Is 3 ≥ 3? **Yes!**
3. Stop — your h-number is **3**: you really do have 3 pictures (the ones with 3, 5 and 6 stickers)
   that each got 3 or more.
