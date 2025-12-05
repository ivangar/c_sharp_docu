#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS0219 // Variable is assigned but its value is never used

/* using directives */
using System;
using System.Globalization;
using System.Reflection;
using System.Net.Http.Json;
using System.Text;

/* Printing */

//Printing in Console without closing console
var helloWorld = "Hello World";
Console.WriteLine(helloWorld);
byte number = 255;
string firstName = "John";
Console.WriteLine("{0} {1}", number, firstName);
Console.WriteLine($"String interpolation {number} {firstName}"); //string interpolation for concat
Console.Error.WriteLine("Error Message"); //Log errors in console

//String Interpolation + Concatenation
Console.WriteLine(
    $"Congratulations {firstName}, " +
    $"you have created your first account with a balance of {number}. " +
    $"Your BankAccountId is .");





/********************************************************************
 *                               Numbers                            *
 ********************************************************************/


float f = 1.0f / 3;       // ~0.3333333 Fast calculations with less precision
double d = 1.0 / 3;       // ~0.333333333333333 precision matters but not to the level of financial accuracy
decimal m = 1.0M / 3;     // Financial and monetary calculations with high precision
int? age = null;
int actualAge = age ?? 18;

const float Pi = 3.14F;  //constant use Pascal Case
const int MaxZoom = 5;

decimal decimalNumber = 1.2M;
byte byteNumber = 255;
var myVar = 10;

//Generating random numbers
Random random = new();
int randomNumber = random.Next(100000, 999999); // 6-digit random ID

//Math library
Math.Max(5, 3);
Math.Pow(3, 2);
Math.Sqrt(2);
Math.Round(3.7);
double pi = Math.PI;


//format a decimal (or double) as currency with standard numeric format s-trings
decimal balance = 1234.56m;
Console.WriteLine(balance.ToString("C", CultureInfo.GetCultureInfo("en-CA")));
Console.WriteLine(balance.ToString("C", CultureInfo.CurrentCulture));





/********************************************************************
 *                               Strings                            *
 ********************************************************************/



char character = 'a';
string firstName2 = "John";
var emptyStr = "";
string? returnEmptyStr = String.Empty; //usually when return from method expects a string
string? nullString = null;

if (!string.IsNullOrEmpty(returnEmptyStr))
    Console.WriteLine("{0}", returnEmptyStr);
if (!string.IsNullOrWhiteSpace(nullString))
    Console.WriteLine("{0}", nullString);

//Perform operations on nullable strings
string? transactionType = returnEmptyStr?.Trim();
string? upperStr = transactionType?.ToUpper();

//null coalescing operator ??
//it means use value if it's not null, otherwise use defaultValue
string displayName = nullString ?? "Guest";

//Chaining Multiple Operators
//?? only checks for null, not for empty strings or other "falsy" values
string chainedCoalescing = nullString ?? returnEmptyStr ?? emptyStr ?? "Unknown";

var trimmed = firstName2.Trim();
var replaced = helloWorld.Replace("Hello", "Hey");
var contains = helloWorld.Contains("Hello"); //true if it finds the substring
var length = helloWorld.Length;
var startsWith = helloWorld.StartsWith("Hell");
var endsWith = helloWorld.EndsWith("World");
int index = helloWorld.IndexOf("World");

// Split the line based on delimiters
string[] parts = helloWorld.Split(',');
public int WordCount() => helloWorld.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;

//using the == operator to test that two string values are equal
var product = "computer";
if (product == "computer")
    { /*do something*/ }
    
    
//Case-insensitive comparison:
if (string.Equals(product, "Initial Balance", StringComparison.OrdinalIgnoreCase))
  { /*do something*/ }
if (product.Equals("Initial Balance", StringComparison.OrdinalIgnoreCase))
  { /*do something*/ }


//String Interpolation Format Specifiers
//$"{variable:format_specifier}";
decimal amount = 123.45m;
Console.Write($"{amount:C}");// Currency: $1,234.57
Console.Write($"{amount:C2}");// Currency with 2 decimals: $1,234.57
Console.Write($"{amount:N}");// Number with separators: 1,234.57
Console.Write($"{12345:#,0}");// will print 12,345

//using the 'is' operator
var computer = "computer";
if(computer is "computer")
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
long parsedNum = long.Parse(s);
long longNum = Convert.ToInt64(s);

//always better to use TryParse, which returns true/false in case the argument is not a valid number
var intParse = int.TryParse(s, out int _);
var doubleParsed = double.TryParse(s, out double _);
var uLongParsed = ulong.TryParse(s, out ulong _);

int myInt = 5;
float myFloat = (float)myInt;

int piCast = (int)Pi;
byte byteCast = (byte)MaxZoom;
var checkedVar = checked(Pi + number);





/********************************************************************
 *                             Classes & Objects                    *
 ********************************************************************/

/*
* Block-Scoped (Traditional) Namespace:         namespace Name { ... }
* File-Scoped Namespace Declaration (C# 10+)    namespace Name;   
* You can even use nested namespaces:           namespace MyApp.Services.Payments;                    
*/

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

CallMethod(new Person() { FirstName = "Ivan", LastName = "Garzon" });

//using primary constructor (new in C# 12)
public class Person(string firstName, string lastName, MyCar car)
{
    public string First { get;  set; } = firstName;
    public string LastName { get; set; } = lastName;
    public MyCar Car { get; set; } = car;
    public List<Pet> Pets { get; } = new(); //new in C# empty list

    string? name;
    
    public string Name    // Property
    {
        get => name;
        set => name = value;
    }

    public required string FullName { get; set; } //Auto-Implemented Property with get/set accessors

    //dynamically defining get accessor
    public decimal Amount
    {
        get
        {
            decimal sum = 0;
            foreach (var transaction in _transactions)
                sum += transaction.Amount;

            return sum;
        }
    }
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

    //Gets the Type Name of the current instance. For example, Cat derived class will print Cat.
    public override string ToString() => GetType().Name;
}

public class Cat(string firstName) : Pet(firstName)
{
    //here we override the base class method
    public override string MakeNoise() => "Meow";

    public int Age { get; set; }
}

public class Dog(string firstName) : Pet(firstName)
{
    //here we override the base class method
    public override string MakeNoise() => "Bark";

    public int Age { get; set; }
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

var myCat = new Cat("Johny");
var myDog = new Dog("Dugg");

//Determines whether the specified object is equal to the current object.
var objectsEqual = myCat.Equals(myDog);

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


//using Reflection lets you inspect a type's metadata to get information about that type
Type t = typeof(Pet);
MemberInfo[] members = t.GetMembers();




/********************************************************************
 *                                Arrays                            *
 ********************************************************************/


int[] numbers = { 1, 2, 3, 4, 5, 6 }; //classic (implicit) array initialization (preferred collection expressions)
int[] numArray2 = [1903, 1907, 1910]; //Collection Expression Syntax

int[] numArray3 = new int[3]; //Arrays in C# are fixed-size

var length2 = numArray3.Length;

//Use this when you need to pass the array to a method or property that expects new
var numArray4 = new int[]{1903, 1907, 1910};

int last = numbers[^1]; // ^1 is the last element (in this case 6)

//slice arrays
int[] smallNumbers = numbers[0..5]; // elements from index 0 to 4

var slice = numbers[..3]; //Slice from beginning to index 3

var customSlice = numbers[2..]; //Slice from index 2 to end

var lastTwo = numbers[^2..]; //Use ^ to count from the end. Here last 2 elements

var copy = numbers[..]; // makes a shallow copy: 

//The spread element, ..e in a collection expression adds all the elements in that expression
int[] appendArray = [.. numbers, 11, 12, 13];

//Copying an array to a new reference array, now these are 2 different object references
//use Clone() in older code or for compatibility reasons
var clonedArray = (int[])numArray.Clone();

//Doing the same with Array.Copy()
string[] copy1 = new string[numArray.Length];
Array.Copy(numArray, copy1, numArray.Length);

//Using LINQ (creates a new array):
int[] copy2 = numArray2.ToArray();

//Anonymous implicitely Typed array
var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };

// Create a jagged 2D array:
int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];





/********************************************************************
 *                          Lists & Collections                     *
 ********************************************************************/


//Lists and arrays are indexable collections, but not all iterable (IEnumerable) types are.

var list1 = new List<string>();  // ✅ var with full type
List<string> list2 = new();          // ✅ target-typed new (C# 9.0+)
List<string> list3 = new List<string>(); // ✅ traditional style, not used a lot anymore.
List<string> nullItems = null;

List<int> emptyArray = []; //declaring an empty array of string (C# 12+)
IEnumerable<string> emptyList = Enumerable.Empty<string>();

var names = new List<string> { "Alice", "Bob", "Charlie", "David" };  //collection initializer syntax.
List<string> collectionExpression = ["Alice", "Bob", "Charlie", "David"];  //(new) collection expressions C# 12+
List<string> letters = new() { "A", "B", "C" };

Console.WriteLine($"My name is {names[0]}.");

//Null Coalescing Assignment Operator (??=)
nullItems ??= new List<string>();  // Initialize only if null

names.Add("Gonzo");
names.Remove("Alice");
names.AddRange(["John", "Sylvia", "Denis"]);

var countListItems = names.Count; //Count is a property for lists, different for Count() for iterable collections
names.Sort();

var index = names.IndexOf("Felipe"); //If the item isn't in the list, IndexOf returns -1.

// .. spread element to expand a collection
IEnumerable<int> moreNumbers = [.. numbers, 11, 12, 13];
IEnumerable<string> empty = [];                        
IEnumerable<int> evenNumbers = Enumerable.Range(1, 5).Where(n => n % 2 == 0);

//get the sequence iterator that can move through the collection one element at a time
var firstIterator = evenNumbers.GetEnumerator();

//Advances the iterator to the next element
bool moveTrueOrFalse = firstIterator.MoveNext();

//Gets the element at the current position of the iterator.
var currentElement = firstIterator.Current;


//Convert a list to array
int[] numArray = evenNumbers.ToArray();

//Spans
Span<char> c = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];







/********************************************************************
 *                    Dictionaries <TKey, TValue>                   *
 ********************************************************************/


// Empty dictionary
Dictionary<string, int> ages = new Dictionary<string, int>();

// With initial capacity
Dictionary<string, int> ages = new Dictionary<string, int>(100);

// Collection initializer
Dictionary<string, int> ages = new Dictionary<string, int>
{
    { "Alice", 25 },
    { "Bob", 30 },
    { "Charlie", 35 }
};

// Modern syntax (C# 9+)
Dictionary<string, int> ages = new()
{
    { "Alice", 25 },
    { "Bob", 30 },
    { "Charlie", 35 }
};

// Index initializer (C# 6+)
Dictionary<string, int> ages = new Dictionary<string, int>
{
    ["Alice"] = 25,
    ["Bob"] = 30,
    ["Charlie"] = 35,
    ["David"] = 20
};

// From other collections
var list = new List<Person> { ... };
var dict = list.ToDictionary(p => p.Id, p => p.Name);


Dictionary<string, int> ages = new Dictionary<string, int>();

// Add method - throws exception if key exists
ages.Add("Alice", 25);
ages.Add("Bob", 30);

// Index operator - overwrites if key exists
ages["Charlie"] = 35;
ages["Alice"] = 26;  // Updates Alice's age

// TryAdd - returns false if key exists (C# 7.0+)
bool added = ages.TryAdd("David", 40);  // true
bool failed = ages.TryAdd("Alice", 27);  // false, doesn't add

// Add multiple items
foreach (var person in people)
{
    ages[person.Name] = person.Age;
}

// Index operator - throws exception if key doesn't exist
int aliceAge = ages["Alice"];  // 25
int eveAge = ages["Eve"];      // KeyNotFoundException!

// TryGetValue - safe way to get values
if (ages.TryGetValue("Alice", out int age))
{
    Console.WriteLine($"Alice is {age}");  // Alice is 25
}
else
{
    Console.WriteLine("Alice not found");
}

// Check if key exists first
if (ages.ContainsKey("Bob"))
{
    int bobAge = ages["Bob"];
}

// Get value or default
int charlieAge = ages.GetValueOrDefault("Charlie", 0);  // Returns 0 if not found

// Update using index operator
ages["Alice"] = 26;

// Update if exists, add if not
ages["Charlie"] = ages.ContainsKey("Charlie") ? ages["Charlie"] + 1 : 35;

// Conditional update
if (ages.ContainsKey("Bob"))
{
    ages["Bob"] = 31;
}

// Update with TryGetValue
if (ages.TryGetValue("Alice", out int currentAge))
{
    ages["Alice"] = currentAge + 1;
}

// Remove by key - returns true if removed
bool removed = ages.Remove("Bob");  // true
bool notFound = ages.Remove("Eve"); // false

// Remove and get value (C# 7.0+)
if (ages.Remove("Charlie", out int charlieAge))
{
    Console.WriteLine($"Removed Charlie, age {charlieAge}");
}

// Clear all items
ages.Clear();

// Remove items matching condition
var keysToRemove = ages.Where(x => x.Value < 30).Select(x => x.Key).ToList();
foreach (var key in keysToRemove)
{
    ages.Remove(key);
}

// Check if key exists
bool hasAlice = ages.ContainsKey("Alice");  // true
bool hasEve = ages.ContainsKey("Eve");      // false

// Check if value exists (slower - O(n))
bool has25 = ages.ContainsValue(25);  // true
bool has40 = ages.ContainsValue(40);  // false

// Check count
int count = ages.Count;  // 2
bool isEmpty = ages.Count == 0;


// Iterate through key-value pairs
foreach (KeyValuePair<string, int> kvp in ages)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Using var
foreach (var kvp in ages)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Deconstruction (C# 7.0+)
foreach (var (name, age) in ages)
{
    Console.WriteLine($"{name}: {age}");
}

// Iterate through keys only
foreach (string name in ages.Keys)
{
    Console.WriteLine(name);
}

// Iterate through values only
foreach (int age in ages.Values)
{
    Console.WriteLine(age);
}

// Using LINQ
ages.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value}"));


// Properties
int count = ages.Count;                           // Number of items
ICollection<string> keys = ages.Keys;             // All keys
ICollection<int> values = ages.Values;            // All values
IEqualityComparer<string> comparer = ages.Comparer; // Key comparer

// Methods
ages.Add("Charlie", 35);                          // Add item
bool removed = ages.Remove("Bob");                // Remove item
ages.Clear();                                     // Remove all items
bool hasKey = ages.ContainsKey("Alice");          // Check key
bool hasValue = ages.ContainsValue(25);           // Check value
bool success = ages.TryGetValue("Alice", out int age);  // Safe get
bool added = ages.TryAdd("David", 40);            // Safe add (C# 7.0+)


// Filter by value
var adults = ages.Where(x => x.Value >= 30).ToDictionary(x => x.Key, x => x.Value);

// Filter by key
var namesWithA = ages.Where(x => x.Key.StartsWith("A")).ToDictionary(x => x.Key, x => x.Value);

// Get all values above threshold
var agesOver25 = ages.Where(x => x.Value > 25).Select(x => x.Value).ToList();

// Get all keys
var allNames = ages.Keys.ToList();
var namesList = ages.Select(x => x.Key).ToList();

// Order by value
var orderedByAge = ages.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

// Order by key
var orderedByName = ages.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

// Get max/min
var maxAge = ages.Max(x => x.Value);
var oldestPerson = ages.FirstOrDefault(x => x.Value == ages.Max(v => v.Value));

// Sum all values
var totalAge = ages.Sum(x => x.Value);

// Check if any match condition
bool hasYoung = ages.Any(x => x.Value < 25);

// Check if all match condition
bool allAdults = ages.All(x => x.Value >= 18);

// Group by condition
var grouped = ages.GroupBy(x => x.Value >= 30 ? "Adult" : "Young");

// Case-insensitive string keys
Dictionary<string, int> dict = new Dictionary<string, int>(
    StringComparer.OrdinalIgnoreCase);

dict["Alice"] = 25;
dict["alice"] = 30;  // Updates the same entry
Console.WriteLine(dict["ALICE"]);  // 30






/********************************************************************
 *                          Loops & Sequences                       *
 ********************************************************************/


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
static async IAsyncEnumerable<int> ReadSequenceAsync()
{
    foreach (var item in await nextChunk)
    {
        yield return item; //return an iterator that provides access to each element when it's available
    }
}

await foreach (var yieldedNumber in ReadSequenceAsync())
   { Console.WriteLine(yieldedNumber); }



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





/********************************************************************
 *                                Dates                          *
 ********************************************************************/

var myDate = new DateTime(1989, 5, 10);
DateTime date = DateTime.Now;

//Converts the string representation of a date and time to its DateTime equivalent
var releaseDate = DateTime.Parse("1989-2-12");

Console.Write($"{date:yyyy-MM-dd}"); // 2025-09-13
Console.Write($"{date:MMM dd, yyyy}"); // Sep 13, 2025
Console.Write($"{date:HH:mm:ss}"); // 14:30:25

var dateMorning = new DateTime(2025, 9, 25, 8, 30, 0);  // Thursday 8:30 AM
var dateEvening = new DateTime(2025, 9, 25, 17, 45, 0);  // Thursday 5:45 PM  

Console.WriteLine($"Testing: {dateMorning:dddd, MMMM dd, yyyy HH:mm}");





/********************************************************************
 *                                Generics                          *
 ********************************************************************/



// Generic List
public class GenericList<T>
{
    public void Add(T value) { }
}

var genericNumbers = new GenericList<int>();
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
int boxedNumber = 42;
object box = boxedNumber;  // Boxing happens here

//Unboxing
object boxedInt = 42;
int unboxedNumber = (int)boxedInt;  // Unboxing
int unboxedGenericNumber = (T)boxedInt; //Using generics




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
 *                                  LINQs                          *
 ********************************************************************/



List<int> scores = [97, 12, 34, 67];

//LINQ Query syntax
IEnumerable<string> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select $"The score is {score}";

//Transforms each element
var squares = numbers.Select(n => n * n);

//Filters elements based on a condition (ex: all the even numbers)
var evenNumberList = numbers.Where(n => n % 2 == 0);

//Sorts elements in ascending order
var scoresOrderAlpha = scores.OrderBy(s => s); // Alphabetical order

// Sorts elements in descending order
var scoreQueryList = scores.OrderByDescending(s => s);

//ThenBy / ThenByDescending - Secondary sort
List<Person> people = [];
var sortedTwice = people.OrderBy(p => p.Name).ThenBy(p => p.FullName);

// All items in one flat list
var flatList = names.SelectMany(name => name);  

// Using SelectMany to flatten the nested structure
var allSubjects = names.SelectMany(name => scores.Select(score => (name, score)));

//Removes duplicates
var uniqueNums = new[] { 1, 2, 2, 3 }.Distinct(); // [1, 2, 3]

//Gets First N Elements
var firstThree = numbers.Take(3); // Result: [1, 2, 3]

//Skips First N Elements
var afterFirstThree = numbers.Skip(3); // Result: [4, 5, 6, 7, 8, 9, 10]

//Convert a List to an array[]
int[] listToArray = numbers.ToArray();

//Convert an IEnumerable sequence to a List<T>
List<int> enumerableToList = scores.ToList();

// Filters by type
var onlyInts = scores.OfType<int>();  // Only integers from mixed collection

// Reverses order
var reversedOrdered = numbers.Reverse(); // [5, 4, 3, 2, 1]

//Takes until condition fails
var takeNumWhile = numbers.TakeWhile(n => n < 5);  // [1, 2, 3, 4]

//Skips until condition fails
var skipNumWhile = numbers.SkipWhile(n => n < 5);  // [5, 6, 7, 8, 9, 10]

//Count numbers
var countNumbers = numbers.Count();

//sum numbers
var sumNums = numbers.Sum();  // 55

//Average of all elements
var averageNums = numbers.Average();

// Smallest/largest value
int min = numbers.Min();  // 1
int max = numbers.Max();  // 10

// First or default value
var firstOrDefault = empty.FirstOrDefault(); // 0 (for int)

//Last element
numbers.Last();  // 10

//Element at specific index
var elementAtPos = numbers.ElementAt(3);  // 4 (zero-indexed)

//Returns default if empty
var defaultIfEmpty = numbers.DefaultIfEmpty(99);  // [99]

//Checks if any element matches
var anyEvenNumbers = numbers.Any(n => n % 2 == 0);  // true

//Checks if all elements match
var positiveNums = numbers.All(n => n > 0);  // true

//- Checks if element exists
var containsElement = numbers.Contains(5);  // true

List<int> set1 = [1, 2, 3];
List<int> set2 = [2, 3, 4, 5];

//Combines two sequences (no duplicates)
var unionSet = set1.Union(set2);  // [1, 2, 3, 4, 5]

//Common elements
var commonSet = set1.Intersect(set2); // [2, 3]

//Combines sequences (keeps duplicates)
var combined = set1.Concat(set2);  // All elements from both

//Groups by key
people.GroupBy(p => p.LastName); // Groups: A-last name, B-last name, etc.

//Inner Join
people.Join(pet,
    p => p.LastName,
    o => o.CustomerId,
    (c, o) => new { c.Name, o.Total });


//Converts to dictionary
Dictionary<string, string> enumerableToDict = people.ToDictionary(p => p.LastName, p => p.FullName);

//Converts to HashSet
HashSet<int> hashedNums = numbers.ToHashSet();  // HashSet<T>

//Generates sequence of integers
IEnumerable<int> quickSequence = Enumerable.Range(1, 5); // [1, 2, 3, 4, 5]






/********************************************************************
 *                                  Tuples                          *
 ********************************************************************/



// Each element of a tuple has a type and an optional name. It is mutable.
var pt = (X: 1, Y: 2);
Console.WriteLine(pt.Y); // (1, 2)

//with expression to create a modified copy of the existing tuple
var pt2 = pt with { Y = 10 }; // (1, 10)

// Modern tuple
(string name, int age) personTuple = ("Alice", 30);
Console.WriteLine($"{personTuple.name} is {personTuple.age} years old.");


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
var student = ("Bob", 25, "Sociology");
Console.WriteLine($"{student.Item1} studies {student.Item3}.");

//Linq projections with tuples
var names2 = new[] { "Alice", "Bob", "Charlie" };
var results = names2.Select(n => (Original: n, Length: n.Length)).ToList();
Console.WriteLine(results[1]); //(Alice, 5)





/********************************************************************
 *                          Records types                           *
 ********************************************************************/



//Use a record for immutable data models (e.g., DTOs), pattern matching and deconstruction.
//A record is a reference type, with value-based equality semantics by default
public record PointImmutable(int X, int Y);

// You can add behavior to a record type by declaring members
public record Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

//A record struct is a struct type that includes the extra behavior added to all record types.
public record struct PointStruct(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

var point1 = new Point(5,10);
Point point2 = new(5, 10);//object initializer syntax, can be returned from a method : return new(5, 10);

//this should print New point : Point { X = 5, Y = 10 }
Console.WriteLine($" New point : {point1}");

var point3 = point1 with { }; //not changing anything, so this is a shallow clone with all the same values
var point4 = point1 with { X = 7 };

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
public record PersonPrimaryCtor(string FirstName, string LastName)
{
    //init Makes the property settable only during object initialization
    //required Ensures that this property must be set during object creation
    public required string[] PhoneNumbers { get; init; }
}





/********************************************************************
 *                          Patterns matching                     *
 ********************************************************************/


//Null checks with "is expression" 
int? maybe = 12;

//declaration pattern
if (maybe is int numberCasted)
{
    Console.WriteLine($"The nullable int 'maybe' has the value {numberCasted}");
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

//The { } matches any non-null object
if (observation.Annotation is { })
{
    Console.WriteLine($"Observation description: {observation.Annotation}");
}


var dog = new Dog("Bark");
var cat = new Cat("Meow");

//perform a cast conditionally only when it will succeed
//The is operator also tests an expression result against a pattern
if (dog is Pet p)
    p.Breathe();

//old style explicit cast would be:
var pet = (Pet)dog;  // Explicit cast


//The switch expression (modern C# style) using type patterns
//Test for range of values using relational pattern and conjunctive patterns (and, or, not)
var hourOfDay = 12 switch
{
    <= 7 => "early morning",
    > 7 and <= 10 => "morning rush hours",
    > 10 and <= 16 => "regular hours",
    > 16 and <= 19 => "evening rush hours",
    > 19 => "Late night"
};

string status = maybe switch
{
    int value => $"Has value: {value}",
    not string => "It's not a string",
    null => "No value",
    _ => "It's a string"
};

// when clause of a switch arm. You use the when clause to test conditions other than equality on a property
MethodBase method = MemberInfo;
string access = method switch
{
    _ when method.IsPublic => " Public",
    _ when method.IsPrivate => " Private",
    _ when method.IsFamily => " Protected",
    _ when method.IsAssembly => " Internal",
    _ when method.IsFamilyOrAssembly => " Protected Internal ",
    _ => ""
};

//switch with tuples
string quadrant = point1 switch //could be any tuple grouping of values (0, 2, 3 ...)
{
    (0, 0) => "Origin",
    (_, 0) => "X-Axis",
    (0, _) => "Y-Axis",
    _ => "Somewhere else"
};

//Expression-bodied method
static string PatternMatchingSwitch(ValueType? val) => val switch
{
    int or long or decimal or float or double => val.ToString(),
    null => "val is a nullable type with the null value",
    _ => "Could not convert " + val.ToString()
};

decimal myVal = CalculateToll(object obj) =>
    obj switch
{
    Dog d           => 2.00m,
    Cat c           => 3.50m,
    Pet p           => 5.00m,
    Person per      => 10.00m,
    { }             => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(obj)),
    null            => throw new ArgumentNullException(nameof(obj))
};


//property pattern: compares a property value to a constant value recursively
//The property pattern examines properties of the object once the type has been determined
decimal propPattern = dog switch
{
    Dog { Age: 1 } => 2.0m,
    Dog { Age: 2 } => 2.0m + 1.0m,
    Dog { Age: 3 } => 2.0m - 1.0m,
    Dog => 4.0m,
    null => throw new ArgumentNullException(nameof(dog))
};

// when clause of a switch arm. You use the when clause to test conditions other than equality on a property (ranges)
string whenClause = cat switch
{
    _ when cat.Age > 10 => "Very old cat",
    _ when cat.Age < 3 => "Baby cat",
    _ => "Adult cat"
};

//nested switch expressions. You can create a declaration pattern that feeds into a constant pattern
decimal nestedPattern = dog switch
{
    Dog c => c.Age switch
    {
        1 => 2.0m,
        2 => 2.0m + 1.0m,
        3 => 2.0m - 1.0m,
        _ => 4.0m,
    }
};





/********************************************************************
 *                            Files Processing                        *
 ********************************************************************/


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


//File input using StreamWriter
try
{
    using (var sw = new StreamWriter("./test.txt"))
    {
        sw.WriteLine("Hello");
    }
}
// Put the more specific exceptions first.
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine(ex);
}

//using FileStream
FileStream? file = null;
FileInfo? fileInfo = null;

try
{
    fileInfo = new FileInfo("./file.txt");
    file = fileInfo.OpenWrite();
    file.WriteByte(0xF);
}
catch (UnauthorizedAccessException e)
{
    Console.WriteLine(e.Message);
}
finally
{
    file?.Close();
}





/********************************************************************
 *                                  Enums                           *
 ********************************************************************/


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


Console.WriteLine($" Enum value {TransactionType.Deposit}");

//cast an enum to get the int value
var enumInt = (int)FileMode.Create;




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







/********************************************************************
 *                    HTTP requests                                 *
 ********************************************************************/

//use an HttpClient to handle requests and responses
using HttpClient client = new();

//sends an HTTP GET request to the specified URI, return response as a String
var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

//deserialize a JSON response into a C# objects
var repositories = await client.GetFromJsonAsync<List<object>>("https://api.github.com/orgs/dotnet/repos");







/********************************************************************
 *                                Statements                        *
 ********************************************************************/


//The using statement ensures the correct use of an IDisposable instance
//Here for example: when the control leaves the block of the using statement, an opened file is closed
using (StreamReader reader = File.OpenText("numbers.txt"))
{
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
}





/********************************************************************
 *                    file -based C# programs                        *
 ********************************************************************/


//Command to run a file based program
//dotnet buuild AsciiArt.cs (optional run command will first build and compile)
//dotnet run AsciiArt.cs

//Read command line arguments
//dotnet run AsciiArt.cs -- This is the command line.

if (args.Length > 0)
{
    string message = string.Join(' ', args);
    Console.WriteLine(message);
}

//dotnet run -- input.txt --mode fast --verbose



/********************************************************************
 *                  .Net Console application                        *
 ********************************************************************/


//use the dotnet utility from the command line.

//To create a new .NET Core project enter at a command prompt the command (optionally add project name i.e. "WebAPIClient"): 
//  dotnet new console
//  dotnet new console --name WebAPIClient

//To compile a .NET Core project enter at a command prompt the command: 
//  dotnet build


//To compile and execute a .NET Core project enter at a command prompt the command: 
//  dotnet run

