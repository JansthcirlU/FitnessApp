# To-do's for back-end

## 1. Make back-end framework agnostic

Currently the domain objects have been implemented with the use of Entity Framework Core in mind. If the ORM changes, these implementations may result in unexpected bugs.

## 2. Use appropriate language features for domain modelling

.NET has introduced the `record` keyword for C# 9, records are immutable classes that implement value equality out of the box. This makes them an excellent candidate to represent DDD value objects.

### 2.1. Caveat surrounding records

The value equality is determined by checking property value equality using the default [`Equals(object? obj)`](https://learn.microsoft.com/en-us/dotnet/api/system.object.equals?view=net-7.0#system-object-equals(system-object)) method (see [this section](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record#value-equality) about record value equality). This means that if a `record` type contains a reference type property (with no custom equality implementation), it will simply check for property value reference equality.

```cs
public record SomeRecord(string Text, string[] TextArray);
```

When creating two identical `SomeRecord` instances, they may not be equal.

```cs
SomeRecord r1 = new("Some text", { "First", "Second", "Third" });
SomeRecord r2 = new("Some text", { "First", "Second", "Third" });
Console.WriteLine(r1 == r2); // False
```

This is due to the fact that even though they have equal `Text` property values, their respective `TextArray` values have different references. If both had used the same array, then they would have been equal.

```cs
string[] sharedArray = { "This", "array", "is", "shared" };
SomeRecord r3 = new("Test", sharedArray);
SomeRecord r4 = new("Test", sharedArray);
Console.WriteLine(r3 == r4); // True
```

Alternatively, if the `TextArray` property had been of a type that checked its contents than its object reference (similar to `string`), then the equality would also have evaluated to `True`.

## 3. Separate domain and application services

Currently, all the services are inside the `Core` folder, but are written like infrastructure services.