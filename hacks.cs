                                                /* using directives */
using System;                                                
using System.Threading.Tasks;                                                
                                                /* Printing */

//Printing in Console without closing console
var helloWorld = "Hello World";
Console.WriteLine(helloWorld);
byte number = 255;
string firstName = "John";
Console.WriteLine("{0} {1}", number, firstName);
Console.WriteLine($"String interpolation {number} {firstName}"); //string interpolation for concat

                                                /* Numbers */
                                                
float f = 1.0f / 3;       // ~0.3333333 Fast calculations with less precision
double d = 1.0 / 3;       // ~0.333333333333333 precision matters but not to the level of financial accuracy
decimal m = 1.0M / 3;     // Financial and monetary calculations with high precision

                                                /* Vars/Const */

const float Pi = 3.14F;  //constant use Pascal Case
const int MaxZoom = 5;
decimal number = 1.2M;
byte number = 255;
string firstName = "John";
char character = 'a';

var myVar = 10;
var myStr = "test";


/********************************************************************
 *                               Strings                            *
 ********************************************************************/


var str = "";
var str = String.Empty; //usually when return expects a string
string? str;
if (!string.IsNullOrEmpty(str))
    Console.WriteLine("{0}", str);
if (string.IsNullOrWhiteSpace(line))
    Console.WriteLine("{0}", str);

//Perform operations on nullable strings
string? transactionType = myStr?.Trim();
string? upperStr = transactionType?.ToUpper();

var trimmed = str.Trim();
var replaced = helloWorld.Replace("Hello", "Hey");
var contains = helloWorld.Contains("Hello"); //true if it finds the substring
var length = helloWorld.Length;
var startsWith = helloWorld.StartsWith("Hell");
var endsWith = helloWorld.EndsWith("World");
int index = message.IndexOf("World");

// Split the line based on delimiters
string[] parts = line.Split(',');
public int WordCount() => str.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;

//using the == operator to test that two string values are equal
var product = "computer";
if(product == "computer")
    //do something
    
//using the 'is' operator
var product = "computer";
if(product is "computer")
    //do something

//string builder
StringBuilder builder = new();
builder.AppendLine("The following arguments are passed:");
Console.WriteLine(builder.ToString());


/********************************************************************
 *                               Type Conversion                    *
 ********************************************************************/


//Convert a string to an int
string s = "1";
int i = Convert.ToInt32(s);
bool b = Convert.ToBoolean(s);
int j = int.Parse(s);
long num = long.Parse(s);
long num = Convert.ToInt64(s);

//always better to use TryParse, which returns true/false in case the argument is not a valid number
var result = int.TryParse(s, out int number);
var result = double.TryParse(s, out double number);
int myInt = 5;
float myFloat = (float)myInt;

int i = (int)Pi;
byte b = (byte)MaxZoom;
var checkedVar = checked(Pi + number);



/********************************************************************
 *                             Classes & Objects                    *
 ********************************************************************/


var person = new Person()
                {
                    FirstName = "Ivan",
                    LastName = "Garzon",
                    Car = new MyCar()
                };

person.Pets.Add(new Cat("Johny"));
person.Pets.Add(new Cat("Liam"));

MyCar NewCar = new();
NewCar.Brand("Audi");

//Inline param obj instantiation
public void CallMethod(Person person) { };

CallMethod(new Person());
CallMethod(new Person() { FirstName = "Ivan", LastName = "Garzon" });

//using primary constructor (new in C# 12)
public class Person(string firstName, string lastName, MyCar car)
{
    public string First { set; } = firstName;
    public string LastName { set; } = lastName;
    public MyCar Car { set; } = car;
    public List<Pet> Pets { get; } = new(); //new in C# empty list

    public string Name    // Property
    {
        get => name;
        set => name = value;
    }

    public string Name { get; set; } //Auto-Implemented Property with get/set accessors
}

public class MyCar(){};

//In Abstract classes there's a strong "is-a" relationship
//Use an abstract class when derived classes are logically types of the base class.
//Cannot create instance of an abstract Pet
public abstract class Pet(string firstName)
{

    public string First { get; } = firstName;

    //Implemented
    public void Breathe() => Console.WriteLine("Breathing...");

    public virtual void BeFriendly() => Console.WriteLine("Jump and be frantic");

    //all derived classes MUST use the following method (not implemented here)
    public abstract string MakeNoise();
}

public class Cat(string firstName) : Pet(firstName)
{
    //here we override the base class method
    public override string MakeNoise() => "Meow";
}

public class Dog(string firstName) : Pet(firstName)
{
    //here we override the base class method
    public override string MakeNoise() => "Bark";

    public override void BeFriendly()
    {
        Console.WriteLine("I am a dog");
        base.BeFriendly();
    }
}

public class BaseClass
{
    public void DoWork() { WorkField++; }
    public int WorkField;
}

//Hiding base class members with new members
public class DerivedClass : BaseClass
{
    public new void DoWork() { WorkField++; }
    public new int WorkField;
}

//A derived class can stop virtual inheritance by declaring an override as sealed
public class C : B
{
    public sealed override void DoWork() { }
}

//Anonymous type
var v = new { Amount = 108, Message = "Hello" }; // Explicit member names.
Console.WriteLine(v.Amount + v.Message);

var personInferred = new { firstName, lastName }; // Projection initializers Inferred members

//Anonymous type mutations
var apple = new { Item = "apples", Price = 1.35 };
var onSale = apple with { Price = 0.79 };

//Temporarily Grouping Data with anonymous type
var grouped = list.GroupBy(x => new { x.Category, x.Type });

// returns a success code (0) from Main method
return 0;

// returns a exception code (1) from Main method
return 1;



/********************************************************************
 *                                Arrays                            *
 ********************************************************************/


int[] numArray = { 1903, 1907, 1910 }; //classic (implicit) array initialization (preferred collection expressions)
int[] numArray = [1903, 1907, 1910]; //Collection Expression Syntax

int[] numArray = new int[3]; //Arrays in C# are fixed-size

var length = numArray.Length;

//Use this when you need to pass the array to a method or property that expects new
int[] numArray = new int[]{1903, 1907, 1910};

string last = names[^1]; // ^1 is the last element

//slice arrays
int[] smallNumbers = numbers[0..5]; // elements from index 0 to 4

var slice = numbers[..3]; //Slice from beginning to index 3

var slice = numbers[2..]; //Slice from index 2 to end

var lastTwo = numbers[^2..]; //Use ^ to count from the end. Here last 2 elements

var copy = numbers[..]; // makes a shallow copy: 

var appendArray = [..numArray, 11, 12, 13];

//Copying an array to a new reference array, now these are 2 different object references
//use Clone() in older code or for compatibility reasons
var clonedArray = (int[])numArray.Clone();

//Doing the same with Array.Copy()
string[] copy = new string[numArray.Length];
Array.Copy(numArray, copy, numArray.Length);

//Using LINQ (creates a new array):
string[] copy = phoneNumbers.ToArray();

//Anonymous implicitely Typed array
var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };


/********************************************************************
 *                          Lists & Collections                     *
 ********************************************************************/


//Lists and arrays are indexable collections, but not all iterable (IEnumerable) types are.

var list1 = new List<string>();  // ✅ var with full type
List<string> list2 = new();          // ✅ target-typed new (C# 9.0+)
List<string> list3 = new List<string>(); // ✅ traditional style, not used a lot anymore.


var names = new List<string> { "Alice", "Bob", "Charlie", "David" };  //collection initializer syntax.
List<string> names = ["Alice", "Bob", "Charlie", "David"];  //(new) collection expressions C# 12+


List<string> names = new() { "A", "B", "C" };

Console.WriteLine($"My name is {names[0]}.");

names.Add("Gonzo");
names.Remove("Alice");
var countListItems = names.Count; //Count is a property for lists, different for Count() for iterable collections
names.Sort();

var index = names.IndexOf("Felipe"); //If the item isn't in the list, IndexOf returns -1.

// .. spread element to expand a collection
IEnumerable<int> moreNumbers = [.. numbers, 11, 12, 13];
IEnumerable<string> empty = [];                        
IEnumerable<int> evenNumbers = Enumerable.Range(1, 5).Where(n => n % 2 == 0);

//Convert a list to array
int[] numArray = numList.ToArray();

                                                            /* Loops & Sequences */

foreach (var number in numbers)
{
    //.. Do some action
}

foreach (var number in numbers[2..4])
{
    //.. Do some action
}


while (true)
{
    //Do something
}

do
{ //your code executes here
}
while (true);//condition here


//using a loop with a yield return statement
foreach (int number in GetNumbers())
{
    Console.WriteLine(number);
}

//iterator method
//returns a sequence of values one at a time, without needing to build and store the entire collection in memory
static IEnumerable<int> GetNumbers()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"Generating {i}");
        yield return i; //the values are produced lazily (lazy sequences)
    }
}


//await foreach
public static async IAsyncEnumerable<int> ReadSequence()
{
    foreach (var item in nextChunk)
    {
        yield return item; //return an iterator that provides access to each element when it's available
    }
}

await foreach (var number in ReadSequence())
   { Console.WriteLine(number); }



//Recursive algorithms (e.g., tree traversal)
IEnumerable<Node> Traverse(Node node)
{
    yield return node;
    foreach (var child in node.Children)
    {
        foreach (var descendant in Traverse(child))
        {
            yield return descendant;
        }
    }
}


                                                    /* Dates */

var myDate = new DateTime(1989, 5, 10);




/********************************************************************
 *                                Generics                          *
 ********************************************************************/



// Generic List
public class GenericList<T>
{
    public void Add(T value) { }
}

var numbers = new GenericList<int>();
var books = new GenericList<Book>();

// Generic Dictionary
public class GenericDictionary<TKey, TValue>
{
    public void Add(TKey key, TValue value){}
}

// Generic Method signature
public class MyClass
{
    public T Max<T>(T a, T b) where T : IComparable
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

//Applying a constraint to be of a specific interface (i.e. IComparable, but can be any other interface)
public class MyClass<T> where T : IComparable
{
    public T Max<T>(T a, T b) 
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

//Defaul value of generic T
var myDefault = default(T);

//Other constraints
public class MyClass<T> where T : Product { } // T is a Product or any of it's children
public class MyClass<T> where T : struct {} // T is a value type
public class MyClass<T> where T : class {} // T is a reference type
public class MyClass<T> where T : new() {} // T is an object with a default ctor
public class MyClass<T> where T  : IComparable, new() {} // using 2 constraints: T is a comparable object with a default ctor

//Boxing
int number = 42;
object box = number;  // Boxing happens here

//Unboxing
object box = 42;
int number = (int)box;  // Unboxing
int number = (T)box; //Using generics




                                                   /* Events & Delegates */

//Define a delegate method for the Subscribers (not needed anymore)
public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

//Define an event based on the delegate (not needed anymore)
public event VideoEncodedEventHandler VideoEncoded;

//.Net already has a defined a generic event handler delegate, so the 2 lines above are no longer necessary
public event EventHandler<VideoEventArgs> VideoEncoded;

//Raise the event
protected virtual void OnVideoEncoded(){}

//Subscribe to the event
publisher.VideoEncoded += subscriber.OnVideoEncoded;


                                                    /*  Automated Test */


                                                    /* Task based asynchronous */

public static async Task<int> GetPageLengthAsync(string endpoint)
{
    byte[] content = await client.GetByteArrayAsync(uri);
    return content.Length;
}




/********************************************************************
 *                                  LINQ                          *
 ********************************************************************/



List<int> scores = [97, 12, 34, 67];

//LINQ Query syntax
IEnumerable<string> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select $"The score is {score}";

//LINQ Method syntax
var scoreQuery = scores.Where(s => s > 80).OrderByDescending(s => s);

//Example to query all the even numbers
int[] numbers = { 1, 2, 3, 4, 5, 6 };
var evenNumbers = numbers.Where(n => n % 2 == 0);




/********************************************************************
 *                                  Tuples                          *
 ********************************************************************/



// Each element of a tuple has a type and an optional name. It is mutable.
var pt = (X: 1, Y: 2);
Console.WriteLine(pt.Y); // (1, 2)

//with expression to create a modified copy of the existing tuple
var pt2 = pt with { Y = 10 }; // (1, 10)

// Modern tuple
(string name, int age) person = ("Alice", 30);
Console.WriteLine($"{person.name} is {person.age} years old.");


//Returning multiple values from a method
(int sum, int product) Calculate(int a, int b)
{
    return (a + b, a * b);
}

//deconstructing a tuple
var (sum, product) = Calculate(5, 6);
(sum, int product) = Calculate(5, 6);

//first and second values are discards
(_, _, area) = city.GetCityInformation(cityName);
Console.WriteLine($"The city are is {area}");

//Quick grouping of values
var student = ("Bob", 25, "Math");
Console.WriteLine($"{student.Item1} studies {student.Item3}.");

//Linq projections
var names = new[] { "Alice", "Bob", "Charlie" };
var results = names.Select(n => (Original: n, Length: n.Length)).ToList();
Console.WriteLine(results[1]); //(Alice, 5)




/********************************************************************
 *                          Pattern matching                     *
 ********************************************************************/


//Null checks with "is expression" 
int? maybe = 12;

//declaration pattern
if (maybe is int number)
{
    Console.WriteLine($"The nullable int 'maybe' has the value {number}");
}


string? message = ReadMessageOrDefault();

if (message is null)
{
    Console.WriteLine("null object");
}

// not logical pattern 
if (message is not null)
{
    Console.WriteLine(message);
}

if (observation.Annotation is { })
{
    Console.WriteLine($"Observation description: {observation.Annotation}");
}

//The "switch expression"
string status = maybe switch
{
    int value => $"Has value: {value}",
    not string => "It's not a string",
    null => "No value",
    _ => "It's a string"
};

//switch with tuples
string quadrant = point switch
{
    (0, 0) => "Origin",
    (_, 0) => "X-Axis",
    (0, _) => "Y-Axis",
    _ => "Somewhere else"
};



/********************************************************************
 *                          Records types                           *
 ********************************************************************/



//Use a record for immutable data models (e.g., DTOs), pattern matching and deconstruction.
//A record is a reference type, with value-based equality semantics by default
public record Point(int X, int Y);

// You can add behavior to a record type by declaring members
public record Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

//A record struct is a struct type that includes the extra behavior added to all record types.
public record struct Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

var point1 = new Point(5,10);
Point point1 = new(5, 10);//object initializer syntax

//this should print New point : Point { X = 5, Y = 10 }
Console.WriteLine($" New point : {point1}");

var point2 = point1 with { }; //not changing anything, so this is a shallow clone with all the same values
var point2 = point1 with { X = 7 };

Console.WriteLine(point1 == point2); // output: True if type name and properties are equal

//switch objects at run time, to see if it's the specified type 
public record Deposit(double Amount, string description);
public record Withdrawal(double Amount, string description);

currentBalance += transaction switch
{
    Deposit d => d.Amount,
    Withdrawal w => -w.Amount,
    _ => 0.0,
};


//primary constructor parameters (init-only properties)
public record Person(string FirstName, string LastName)
{
    //init Makes the property settable only during object initialization
    //required Ensures that this property must be set during object creation
    public required string[] PhoneNumbers { get; init; }
}


                                                            /* File Processing */


//using yield it doesn't load the whole file into memory.
IEnumerable<string> ReadLines(string filePath)
{
    // using statement automatically free nonmemory resources
    using var reader = new StreamReader(filePath);
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        yield return line;
    }
}

//File I/O
string path = "example.txt";
File.WriteAllText(path, "This is a test file.");
string content = File.ReadAllText(path);


                                                                /* Enums */


public enum TransactionType {
    Deposit,
    Withdrawal,
    Invalid
}

public enum FileMode
{
    CreateNew = 1,
    Create = 2,
    Open = 3,
    OpenOrCreate = 4,
    Truncate = 5,
    Append = 6,
}

                                                            /* Math library */

Math.Max(a, b);


/********************************************************************
 *                                   Structs                        *
 ********************************************************************/


public struct Coords
{
    public int x, y;

    public Coords(int p1, int p2)
    {
        x = p1;
        y = p2;
    }
}
