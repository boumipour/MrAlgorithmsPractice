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
