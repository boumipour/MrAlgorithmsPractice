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

### Explain it to a kid 🧒

Same prices `[7, 1, 5, 3, 6, 4]`, but now you can buy and sell as many times as you want. Walk day by
day and grab every step **up**.

1. `7 → 1`: price went down, do nothing.
2. `1 → 5`: up by `4` → buy at 1, sell at 5, pocket **4**.
3. `5 → 3`: down, do nothing.
4. `3 → 6`: up by `3` → pocket **3** more.
5. `6 → 4`: down, do nothing.

Add the wins: `4 + 3 = `**7** coins total.
