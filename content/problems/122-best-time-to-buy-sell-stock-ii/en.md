Now you may buy and sell **as many times as you like** (but hold at most one share at a time).
Return the maximum total profit.

### Greedy — capture every rise

Any multi-day gain can be broken into consecutive day-to-day gains. So simply add up every positive
step: whenever `prices[i] > prices[i - 1]`, pocket the difference. This is equivalent to buying
before each rise and selling at its top.

You never lose by summing only the up-steps, and you can't do better than capturing all of them.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1).
