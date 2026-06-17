Convert a roman numeral string to its integer value. Roman numerals use seven symbols and a
subtraction rule: when a smaller symbol appears before a larger one, it is subtracted instead of added.

### Roman numeral symbols

| Symbol | Value |
| --- | --- |
| I | 1 |
| V | 5 |
| X | 10 |
| L | 50 |
| C | 100 |
| D | 500 |
| M | 1000 |

The six subtraction cases are: **IV** = 4, **IX** = 9, **XL** = 40, **XC** = 90, **CD** = 400, **CM** = 900.

### Single-pass approach

Walk the string left to right with a dictionary lookup:

- If the current symbol is **less than** the next symbol → it is part of a subtraction pair, so **subtract** it.
- Otherwise → **add** it.

```
"MCMXCIV"
 M  → next is C (1000 > 100)  → add    1000  → 1000
 C  → next is M (100 < 1000)  → subtract 100 →  900
 M  → next is X (1000 > 10)   → add    1000  → 1900
 X  → next is C (10 < 100)    → subtract 10  → 1890
 C  → next is I (100 > 1)     → add     100  → 1990
 I  → next is V (1 < 5)       → subtract  1  → 1989
 V  → no next                 → add       5  → 1994
```

### Complexity

| | Time | Space |
| --- | --- | --- |
| Single pass | O(n) | O(1) |

The dictionary has a fixed 7 entries, so space is effectively constant.

### Explain it to a kid 🧒

Imagine reading a price tag written in a secret code. Each letter has a price. You add up the prices
as you go — but there's one trick: if a cheaper letter comes **right before** a more expensive one,
you **take it away** instead of adding it.

So `IV` means "5 take away 1" = **4**, and `IX` means "10 take away 1" = **9**.
