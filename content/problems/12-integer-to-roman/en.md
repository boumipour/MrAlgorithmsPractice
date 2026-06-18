Convert an integer (1 to 3999) into its roman numeral string. Roman numerals use seven symbols and a
subtraction rule: when a smaller symbol would normally repeat four times, a subtractive pair is used
instead.

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

### Digit lookup tables

Because a roman numeral never mixes symbols across "decades", each digit of `num` (thousands,
hundreds, tens, ones) can be converted independently with a fixed lookup table of 10 entries — one
per possible digit value 0-9. Concatenating the four lookups in order builds the final string.

```
1994
 thousands digit 1 → "M"
 hundreds  digit 9 → "CM"
 tens      digit 9 → "XC"
 ones      digit 4 → "IV"
 "M" + "CM" + "XC" + "IV" = "MCMXCIV"
```

### Greedy alternative

Walk a list of values from largest to smallest, including the six subtractive pairs (1000, 900, 500,
400, 100, 90, 50, 40, 10, 9, 5, 4, 1). For each value, append its symbol and subtract it from `num` as
many times as it still fits before moving to the next, smaller value.

```
1994
 1000 fits once  → "M",  num = 994
  900 fits once  → "CM", num = 94
   90 fits once  → "XC", num = 4
    4 fits once  → "IV", num = 0
 "MCMXCIV"
```

### Complexity

| Approach | Time | Space |
| --- | --- | --- |
| Digit lookup tables | O(1) | O(1) |
| Greedy | O(1) | O(1) |

Both run in constant time/space since `num` is bounded by 3999 — the lookup tables are fixed-size and
the greedy loop visits at most 13 values.

### Explain it to a kid 🧒

Imagine you have a box of stickers labeled M, D, C, L, X, V, I — each worth a different amount of
points. You want to spell out a number using as few stickers as possible.

One way: grab the **biggest** sticker that still fits under your number, stick it down, and subtract
its points. Keep grabbing the biggest sticker that fits until you hit zero — that's the greedy way.

The other way: split your number into "how many thousands, how many hundreds, how many tens, how many
ones" and look up the ready-made sticker combo for each piece from a cheat sheet — no subtracting
needed at all!
