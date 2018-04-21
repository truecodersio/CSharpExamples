# Mark 3 Code Snippets

* [Abstract Class](#abstract-class)
* [Continue and Break](#continue-and-break)
* [Custom Get and Set](#custom-get-and-set)
* [Day 3 Example Code](#day-3-example-code)
* [Dictionaries](#dictionaries)
* [Exceptions, Ref, and Out](#exceptions--ref--and-out)
* [Extension Methods](#extension-methods)
* [Generics](#generics)
* [IEnumerable](#ienumerable)
* [Interfaces](#interfaces)
* [Iteration vs. Recursion](#iteration-vs-recursion)
* [Keyword: this](#keyword--this)
* [Lambdas](#lambdas)
* [LINQ](#linq)
* [Method Overloading](#method-overloading)
* [Modifier Keywords](#modifier-keywords)
* [Nested For Loop](#nested-for-loop)
* [Polymorphism](#polymorphism)
* [String Helper](#string-helper)
* [Try Parse](#try-parse)
* [xUnit Test Cases](#xunit-test-cases)

## Abstract Class

```csharp
public abstract class Animal
{
    public virtual string Name { get; set; }

    public abstract void SayName();
}

class Dog : Animal
{
    private string _name;

    public override string Name
    {
        get => _name;
        set => _name = string.IsNullOrEmpty(value) ? "Probably Fido" : value;
    }

    public override void SayName()
    {
        Console.WriteLine($"Hello my name is: {Name}");
    }
}
```

## Continue and Break

```csharp
// continue and break

for (var i = 0; i < 1000; i++)
{
    if (i % 2 != 0) { continue; }
    Console.WriteLine($"I even: {i}");
}

var emails = new[] { "a@truecoders.io", "b@me.com", "c@example.com", "d@google.com", "e@hotelmonkeys.biz" };

foreach (var email in emails)
{
    if (email == "c@example.com") { break; }
    Console.WriteLine($"This email: {email}");
}
```

## Custom Get and Set

```csharp
class Animal
{
    private string _name;

    public string Name
    {
        get => _name;
        private set => _name = string.IsNullOrEmpty(value) ? "Unknown" : value;
    }
}
```

## Day 3 Example Code

```csharp
using System;

namespace CSharpTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalNames = new[] { "Fido", "Spot", "Cujo", "Old Yeller" };

            foreach (var name in animalNames)
            {
                var dog = new Dog { Name = name };
                dog.SayName();
            }

            object testing = 468.36m;

            if (testing is string str)
            {
                Console.WriteLine($"We've found a string: {str}");
            }
            else if (testing is int num)
            {
                Console.WriteLine($"We've found a num: {num}");
                num *= 2;
            }
            else if (testing is bool isVal)
            {
                Console.WriteLine($"We've found a bool: {isVal}");
                isVal = !isVal;
            }
            else
            {
                Console.WriteLine($"I don't know what the hell this is: {testing}");
            }

            //Console.WriteLine($"The total number of animals is: {Animal.TotalCount}");
        }
    }

    enum AnimalVoice
    {
        Bark,
        Meow,
        Ribbit,
        Unknown
    }

    abstract class Animal
    {
        public static int TotalCount { get; private set; }

        public string Name { get; set; }
        public abstract AnimalVoice Voice { get; }

        public Animal()
        {
            TotalCount += 1;
        }

        public void SayName()
        {
            Console.WriteLine("My name is: " + Name);
        }
    }

    class Dog : Animal
    {
        public override AnimalVoice Voice => AnimalVoice.Bark;
    }

    class Cat : Animal
    {
        public override AnimalVoice Voice => AnimalVoice.Meow;
    }

    class Frog : Animal
    {
        public override AnimalVoice Voice => AnimalVoice.Ribbit;
    }
}
```

## Dictionaries

```csharp
var numNames = new Dictionary<int, string> {
    {7, "Jeff S."},
    {71, "Brandon D."},
    {2, "Chip E."},
    {100, "Francesca M."},
    {2000000000, "David C."},
    {86, "Chris F."},
    {27, "Trey D."},
    {4, "Steven B."},
    {17, "Skylar C."},
    {55, "Reid B."},
    {8, "Lisa B."},
    {5, "Cody W."},
    {0, "Daniel W."}
};

foreach (var data in numNames)
{
    Console.WriteLine($"{data.Key} {data.Value}");
}

string person = null;

do
{
    Console.WriteLine("Give us the number for the person you want");

    try
    {
        var favNum = int.Parse(Console.ReadLine());
        person = numNames[favNum];
    }
    catch (Exception)
    {
        Console.WriteLine("That's not a favorite number, you weirdo");
    }

} while (string.IsNullOrEmpty(person));

Console.WriteLine($"That number is the favorite of {person}");

Console.Read();
```

## Exceptions, Ref, and Out

```csharp
class Program
{
    static void Main(string[] args)
    {
        var refNum = 10;
        Console.WriteLine("Before i == " + refNum);

        TestingRef(ref refNum);
        Console.WriteLine("After Ref i == " + refNum);

        TestingOut(out var outNum);

        Console.WriteLine("After Out i == " + refNum);

        var firstStr = "123";

        if (int.TryParse(firstStr, out var firstR))
        {
            Console.WriteLine($"TryParse {firstStr} and got {firstR}");
        }


        var secondStr = "456";

        try
        {
            var secondR = Int32.Parse(secondStr);
            Console.WriteLine($"TryParse {secondStr} and got {secondR}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"We had an exception for {secondStr}: {ex}");
        }
    }

    static void TestingOut(out int i)
    {
        i = -2;
    }

    static void TestingRef(ref int i)
    {
        i *= 10;
    }
}
```

## Extension Methods

```csharp
public static class StringHelper
{
    public static bool IsValidEmail(this string email)
    {
        var isValid = email.Contains("@");
        return isValid;
    }
}
```

## Generics

```csharp
public class TestStack<T>
{
    public readonly int Size;
    private readonly List<T> items = new List<T>();

    public TestStack(int size)
    {
        Size = size;
    }

    public void Push(T item)
    {
        if (items.Count >= Size) { return; }
        items.Add(item);
    }

    public T Pop()
    {
        var i = items.Count - 1;
        var item = items[i];
        items.RemoveAt(i);
        return item;
    }

    public override string ToString()
    {
          return "[" + items.Select(n => $"{n}").Aggregate((e, s) => e + ", " + s) + "]";
    }
}
```

## IEnumerable

```csharp
IEnumerable<string> myCollection = new[] { "testing", "other" };

//IEnumerable<string> myCollection = new List<string> { "testing", "other" };

foreach (var item in myCollection)
{
    Console.WriteLine($"My item: {item}");
}
```

## Interfaces

```csharp
class Program
{
    static void Main(string[] args)
    {
        var car = new Car();
        var moto = new Motorcycle();

        car.Drive(70);
        moto.Drive(60, 5);

        var winner = Race(car, moto, 2);

        Console.WriteLine($"The winner is racing at {winner.GetCurrentSpeed()}");
    }

    public static IDriveable Race(IDriveable a, IDriveable b, double distance)
    {
        var aSpeed = a.GetCurrentSpeed() / distance;
        var bSpeed = b.GetCurrentSpeed() / distance;

        return aSpeed < bSpeed ? b : a;
    }
}

public interface IDriveable
{
    double GetCurrentSpeed();
    void Drive(double speed);
}

public interface IManualDriveable : IDriveable
{
    int GetCurrentGear();
    void Drive(double speed, int gear);
}

public class Car : IDriveable
{
    public const double MaxSpeed = 500.0;

    public double CurrentSpeed { get; private set; } = 0.0;
    public double GetCurrentSpeed() => CurrentSpeed;

    public void Drive(double speed = 15.0)
    {
        speed = speed < 0 ? 0 : speed;
        CurrentSpeed = (speed > MaxSpeed) ? MaxSpeed : speed;
    }
}

public class Motorcycle : IManualDriveable
{
    public const double MaxSpeed = 500.0;
    public const int NumberOfGears = 6;

    public double CurrentSpeed { get; private set; } = 0.0;
    public int CurrentGear { get; private set; } = 1;

    public double GetCurrentSpeed() => CurrentSpeed;
    public int GetCurrentGear() => CurrentGear;

    public void Drive(double speed = 15.0)
    {
        speed = speed < 0 ? 0 : speed;
        CurrentSpeed = (speed > MaxSpeed) ? MaxSpeed : speed;
    }

    public void Drive(double speed, int gear)
    {
        Drive(speed);

        gear = gear < 1 ? 1 : gear;
        CurrentGear = (gear > NumberOfGears) ? NumberOfGears : gear;
    }
}
```

## Iteration vs. Recursion

```csharp
class Program
{
    static void Main(string[] args)
    {
        var iName = AskQuestionIteration("What is your name?");

        var rName = AskQuestionRecursion("What is your name?");
    }

    static string AskQuestionIteration(string question)
    {
        while (true)
        {
            Console.WriteLine(question);
            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("You need to answer our question");
                continue;
            }

            return response;
        }
    }

    static string AskQuestionRecursion(string question)
    {
        Console.WriteLine(question);
        var response = Console.ReadLine();

        if (string.IsNullOrEmpty(response))
        {
            Console.WriteLine("You need to answer our question");
            return AskQuestionRecursion(question);
        }

        return response;
    }
}
```

## Keyword: this

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create a plain automobile

        var auto = new Automobile();
        Console.WriteLine($"Auto speed: {auto.CurrentSpeed}");

        // Tell the automobile to drive at 40
        auto.Drive(40.0);
        Console.WriteLine($"Auto speed: {auto.CurrentSpeed}");




        // Create a motorcycle

        var motorcycle = new Automobile();
        Console.WriteLine($"Motorcycle speed: {motorcycle.CurrentSpeed}");

        // Tell the motorcycle to drive at 70
        motorcycle.Drive(70.0);
        Console.WriteLine($"Motorcycle speed: {motorcycle.CurrentSpeed}");
    }
}

public class Automobile
{
    public const double MaxSpeed = 500.0;

    public double CurrentSpeed { get; private set; } = 0.0;

    public void Drive(double speed)
    {
        // Can be simplified to CurrentSpeed = speed;
        this.CurrentSpeed = speed;
    }
}
```

## Lambdas

```csharp
class Program
{
    static void Main(string[] args)
    {
        var test = Filter("Cody", "Claire", "Casey", "Ted", "Jessica", "Shelby", "Coby", "Laura", "Jason");
    }

    static IEnumerable<string> Filter(params string[] names)
    {
        var filteredNames = new List<string>();

        foreach (var name in names)
        {
            if (name.First() == 'C')
            {
                filteredNames.Add(name);
            }

            if (filteredNames.Count == 4)
            {
                return filteredNames;
            }
        }

        return filteredNames;
    }

    static IEnumerable<string> FilterWithLinq(params string[] names)
    {
        return names.Where(name => name.First() == 'C').OrderBy(n => n).Take(4);
    }
}
```

## LINQ

```csharp
static void Main(string[] args)
{
    var names = new[] {
        "Jeff S.",
        "Brandon D.",
        "Chip E.",
        "Francesca M.",
        "David C.",
        "Chris F.",
        "Trey D.",
        "Steven B.",
        "Skylar C.",
        "Reid B.",
        "Lisa B.",
        "Cody W.",
        "Daniel W."
    };

    var result = names
        .Where(s => s[0] == 'S')
        .Select(s => s.ToLower().Split(' ').First())
        .OrderByDescending(s => s);

    result = from name in names
        where name.First() == 'S'
        orderby name descending
        select name.ToLower().Split(' ').First();

    foreach (var name in result)
    {
        Console.WriteLine($"Name: {name}");
    }

    Console.Read();
}
```

## Method Overloading

```csharp
class Program
{
    static void Main(string[] args)
    {
        var auto = new Automobile();

        auto.Drive();
        auto.Drive(40.0);

        LogNames("Cody", "Winton");
    }

    static void LogNames(params string[] names)
    {
        foreach (var name in names)
        {
            Console.WriteLine($"Name is: {name}");
        }
    }
}

public class Automobile
{
    public const double MaxSpeed = 500.0;
    public const int NumberOfGears = 6;

    public double CurrentSpeed { get; private set; } = 0.0;
    public int CurrentGear { get; private set; } = 1;

    public static Automobile Race(Automobile a, Automobile b, double distance)
    {
        var aSpeed = a.CurrentSpeed / distance;
        var bSpeed = b.CurrentSpeed / distance;

        return aSpeed < bSpeed ? b : a;
    }

    public void Drive(double speed = 15.0)
    {
        Console.WriteLine("Called the speed method with speed: " + speed);

        speed = speed < 0 ? 0 : speed;
        CurrentSpeed = (speed > MaxSpeed) ? MaxSpeed : speed;
    }

    public void Drive(double speed, int gear)
    {
        Console.WriteLine("Called the gear method with gear: " + gear);

        Drive(speed);

        gear = gear < 1 ? 1 : gear;
        CurrentGear = (gear > NumberOfGears) ? NumberOfGears : gear;
    }
}
```

## Modifier Keywords

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create a plain automobile
        var auto1 = new Automobile();
        var auto2 = new Automobile();

        auto1.Drive(40);
        auto2.Drive(50);

        //var winner = Automobile.Race(auto1, auto2, 2);
        var winner = Automobile.Race(auto1, auto2, 2);
        Console.WriteLine($"Winner speed: {winner.CurrentSpeed}");
    }
}

public class Automobile
{
    public const double MaxSpeed = 500.0;

    public double CurrentSpeed { get; private set; } = 0.0;

    /// <summary>
    /// Race the specified autos for a set distance and return the winner
    /// </summary>
    /// <returns>The winner</returns>
    /// <param name="a">The first auto</param>
    /// <param name="b">The second auto</param>
    /// <param name="distance">The distance in miles</param>
    public static Automobile Race(Automobile a, Automobile b, double distance)
    {
        var aSpeed = a.CurrentSpeed / distance;
        var bSpeed = b.CurrentSpeed / distance;

        return aSpeed < bSpeed ? b : a;
    }

    public void Drive(double speed)
    {
        speed = speed < 0 ? 0 : speed;
        CurrentSpeed = (speed > MaxSpeed) ? MaxSpeed : speed;
    }
}
```

## Nested For Loop

```csharp
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        Console.WriteLine($"{i} : {j}");
    }
}
```

## Polymorphism

```csharp
class Program
{
    static void Main(string[] args)
    {
        string x = "Hi";
        int n = 100;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("X is: " + x);
        }
    }
}
```

## String Helper

```csharp
namespace CSharpExamples
{
    public static class StringHelper
    {
        public static bool IsValidEmail(this string email)
        {
            // start with empty value
            // return false;

            // then build tests and watch fail

            // then build code to pass your tests
            return email.Contains("@");
        }
    }
}
```

## Try Parse

```csharp
class Program
{
    static void Main(string[] args)
    {
        var myString = "123";
        int myNumber;

        var didSucceed = TryParse(myString, out myNumber);

        // Here myNumber == 123;
    }

    public static bool TryParse(string input, out int result)
    {
        try
        {
            result = Convert.ToInt32(input);
            return true;
        }
        catch
        {
            result = 0;
            return false;
        }
    }
}
```

## xUnit Test Cases

```csharp
using Xunit;
using CSharpExamples;

namespace CSharpExamples.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void EmptyStringIsInvalidEmail()
        {
            // Arrange
            var email = "";

            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ShouldSayHelloWorld()
        {
            // Arrange
            const string expected = "Hello World!";

            // Act
            var actual = Program.SayHello();

            // Assert
            Assert.Equal(expected, actual);
        }

        // Arrange
        [Theory]
        [InlineData("cwinton@truecoders.io")]
        [InlineData("dwalsh@truecoders.io")]
        [InlineData("me@example.com")]
        public void IsValidEmail(string email)
        {
            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.True(result);
        }

        // Arrange
        [Theory]
        [InlineData("cwinton")]
        [InlineData("dwalsh@s.i")]
        [InlineData("me@1.2")]
        public void IsInvalidEmail(string email)
        {
            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Hey!")]
        [InlineData("Test")]
        public void ShouldDoSomething(string str)
        {
            // Arrange
            const int expected = 4;

            // Act
            var actual = str.Length;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
```
