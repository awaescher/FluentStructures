# FluentStructures

This project provides a set of fluent APIs to simplify the handling of structs in .NET.

You wasted way to much of your lifetime doing `X1 + ((Width1 - Width2) / 2)` to center content.

## Use cases

### Moving points and rectangles

```csharp

//   (p1)───────────────────────────────(p2)
//                                       │
//                                       │
//                                       │
//                                       │
//                                       │
//                                      (p3)

// traditional
var p1 = new Point(10, 10);
var p2 = new Point(110, 10);
var p3 = new Point(110, 60);

// fluent
var p1 = new Point(10, 10);
var p2 = p1.WithX(100);       // absolute
var p3 = p2.AddY(50);         // relative

```

### Finding landmarks

```csharp

//    ┌──────────────────────────────────┐
//    │                                  │
//    │                                  │
//   (p1)                                │
//    │                                  │
//    │                                  │
//    └───────────────(p2)───────────────┘

// traditional
var p1 = new Point(rect.Left, rect.Top + (rect.Height / 2));
var p2 = new Point(rect.Right / 2, rect.Bottom);

// fluent
var p1 = rect.GetPoint(ContentAlignment.TopRight);
var p2 = rect.GetPoint(ContentAlignment.MiddleCenter);
```

### Aligning into rectangles

```csharp

//    ┌──────────────────────────────────┐
//    │                                  │
//    │              ┌────┐              │
//    │              │    │              │
//    │              └────┘              │
//    │                                  │
//    └──────────────────────────────────┘

var cellBounds = new Rectangle(100, 100, 300, 150);
var userImage = new Bitmap(30, 30);

// traditional
var rect = new Rectangle(
                cellBounds.X + ((cellBounds.Width - userImage.Width) / 2),
                cellBounds.Y + ((cellBounds.Height - userImage.Height) / 2),
                userImage.Width,
                userImage.Height);

// fluent
var rect = cellBounds.Align(userImage.Size, ContentAlignment.MiddleCenter);
```

--- 
[Model icons created by Flowicon on Flaticon](https://www.flaticon.com/free-icons/model)
