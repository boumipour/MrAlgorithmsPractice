You may buy on one day and sell on a **later** day — a single transaction. Return the maximum
profit, or `0` if no profit is possible.

### One pass

The best profit if you sell *today* is `today's price − the lowest price seen so far`. So scan once
while tracking:

- `minPrice` — the cheapest day seen up to now (the best day to have bought).
- `maxProfit` — the largest `price − minPrice` seen.

Each day, either it's a new minimum (update `minPrice`) or it could be a better sell day (update
`maxProfit`). The answer is whatever `maxProfit` ends at.

### Complexity

- **Time:** O(n) — one pass.
- **Space:** O(1).

### Explain it to a kid 🧒

Candy prices over the week are `[7, 1, 5, 3, 6, 4]`. You may buy **one** day and sell a **later** day.
Remember the **cheapest day so far** and the **best profit so far**.

1. Day price `7`: cheapest = 7, best = 0.
2. Day `1`: cheaper than 7 → cheapest = **1**.
3. Day `5`: buy at 1, sell at 5 → profit `4`. best = **4**.
4. Day `3`: 3 − 1 = 2, not better than 4. best stays 4.
5. Day `6`: 6 − 1 = 5, that's bigger → best = **5**.
6. Day `4`: 4 − 1 = 3, not better.

The biggest profit you could grab with one buy and one sell is **5**.
