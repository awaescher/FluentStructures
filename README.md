# FluentStructures

This project provides a set of fluent APIs to simplify the handling of structs in .NET.

You spent too much time centering stuff with `X1 + ((Width1 - Width2) / 2)`.

## Use cases

### Setting properties with `With...`

The extensions methods `With...` and `WithAdditional...` provide expressive ways to get a copy of a struct with absolute values or relative value additions.

```csharp
//   (p1)───────────────────────────────(p2)
//                                       │
//                                       │
//                                       │   +50px
//                                       │
//                                       │
//                         (p4)─────────(p3)
//                               -33px

// traditional
var p1 = new Point(10, 10);
var p2 = new Point(100, p1.Y);
var p3 = new Point(p2.X, p2.Y + 50);
var p4 = new Point(p3.X - 33, p3.Y);

// fluent
p1 = new Point(10, 10);
p2 = p1.WithX(100);             // absolute
p3 = p2.WithAdditionalY(50);    // relative
p4 = p3.WithAdditionalX(-33);
```

### Emphasizing the intent over simple calculations

This project does not only add fluent extensions to set properties, it also comes with tailored extension methods to emphasize the intent when working with structs. Simple and expressive code instead of calculations that have to be thought through every time they get rediscovered.

The `Rectangle` (and `RectangleF`) gets an extension method to find its landmarks (corner stones or the center point) easily ...

```csharp
//    ┌──────────────────────────────────┐
//    │                                  │
//    │                                  │
//    │              (p1)                │
//    │                                  │
//    │                                  │
//    └──────────────(p2)────────────────┘


// traditional
var p1 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2));
var p2 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);

// fluent
p1 = rect.GetLandmark(ContentAlignment.MiddleCenter);
p2 = rect.GetLandmark(ContentAlignment.BottomCenter);
```

... while `Embed()` takes another rectangle or size to be embedded and returns the corresponding bounds depending on the defined alignment.

```csharp
//    ┌──────────────────────────────────┐
//    │                                  │
//    │                         ┌────┐   │
//    │                         │    │   │   <-- 10px padding
//    │                         └────┘   │
//    │                                  │
//    └──────────────────────────────────┘

var cellBounds = new Rectangle(100, 100, 300, 150);
var userImage = new Bitmap(30, 30);

// traditional
var userImageBounds = new Rectangle(
    cellBounds.Right - userImage.Width - 10,
    cellBounds.Y + ((cellBounds.Height - userImage.Height) / 2),
    userImage.Width,
    userImage.Height);

// fluent
userImageBounds = cellBounds
    .Embed(userImage.Size, ContentAlignment.MiddleRight)
    .WithAdditionalLeft(-10);
```

## Scope

This project currently adds extension methods to structs of the `System.Drawing` namespace like `Color`, `Point`, `Rectangle` and so on. More structs might be added over time, pull requests always welcome.

--- 
[Model icons created by Flowicon on Flaticon](https://www.flaticon.com/free-icons/model)
