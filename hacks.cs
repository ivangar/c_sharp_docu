#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS0219 // Variable is assigned but its value is never used

/* using directives */
using System;
using System.Globalization;
using System.Reflection;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;


/********************************************************************
 *                               Printing                           *
 ********************************************************************/

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

//Formatting => {value:FORMAT}

//format a decimal (or double) as currency with standard numeric format s-trings
decimal balance = 1234.56m;
Console.WriteLine(balance.ToString("C", CultureInfo.GetCultureInfo("en-CA")));
Console.WriteLine(balance.ToString("C", CultureInfo.CurrentCulture));

//Fixed-point (F)
Console.WriteLine($"{value:F0}"); // 2.0339497 -> 2
Console.WriteLine($"{value:F2}"); // 2.0339497 -> 2.03

//Number (N)
Console.WriteLine($"{value:N2}"); // 12345.678 → 12,345.68

//Currency (C)
Console.WriteLine($"{value:C}"); // 123.45 → $123.45

//Percentage (P)
Console.WriteLine($"{value:P}"); // 0.85 → 85.00%

//General (G)
Console.WriteLine($"{value:G}");

//Exponential / Scientific (E)
Console.WriteLine($"{value:E2}"); // 12345 → 1.23E+004

//Integer with leading zeros (D)
Console.WriteLine($"{value:D5}"); // 42 → 00042

//Custom numeric format
// 0 → required digit
// # → optional digit
Console.WriteLine($"{value:0.00}"); // 1234.5 → 1234.50
Console.WriteLine($"{value:#,##0.00}"); //1234.5 → 1,234.50

//Aligning Output
Console.WriteLine($"{value, 10}"); // right-aligned
Console.WriteLine($"{value, -10}"); // left-aligned






/********************************************************************
 *                               Numbers                            *
 ********************************************************************/


float f = 1.0f / 3;       // ~0.3333333 Fast calculations with less precision
double d = 1.0 / 3;       // ~0.333333333333333 precision matters but not to the level of financial accuracy
decimal m = 1.0M / 3;     // Financial and monetary calculations with high precision
int? age = null;
int actualAge = age ?? 18;
int smallest = int.MinValue;   //the smallest possible value of int

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
double rounded = Math.Round(12.5879, 2, MidpointRounding.AwayFromZero);
double pi = Math.PI;
int clamped = Math.Clamp(19, 0, 100);

        //GUID => System.Guid struct => never null!

Guid guid = Guid.NewGuid();
Guid emptyguid = Guid.Empty; //// 00000000-0000-0000-0000-000000000000

string guidString = guid.ToString(); 

//Parse from string
Guid g = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301");

// Safe parse (no exception)
if (Guid.TryParse(guidString, out Guid g2))
    Console.WriteLine(g2);

//From byte array
byte[] bytes = new byte[16]; // fill bytes
Guid g = new Guid(bytes);    

// Back to bytes
byte[] back = g.ToByteArray();

//Check if a GUID has not been assigned yet
var assignedGuid = guid == Guid.Empty;

if (guid == Guid.Empty)
    throw new Exception("Not assigned");

int comparison = guid.CompareTo(g);

guid.ToString("N");  // no dashes → 3f2504e04f8911d39a0c0305e82c3301
guid.ToString("B");  // braces   → {3f2504e0-4f89-11d3-9a0c-0305e82c3301}
guid.ToString("P");  // parens   → (3f2504e0-4f89-11d3-9a0c-0305e82c3301)

//Equality
bool eq  = guid == g;        
bool neq = guid != g;         
bool eq2 = guid.Equals(g);   






/********************************************************************
 *                               Strings                            *
 ********************************************************************/



char character = 'a';
char nullCharacter = default; //'\0'
string firstName2 = "John";
var emptyStr = "";
string? returnEmptyStr = String.Empty; //usually when return from method expects a string
string? nullString = null;
var newStr = new string(['h','e','l','l','o']);

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

//Common methods
var trimmed = firstName2.Trim();
var replaced = helloWorld.Replace("Hello", "Hey");
var contains = helloWorld.Contains("Hello"); //true if it finds the substring
var subStr = helloWorld.Substring(0, 5); // Substring(startIndex, length) => "Hello"
var length = helloWorld.Length;
var startsWith = helloWorld.StartsWith("Hell");
var endsWith = helloWorld.EndsWith("World");
int index = helloWorld.IndexOf("World");
var capitalLetter = char.ToUpper(helloWorld[0]);
var concatenatedStr = string.Concat("Hello", " ", "World"); // "Hello World"
var hasPunctuation = Char.IsPunctuation(character);
var isLetter = char.IsLetter(character);
var isDigit = char.IsDigit(character);
var isLetterOrDigit = char.IsLetterOrDigit(character);
char[] chars = helloWorld.ToCharArray(); //Copies the characters to a Unicode char[].
var lowerCaseStr = helloWorld.ToLowerInvariant(); //Same as string.ToLower()
var upperCaseStr = helloWorld.ToUpperInvariant(); //Same as string.ToUpper()
int compareString = string.Compare("apple", "banana"); // (–1, 0, 1) negative 
ReadOnlySpan<char> test = firstName2.AsSpan(); //read-only span representation

// Split the line based on delimiters
string[] parts = helloWorld.Split(',');
int WordCount() => helloWorld.Split([' ', '.', '?'], StringSplitOptions.RemoveEmptyEntries).Length;

//joins a collection into a single string with separator.
var joinedStr = string.Join(", ", new[] { "A", "B", "C" }); // "A, B, C"
Console.WriteLine($"{string.Join(", ", numbers)}");

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

//Range and Index
s = "Hello World"; 
s[6..]; // "World" 
s[..5]; // "Hello" 
s[^5..]; // "World"







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
var def = default(int);
var nullForgivingOperator = default(int)!; //suppresses null compiler warnings






/********************************************************************
 *                                Arrays                            *
 ********************************************************************/


int[] numbers = { 1, 2, 3, 4, 5, 6 }; //classic (implicit) array initialization (preferred collection expressions)
int[] numArray2 = [1903, 1907, 1910]; //Collection Expression Syntax

int[] numArray3 = new int[3]; //Arrays in C# are fixed-size

Console.WriteLine($"{string.Join(", ", numbers)}");

var length2 = numArray3.Length;

//Use this when you need to pass the array to a method or property that expects new
var numArray4 = new int[]{1903, 1907, 1910};

//Range and Index syntax - .. → Range operator - ^ → Index-from-end operator
//array[start..end]  // end is exclusive 
//^n count from the end of the collection

int last = numbers[^1]; // ^1 is the last element (in this case 6)

//slice arrays (slice is a copy of the original array.)
int[] smallNumbers = numbers[0..5]; // elements from index 0 to 4

var slice = numbers[..3]; //Slice from beginning to index 3

var customSlice = numbers[2..]; //Slice from index 2 to end

var lastTwo = numbers[^2..]; //Use ^ to count from the end. Here last 2 elements

var copy = numbers[..]; // makes a shallow copy: 

//The spread element, ..e in a collection expression adds all the elements in that expression
int[] appendArray = [.. numbers, 11, 12, 13];

Array.Sort(numbers);                    // [1,2,3,4,5]
Array.Reverse(numbers);                 // [5,4,3,2,1]
Array.Fill(numbers, 0);                 // all zeros
Array.Fill(numbers, 9, 1, 3);           // fill with 9, starting from index 1, 3 times.
int idx = Array.IndexOf(numbers, 3);   // find index
int bi  = Array.BinarySearch(numbers, 3); // requires sorted
bool ex = Array.Exists(numbers, n => n > 3);
var value = numbers.ElementAtOrDefault(Array.IndexOf(numbers, 3));  //Returns default value instead of throwing.
byte[] byteArray = new byte[16]; // fill bytes

//Copying an array to a new reference array, now these are 2 different object references
//use Clone() in older code or for compatibility reasons
var clonedArray = (int[])numArray.Clone();

//Doing the same with Array.Copy()
//Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
string[] copy1 = new string[numArray.Length];
Array.Copy(numArray, copy1, numArray.Length);

//Using LINQ (creates a new array):
int[] copy2 = numArray2.ToArray();

//Anonymous implicitely Typed array
var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };

// Create a jagged 2D array:
int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
int twoDval = twoD[1][2]; //6

// Rectangular 2D array
int[,] rect = { {1,2}, {3,4} };
int v = rect[0,1];   
int rows = rect.GetLength(0);
int cols = rect.GetLength(1);

Array.Resize(ref numbers, numbers.Length + 1);



/********************************************************************
 *                          Lists                                   *
 ********************************************************************/


//Lists and arrays are indexable collections, but not all iterable (IEnumerable) types are.

var list1 = new List<string>();  // ✅ var with full type
List<string> list2 = new();          // ✅ target-typed new (C# 9.0+)
List<string> list3 = new List<string>(); // ✅ traditional style, not used a lot anymore.
List<string>? nullItems = null;           // Use when the list might be assigned later

List<int> emptyArray = []; //declaring an empty array of string (C# 12+)

var names = new List<string> { "Alice", "Bob", "Charlie", "David" };  //collection initializer syntax.
List<string> collectionExpression = ["Alice", "Bob", "Charlie", "David"];  //(new) collection expressions C# 12+
List<string> letters = new() { "A", "B", "C" };

Console.WriteLine($"My name is {names[0]}.");

//Quick print of whole list to screen
names.ForEach(name => Console.Write(name + " "));
Console.WriteLine($"List items: {string.Join(", ", names)}");

var copyList = new List<string>(names);

//Null Coalescing Assignment Operator (??=)
nullItems ??= new List<string>();  // Initialize only if null

// Common methods
names.Add("Charlie");
names.AddRange(["Dave", "Eve"]);
names.Insert(1, "Zara");        // insert at index 1
names.Remove("Alice");          // remove first match
names.RemoveAt(0);              // remove by index
names.RemoveAll(n => n.StartsWith("D"));
names.Clear();
var countListItems = names.Count; //Count is a property for list-s, different for Count() for iterable collections
names.Sort();
names.Reverse();
names.ForEach(name => Console.Write(name + " "));

//looping through list
foreach (var letter in letters)
    Console.WriteLine(letter);

//Search capabilities
var index = names.IndexOf("Felipe"); //If the item isn't in the list, IndexOf returns -1.
bool has = list.Contains("Alice");
bool any = list.Exists(n => n.Length > 4);
string found = list.Find(n => n[0] == 'B'); 

// .. spread element to expand a collection (C# 12+)
List<string> moreNames = [.. names, "Roger", "Xavier"];

//Combine list(s) (C# 12+)
List<string> lastNames = ["Johnson", "Harris", "Ovechkin", "O'Brien"];
var fullNames = [.. names, .. lastNames];

//get the sequence iterator that can move through the collection one element at a time
//enumerator starts before the first element.
using var enumerator = evenNumbers.GetEnumerator();

//Advances the iterator to the next element
bool moveTrueOrFalse = enumerator.MoveNext();

//Gets the element at the current position of the iterator.
var currentElement = enumerator.Current;

//iterating with IEnumerator<T>
while (enumerator.MoveNext())
{
    var current = enumerator.Current;
    Console.WriteLine(current);
}

//Convert a list to array
int[] numArray = evenNumbers.ToArray();

//Converting an array to a List<T>
List<string> names = copy2.ToList();

//Spans
Span<char> c = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];
Span<char> slice = c.Slice(1, 2); // b, c

//Remove duplicates from a list:
var unique = new HashSet<string>(names);



/********************************************************************
 *                    Dictionaries<TKey, TValue>                   *
 ********************************************************************/


// Classic explicit constructor
Dictionary<string, int> ages = new Dictionary<string, int>();

// With initial capacity
Dictionary<string, int> ages = new Dictionary<string, int>(100);

//Target-typed (C# 9+)
Dictionary<int, string> targetTypedDict = new();

//var with Ctor
var inferredDict = new Dictionary<string, int>();

//Collection expression (C# 12 - careful it does NOT work for empty dictionaries without type context)
Dictionary<string, string> collectionDict = [];

// Case-insensitive string keys
Dictionary<string, int> dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

//Sorted Dictionary - sorted on the key
var phoneBook = new SortedDictionary<string, string>();

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

//Quick print to screen
Console.WriteLine($"Dictionary [key, value] pairs: {string.Join(", ", ages)}");

// Properties
int count = ages.Count;                           // Number of items
ICollection<string> keys = ages.Keys;             // All keys
ICollection<int> values = ages.Values;            // All values
IEqualityComparer<string> comparer = ages.Comparer; // Key comparer

// Methods
ages.Add("Charlie", 35);                          // Add item
bool added = ages.TryAdd("David", 40);            // Safe add (C# 7.0+)
bool removed = ages.Remove("Bob");                // Remove item
ages.Clear();                                     // Remove all items
bool hasKey = ages.ContainsKey("Alice");        // Check key exists
bool hasValue = ages.ContainsValue(25);           // Check value
bool success = ages.TryGetValue("Alice", out int age);  // Safe get
int charlieAge = ages.GetValueOrDefault("Charlie", 0);  //Get value or default

// Check empty Dict
bool isEmpty = ages.Count == 0;

// Add method - throws exception if key exists
ages.Add("Alice", 25);

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

// Check if key exists
bool hasAlice = ages.ContainsKey("Alice");  // true
bool hasEve = ages.ContainsKey("Eve");      // false

// Check if value exists (slower - O(n))
bool has25 = ages.ContainsValue(25);  // true
bool has40 = ages.ContainsValue(40);  // false

// Update using index operator
ages["Alice"] = 26;

// Update if exists, if not then add other value
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

// Remove items matching condition - removing keys without ToList() will throw an exception
foreach (var key in ages.Keys.ToList())
{
    if(ages[key] > 30)
        ages.Remove(key);
}

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

//(shallow copy) - copy a dictionary into another one using the ctor
var copyDict = new Dictionary<string, int>(ages);

//deep copy - You must clone values manually
var deepCopy = ages.ToDictionary(
    kvp => kvp.Key,
    kvp => new Person { Name = kvp.Value.Name, Age = kvp.Value.Age }
);

// Using LINQ
ages.ToList().ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value}"));

// Transform to Dict from other collections
List<KeyValuePair<string,int>> keyValuePairList = [
    new KeyValuePair<string, int>("Myriam", 25),
    new KeyValuePair<string, int>("John", 45)];
    
Dictionary<string,int> people = keyValuePairList.ToDictionary(x => x.Key, x => x.Value);

// Filter by value
var adults = ages.Where(x => x.Value >= 30).ToDictionary(x => x.Key, x => x.Value);

// Filter by key
var namesWithA = ages.Where(x => x.Key.StartsWith('A')).ToDictionary(x => x.Key, x => x.Value);

// Get all values above threshold
var agesOver25 = ages.Where(x => x.Value > 25).Select(x => x.Value).ToList();

// Get all keys
var allNames = ages.Keys; //directly accesses the dictionary’s key collection
var namesList = ages.Select(x => x.Key).ToList();

// Order by value
var orderedByAge = ages.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

// Order by key
var orderedByName = ages.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

// Get max/min
var maxAge = ages.Max(x => x.Value); //returns an int value
var oldestPerson = ages.FirstOrDefault(x => x.Value == ages.Max(v => v.Value));

//The following return the whole KeyValuePair sequence, not just the value
var youngest = ages.MinBy(x => x.Value); // David, 20
var oldest   = ages.MaxBy(x => x.Value); // Charlie, 35

// Sum all values
var totalAge = ages.Sum(x => x.Value);

// Check if any match condition
bool hasYoung = ages.Any(x => x.Value < 25);

// Check if all match condition
bool allAdults = ages.All(x => x.Value >= 18);

// Group by condition
var grouped = ages.GroupBy(x => x.Value >= 30 ? "Adult" : "Young");

dict["Alice"] = 25;
dict["alice"] = 30;  // Updates the same entry
Console.WriteLine(dict["ALICE"]);  // 30






/********************************************************************
 *                              HashSets                            *
 ********************************************************************/
//Stores unique elements only (no duplicates)
//Is unordered
//Provides very fast lookups (typically O(1))


var emptySet = new HashSet<int>();
var hashSet = new HashSet<int> { 1, 1, 2, 3, 3 }; //Result: {1, 2, 3}
 
var set2 = new List<int> {1, 1, 2, 3, 3 }.ToHashSet(); 

//Gets the equality comparer used (e.g., case-insensitive)
var comparer = set.Comparer;

//Case-insensitive sets
var nameSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
{
    "Ivan",
    "ivan" // this entry will not be added "Ivan" == "ivan"
};

//Create HashSet based on a list
var duplicates = new List<int> { 1, 2, 2, 2, 3 };
var uniqueSet = new HashSet<int>(duplicates); //1, 2, 3

//Common methods
bool added = hashSet.Add(5); 
bool removed = hashSet.Remove(5);  
int removed = hashSet.RemoveWhere(x => x % 2 == 0);
bool containsHashValue = hashSet.Contains(5);  
hashSet.Clear();
int countElements = hashSet.Count;

//Set operations
hashSet.UnionWith(set2);            //Adds all elements from other → A ∪ B
hashSet.IntersectWith(set2);        //Keeps only shared elements → A ∩ B
hashSet.ExceptWith(set2);           //Removes elements found in other → A − B
hashSet.SymmetricExceptWith(set2);  //Keeps elements in either but not both → A △ B

//Comparison methods
hashSet.IsSubsetOf(set2);
hashSet.IsSupersetOf(set2);
hashSet.Overlaps(set2);             //True if A and B share at least one element
hashSet.SetEquals(set2);            //True if A and B contain exactly the same elements





/********************************************************************
 *                          Loops & Iterators                       *
 ********************************************************************/


foreach (var number in numbers)
{
    //.. Do some action
}

foreach (var number in numbers[2..4])
{
    //.. Do some action
}

for (int i = 0; i < numbers.Length; i++)
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

static IEnumerable<int> InfiniteCounter()
{
    int i = 0;
    while (true)
        yield return i++;
}

//await foreach
static async IAsyncEnumerable<int> ReadSequenceAsync()
{
    foreach (var item in await nextChunk())
    {
        //Use Task.Delay inside async code for testing awaitable delays
        await Task.Delay(3000);

        if (item is null) 
            yield break; // stop iteration

        yield return item; //return an iterator that provides access to each element when it's available
    }
}

//data is streamed asynchronously
await foreach (var yieldedNumber in ReadSequenceAsync())
   { Console.WriteLine(yieldedNumber); }


//More asynchronous iterators
async IAsyncEnumerable<int> GenerateNumbersAsync(int count)
{
    for (int i = 0; i < count; i++)
        yield return await ProduceAsync(i);
}

async Task<int> ProduceAsync(int seed)
{
    await Task.Delay(1000);
    return seed * 2;
}

//Handle reading input from standard input (stdin) 
while (Console.ReadLine() is string line && line.Length > 0)
{
    Console.WriteLine(line);
}


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
}  // reader.Dispose() is automatically called here

//Modern C# also supports the declaration form (no braces needed):
using var reader = File.OpenText("numbers.txt"); 


//Recursive algorithms (e.g., tree traversal)
static IEnumerable<Node> Traverse(Node node)
{
    yield return node;

    foreach (var child in node.Children)
        foreach (var descendant in Traverse(child))
            yield return descendant;
}

//Return lazy sequence instead of a list
static IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

foreach (var suit in Suits())
    Console.WriteLine($" Suit : {card.Suit}");


//you can implement GetEnumerator()
class NumberBox
{
    private readonly int[] _values = { 1, 2, 3, 4 };

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var v in _values)
            yield return v;
    }
}





/********************************************************************
 *                                Dates                          *
 ********************************************************************/


var newDateTime = new DateTime(); //Min value date 1/1/0001 12:00:00 AM
var newDateTime = new DateTime(1989, 5, 10);
var exactDateTime = new DateTime(2025, 4, 9, 14, 30, 0); //+ hour, min, sec
DateTime now = DateTime.Now; //Local date + time
DateTime utcNow = DateTime.UtcNow; //UTC date + time
DateTime today = DateTime.Today; //Today at 00:00:00
DateTime minValue = DateTime.MinValue; //Boundary sentinels
DateTime maxValue = DateTime.MaxValue; //Boundary sentinels

//Properties
int year = newDateTime.Year;
int month = newDateTime.Month;
int day = newDateTime.Day;
int hour = newDateTime.Hour;
int minute = newDateTime.Minute;
int second = newDateTime.Second;
long ticks = newDateTime.Ticks;
DayOfWeek dayOfWeek = newDateTime.DayOfWeek; //DayOfWeek enum (0=Sunday)
int dayOfYear = newDateTime.DayOfYear; //1–366
DateTime dateMidnight = newDateTime.Date; //Same date, time 00:00:00
TimeSpan year = newDateTime.TimeOfDay;
DateTimeKind kind = newDateTime.Kind; //Local / Utc / Unspecified

//Types
var dateTime = DateTime(); //Date + time, no timezone
var dateOnly = DateOnly(); //Date only
var timeOnly = TimeOnly(); //time only
var dateTimeOffset = DateTimeOffset(); //DateTime + UTC offset
var timeSpan = TimeSpan(); // Duration / difference

//Add/Subtract methods
DateTime addYears = newDateTime.AddYears(3);
DateTime addMonths = newDateTime.AddMonths(12);
DateTime addDays = newDateTime.AddDays(30); //Negative = subtract
DateTime addHours = newDateTime.AddHours(18);
DateTime addMinutes = newDateTime.AddMinutes(59);
DateTime AddSeconds = newDateTime.AddSeconds(60);
DateTime addTimeSpan = newDateTime.Add(10000000); //Add any TimeSpan
TimeSpan subtractDate = newDateTime.Subtract(exactDateTime);

//Compare dates
int compareDates = DateTime.Compare(newDateTime, exactDateTime); //–1, 0, 1
int dateCompareTo = newDateTime.CompareTo(exactDateTime);
bool dateEquals = newDateTime.Equals(exactDateTime);
bool operatorDateEquals = newDateTime == exactDateTime;
bool operatorDateNotEquals = newDateTime != exactDateTime; //also: a < b, a > b, a <= b, a >= b
TimeSpan dateDifference = newDateTime - exactDateTime;

//Parse & Convert
DateTime parsedDate = DateTime.Parse("1989-2-12");
bool tryParsedDate = DateTime.TryParse("1989-2-12", out dt);
DateTime parsedExact = DateTime.ParseExact("1989-2-12", "yyyy-MM-dd", ci);
bool tryParsedExact = DateTime.TryParseExact("1989-2-12", "yyyy-MM-dd", ci, out dt);
DateTime localTime = DateTime.ToLocalTime();
DateTime utcTime = DateTime.ToUniversalTime();
long windowsFileTime = DateTime.ToFileTime(); //Windows File Time
double OLEAutomationdate = DateTime.ToOADate(); //OLE Automation date

//Formatting (ToString) -> You can just print the date without convert toString()
string shortDate = newDateTime.ToString("d"); //Short date: 4/10/2026
string longDate = newDateTime.ToString("D"); //Long date: Friday, April 10, 2026
string shortTime = newDateTime.ToString("t"); //Short time: 11:12 AM
string longTime = newDateTime.ToString("T"); //long time: 11:12:00 AM
string fullDate = newDateTime.ToString("f"); //Full date + time: Friday, April 10, 2026 11:12 AM
string generalShort = newDateTime.ToString("g"); //General short: 4/10/2026 11:12 AM
string generalLong = newDateTime.ToString("G"); //General long (Default print format): 4/10/2026 11:12:00 AM
string sortableIso = newDateTime.ToString("s"); //Sortable (ISO-like): 2026-04-10T15:12:00
string roundTripISO = newDateTime.ToString("o"); //Round-trip ISO 8601: 2026-04-10T15:12:00.000Z
string monthDay = newDateTime.ToString("M"); //Month and day: April 10
string yearMonth = newDateTime.ToString("Y"); //Year and month: April 2026
string RFC1123 = newDateTime.ToString("R"); //RFC 1123: Fri, 10 Apr 2026 15:12:00 GMT
string universalSortable = newDateTime.ToString("u"); //Universal sortable: 2026-04-10 15:12:00Z
string customPatternDate = newDateTime.ToString("yyyy-MM-dd HH:mm:ss"); //Custom pattern: 2026-04-10 11:12:00

if (newDateTime.HasValue)
    Console.WriteLine(newDateTime.Value.ToString("D"));

//TimeSpan
var newTimeSpan = new TimeSpan(12,7,45);
var fromDays = TimeSpan.FromDays(15);
var fromHours = TimeSpan.FromHours(45);
var days = TimeSpan.Days;
var timeSpanHours = TimeSpan.Hours;
var timeSpanMinutes = TimeSpan.Minutes;
var timeSpanSeconds = TimeSpan.Seconds;
var totalDays = TimeSpan.TotalDays; 
var totalHours = TimeSpan.TotalHours; 
var totalMinutes = TimeSpan.TotalMinutes;

//Calendar helpers
bool isLeapYear = DateTime.IsLeapYear(2026);
int daysInMonth = DateTime.DaysInMonth(2026, 5);

//DateTimeOffset & TimeZones
DateTimeOffset dateTimeOffset = DateTimeOffset.Now; //4/12/2026 2:08:19 PM -04:00
DateTimeOffset dateTimeOffsetUTC = DateTimeOffset.UtcNow; //4/12/2026 6:08:19 PM +00:00
TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("3");
TimeZoneInfo.ConvertTime(dt, tz);
TimeZoneInfo.ConvertTimeToUtc(dt, tz);
TimeZoneInfo.Local;
TimeZoneInfo.Utc;

//Format output
Console.Write($"{newDateTime:yyyy-MM-dd}"); // 2025-09-13
Console.Write($"{newDateTime:MMM dd, yyyy}"); // Sep 13, 2025
Console.Write($"{newDateTime:HH:mm:ss}"); // 14:30:25






/********************************************************************
 *                    Methodss & Properties                         *
 ********************************************************************/
//Every method has a signature: access modifier, return type, name, parameters. 
//The body contains the logic.

//To avoid error highlighting we put all methods inside a dummy class
class Dummy{

        //Properties

private string _name;         // backing field (private)

public string Name            // property (public)
{
    get => _name;
    set => _name = value?.Trim(); //value is the implicit parameter representing the assigned value
}

// Read-write
public string Name { get; set; }

//Init-only - only callable during object initialisation
public string Id { get; init; }

//read-only
public string Key { get; }

// With default value (C# 6+)
public int Count { get; set; } = 0;

// Expression-bodied computed property
public int Area => Width * Height;

// Full body if logic needed
public string Label
{
    get
    {
        if (Area > 1000) return "Large";
        return "Small";
    }
}

// Public read, private write
public int Score { get; private set; }

// Public read, protected write
public string State { get; protected set; }

// Internal set — within assembly only
public Guid Id { get; internal set; }

//Indexers — property-style access by key

//Let a class be indexed like an array
public T this[int index]
{
    get => _items[index];
    set => _items[index] = value;
}

// Non-integer key
public string this[string key]
    => _dict.TryGetValue(key, out var v) ? v : null;


            //Methods

public int Add(int a, int b)   // signature
{
    return a + b;              // body
}

// Expression-bodied (C# 6+)
public int Add(int a, int b) => a + b;

            //Parameters

//C# supports several parameter flavours.

// Default value (Named argument at call site)
void Greet(string name = "World") { }
//Greet(name: "Alice");

            //Parameters by reference

//With ref — must be initialized, can read AND write, original is modified
void ModifyReference(ref int y) => y *= 2;
//int b = 5;
//ModifyReference(ref b);


// out — doesn't need to be initialized, MUST be written inside
void WithOut(out int x) => x = 99;
//call it like this => WithOut(out int x);


// in — must be initialized, READ ONLY (no modification allowed)
void WithIn(in int x) => Console.WriteLine(x); // can't write to x
// int x = 15;
// WithIn(in x);


// params — variable-length
// params is just syntactic sugar that lets callers pass a comma-separated list instead of array
int Sum(params int[] nums) => nums.Sum();
//Sum(0, 1, 0, 3, 12);

            //Return types

// Typed return
public string GetName() => _name;

// void — no return value
public void Reset() => _count = 0;

// Tuple return (C# 7+)
public (int min, int max) Range()
    => (Items.Min(), Items.Max());

// Async Task (Non-blocking I/O operations)
public async Task<string> FetchAsync()
    => await _client.GetStringAsync(url);

//Local functions
public static void OuterMethod()
{
    //A local function is a method declared inside another method.
    void InnerHelper()
    {
        Console.WriteLine("I'm inside OuterMethod");
    }

    InnerHelper();
}

            //Accessors

//get accessor
private List<string> _tags;

public IReadOnlyList<string> Tags
{
    get
    {
        // Lazy initialisation
        return _tags ??= new List<string>();
    }
}

//set accessor
private int _age;

public int Age
{
    get => _age;
    set
    {
        if (value < 0 || value > 150)
            throw new ArgumentOutOfRangeException();
        _age = value;
        OnPropertyChanged();     // notify UI (INotifyPropertyChanged)
    }
}

            //Method overloading

public string Format(int n)     => n.ToString();
public string Format(double d)  => d.ToString("F2");
public string Format(DateTime dt) => dt.ToString("yyyy-MM-dd");


            //Generic methods

// Unconstrained
public T[] Repeat<T>(T item, int count)
    => Enumerable.Repeat(item, count).ToArray();

// Constrained: T must implement IComparable
public T Max<T>(T a, T b) where T : IComparable<T>
    => a.CompareTo(b) >= 0 ? a : b;

// Multiple constraints
public T Create<T>() where T : class, new()
    => new T();
    

} //ending of Dummy class


//Extension methods (Must be in a static class)

public static class StringExtensions
{
    //has to be static
    public static bool IsNullOrEmpty(this string s)
        => string.IsNullOrEmpty(s);
}

// Called as if it's a string method
string name = null;
bool empty = name.IsNullOrEmpty(); // true

            //Operator overloading

public readonly record struct Money(decimal Amount, string Currency)
{
    //Must be public static
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency) throw new InvalidOperationException();
        return a with { Amount = a.Amount + b.Amount };
    }
}

            //Access modifiers

/*
+----------------------+--------------------------------+
| Modifier             | Visible to                     |
+----------------------+--------------------------------+
| public               | Everyone                       | 
| private              | Containing class only          | 
| protected            | Containing class + subclasses  | 
| internal             | Same assembly                  | 
| protected internal   | Same assembly OR subclasses    | 
| private protected    | Same assembly AND subclasses   | 
+----------------------+--------------------------------+
*/       

                //Other modifiers

/*
+----------------------+------------------------------------+
| Modifier             | Effect                             |
+----------------------+------------------------------------+
| static               | Belongs to type, not instance      | 
| readonly             | Field set only in constructor      | 
| const                | Compile-time constant              | 
| async                | Enables await inside method        | 
| partial              | Split across files                 | 
| extern               | Implemented externally (P/Invoke)  | 
+----------------------+------------------------------------+
*/ 







 
/********************************************************************
 *                             Classes & Objects                    *
 ********************************************************************/

/*
* Block-Scoped (Traditional) Namespace:         namespace Name { ... }
* File-Scoped Namespace Declaration (C# 10+)    namespace Name;   
* You can even use nested namespaces:           namespace MyApp.Services.Payments;                    
*/

//The most basic class declaration requires only the class keyword and a name.
class Basic
{
}

//using a Primary Constructor (C# 12+)
//parentheses are not necessary
public class MyCar(){}

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
void CallMethod(Person person) { };

CallMethod(new Person() { FirstName = "Ivan", LastName = "Garzon" });

//using primary constructor (new in C# 12)
public class Person(string firstName, string lastName, MyCar car)
{
    public string First { get;  set; } = firstName;
    public string LastName { get; set; } = lastName;
    public MyCar Car { get; set; } = car;
    public List<Pet> Pets { get; } = new(); //new in C# empty list

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


//In Abstract classes there's a strong "is-a" relationship
//Use an abstract class when derived classes are logically types of the base class.
//Cannot create instance of an abstract Pet
public abstract class Pet(string firstName)
{

    public string First { get; } = firstName;

    //Implemented
    public void Breathe() => Console.WriteLine("Breathing...");

    public virtual void BeFriendly() => Console.WriteLine("Jump and be frantic");

    //all derived classes MUST use the following method (cannot implement body here, it's not allowed)
    public abstract string MakeNoise();

    public abstract void DoWork() { }   // ❌ compile error

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





/********************************************************************
 *                     Events & Delegates                           *
 ********************************************************************/



//C#'s built-in delegate type
Func<T, TResult> square = x => x * x; //T is input, TResult is output

//Takes T, returns nothing
Action<T>;

//Takes T, returns bool
Predicate<T>;


//Example of a method that takes a delegate function
static IEnumerable<TResult> Transform<T, TResult>(
    IEnumerable<T> source,      // 1. a list of any type T
    Func<T, TResult> selector   // 2. a method that converts T → TResult
)
{
    foreach (var element in source)
        yield return selector(element); // 3. apply the method to each element lazily
}

// 3 Ways to Pass a Delegate

var delegateList = new List<string> { "Alice", "Bob", "Jasmine" };

//1. Named method
static int GetLength(string s) => s.Length;
var result = Transform(delegateList, GetLength);

//2. Anonymous method
var result = Transform(delegateList, delegate(string s) { return s.Length; });

//3. Lambda (most common in modern C#)
var result = Transform(names, s => s.Length);

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


                                                    /*  Automated Tests */


                                                    /* Task based asynchronous */

public static async Task<int> GetPageLengthAsync(string endpoint)
{
    byte[] content = await client.GetByteArrayAsync(uri);
    return content.Length;
}




/********************************************************************
 *                     LINQs & Collections                          *
 ********************************************************************/



IEnumerable<int> scores = [97, 12, 34, 67];

//declaring an Enumerable empty collection
IEnumerable<string> emptyList = Enumerable.Empty<string>();
IEnumerable<string> empty = [];  
IEnumerable<int> moreScores = [.. scores, 11, 12, 13];                      

//LINQ Query syntax
IEnumerable<string> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select $"The score is {score}";

//Print LINQ - deferred iterable execution
Console.WriteLine(string.Join(", ", scores));

foreach(var item in scores)
    Console.WriteLine($"{item}");

//Transforms each element
var squares = numbers.Select(n => n * n);

//Filters elements based on a condition (ex: all the even numbers)
var evenNumberList = numbers.Where(n => n % 2 == 0);

//Filters elements based on a condition (ex: all the odd numbers)
var oddNumberList = numbers.Where(n => n % 2 != 0);

//Filters elements based on a condition (ex: all the prime numbers)
var primes = Enumerable.Range(1, 19)
                       .Where(n => !Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Any(d => n % d == 0));

//Sorts elements in ascending order
var scoresOrderAlpha = scores.OrderBy(s => s); // Alphabetical order

// Sorts elements in descending order
var scoreQueryList = scores.OrderByDescending(s => s);

//ThenBy / ThenByDescending - Secondary sort
List<Person> people = [];
var sortedTwice = people.OrderBy(p => p.Name).ThenBy(p => p.FullName);

// All items in one flat list - i.e. takes a list of list(s), and flatten it into one IEnumerable
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

//Compares two sequences element by element
var a = "hello";
var b = "hello";
a.SequenceEqual(b); // true  — same chars, same order

//Takes until condition fails
var takeNumWhile = numbers.TakeWhile(n => n < 5);  // [1, 2, 3, 4]

//Skips until condition fails
var skipNumWhile = numbers.SkipWhile(n => n < 5);  // [5, 6, 7, 8, 9, 10]

//Count numbers
var countNumbers = numbers.Count();

//sum numbers
var sumNums = numbers.Sum();  // 55

//Returns the only element of a sequence or throws exception
var single = numbers.Single(x => x > 7 && x < 9);

//Average of all elements
var averageNums = numbers.Average();

// Smallest/largest value
int min = numbers.Min();  // 1
int max = numbers.Max();  // 10

//Aggregate (accumulator function) to multiply all numbers using a seed = 1
int product = numbers.Aggregate(
    1, 
    (accumulated, x) => accumulated * x
); 

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

//A − B (set difference) elements from set1 that are not present in set2
var excludeElements = set1.Except(set2);

//Groups by key
people.GroupBy(p => p.LastName); // Groups: A-last name, B-last name, etc.

//Inner Join
people.Join(
    orders,
    p => p.Id,
    o => o.CustomerId,
    (c, o) => new { c.Name, o.Total });

//Converts to dictionary
Dictionary<string, string> enumerableToDict = people.ToDictionary(p => p.LastName, p => p.FullName);

//Converts to HashSet
HashSet<int> hashedNums = numbers.ToHashSet();  // HashSet<T>

//Generates sequence of integers
IEnumerable<int> quickSequence = Enumerable.Range(1, 5); // [1, 2, 3, 4, 5]

IEnumerable<int> evenNumbers = Enumerable.Range(1, 5).Where(n => n % 2 == 0);

// Converts IEnumerable<int> → IEnumerable<int?>
// treat every element as this type going forward.
List<int?> nullableScores = scores.Cast<int?>().ToList();




/********************************************************************
 *                      Tuples - ValueType<T1, T2,...>               *
 ********************************************************************/


        //Value tuple literals

// Unnamed
var tuple = (42, "hello", 3.14);  // ValueTuple<int, string, double>

//Access tuple with Item field
string item = tuple.Item1; //"hello"

// Explicit type
(int X, int Y) pt = (10, 20);

//The Tuple class does not itself represent a tuple, it provides static methods.
var tuples = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
Console.WriteLine($"{tuples.Item1}, {tuples.Item3}, {tuples.Item6}"); // 2, 5, 13

// Each element of a tuple has a type and an optional name (Named Tuple). It is mutable.
var pt = (X: 1, Y: 2);
Console.WriteLine(pt.Y); // (1, 2)

//Quick grouping of values
var student = ("Bob", 25, "Sociology");
Console.WriteLine($"{student.Item1} studies {student.Item3}.");

//value tuple instances are mutable
pt.X = 4; // (X: 4, Y: 2)

// copy tuples - copies the whole struct:
var copyTuple = student; 


        //Deconstruction


//Deconstructed variable declaration
var (X, Y) = (1, 2);
Console.WriteLine($"tuple: ({X}, {Y})");

//Deconstruct to existing vars
int x, y;
(x, y) = (5, 9);

// Typed
var t = (X: 3, Y: 4);
(int a, int b) = t;

// Discard unwanted
var (_, yOnly) = t;

// Nested deconstruct
var ((r, g), alpha) = ((r: 255, g: 0), 1.0);

//with expression to create a modified copy of the existing tuple
var pt2 = pt with { Y = 10 }; // (1, 10)

// Modern tuple - Explicit type
(string name, int age) personTuple = ("Alice", 30);
Console.WriteLine($"{personTuple.name} is {personTuple.age} years old.");

//first and second values are discards
(_, _, area) = city.GetCityInformation(cityName);
Console.WriteLine($"The city are is {area}");


            //Methods & returns

//Returning multiple values from a method — Positional Tuple
(int, int) Calculate(int a, int b)
{
    return (a + b, a * b);
}

//call positional tuple with deconstructing
var (sum, product) = Calculate(5, 6);
(sum, int product) = Calculate(5, 6);

//Returning multiple values from a method -  Named Tuple (Recommended)
(int sum, int product) Calculate(int a, int b)
{
    return (
        sum: a + b,
        product: a * b
    );
} 

var namedTuple = Calculate(2, 3);

//As method parameter
double Distance((int X, int Y) a, (int X, int Y) b)
{
    int dx = a.X - b.X;
    int dy = a.Y - b.Y;
    return Math.Sqrt(dx*dx + dy*dy);
}


        //projections 

//projections with tuples
var names2 = new[] { "Alice", "Bob", "Charlie" };
var results = names2.Select(n => (Name: n, Length: n.Length)).ToList();
Console.WriteLine(results[1]); //(Alice, 5)

//using ForEach lambda to Loop through each tuple
results.ForEach(client => Console.WriteLine($"{client.Name} - {client.Length}"));

//using a foreach loop on a collection of tuples 
foreach (var (name, length) in results)
    Console.WriteLine($"{name} - {length}");

//Linq projection with indexed Select
var result = names
    .Select((n, i) => (Index: i, Upper: n.ToUpper()))
    .Where(t => t.Index > 0);

//List of tuples
var pts = new List<(int X, int Y)>
{
    (1, 2), (3, 4), (5, 6), (3,4), (10,6)
};

//Tuple dictionary
var tupleDict = new Dictionary<(int X, int Y), string>();

tupleDict[(0, 0)] = "origin";
tupleDict[(1, 2)] = "point";


    //Equality & struct semantics

var a = (X: 1, Y: 2);
var b = (1, 2);

bool eq = (a == b);    // true (C# 7.3+)
bool neq = (a != b);   // false


        //Type aliases (C# 12)

// scroll to top for Global using alias
// using Point = (int X, int Y);
// using RGB   = (byte R, byte G, byte B);
Point origin = (0, 0);
RGB   red    = (255, 0, 0);


//Custom deconstruct

class Point {
  public int X, Y;

  public void Deconstruct(out int x, out int y)
    => (x, y) = (X, Y);
}

var (x, y) = new Point
{
    X=3,
    Y=4
};







/********************************************************************
 *                  Records types (class or struct)                 *
 ********************************************************************/



//Use a record for immutable data models (e.g., DTOs), pattern matching and deconstruction.
//A record is a reference type, with value-based equality semantics by default
public record Person(string FirstName, string LastName); //Immutable positional parameters

var recordClass = new Person("Grace", "Hopper");

//Standard property syntax
public record Product
{
    public required string Name { get; init; }
    public decimal Price { get; set; } //read/write but it defeats the purpose of immutability
}

//instantiating of standard record 
var prod = new Product
{
    Name = "name",
    Price = 23.5
};

// You can add behavior to a record type by declaring members
public record Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}

//A record struct is a struct type that includes the extra behavior added to all record types.
public record struct Coordinate(double Latitude, double Longitude)
{
    public double Slope() => Latitude / Longitude;
}

public readonly record struct Temperature(double Celsius)
{
    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32.0;
}

//record class vs. record struct

// Record class
var p1 = new Person("Ivan", "Garzon");
var p2 = p1; // p1 and p2 point to the same object:
var referenceEquality = ReferenceEquals(p1, p2); //True

// Record struct — assignment copies the data
var c1 = new Coordinate(47.6062, -122.3321);
var c2 = c1;
var valueEquality = c1 == c2; //true
c2.Longitude = 0.0; // mutating c2 doesn't affect c1


var point1 = new Point(5,10);
Point point2 = new(5, 10);//object initializer syntax, can be returned from a method : return new(5, 10);

//this should print New point : Point { X = 5, Y = 10 }
Console.WriteLine($" New point : {point1}");

//Nondestructive mutation -> with creates a new object
var point3 = point1 with { }; //not changing anything, so this is a shallow clone with all the same values
var point4 = point1 with { X = 7 };

//Equality works the same for record class & record struct
Console.WriteLine(point1 == point2); // output: True if type name and properties are equal

//Positional records generate a Deconstruct
var (first, last) = person;
Console.WriteLine($"{first} {last}");

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

//Record inheritance
public record ThreeDimensionPoint(int X, int Y, int Z) : Point(X, Y);







/********************************************************************
 *                          Patterns matching                     *
 ********************************************************************/


//Null checks with "is expression" 
int? maybe = 12;

//declaration pattern
//perform a cast conditionally only when it will succeed
if (maybe is int numberCasted)
    Console.WriteLine($"The nullable int 'maybe' has the value {numberCasted}");

//classic type checking
if (maybe is int or long or decimal or float or double)
    return val.ToString();

string? message = ReadMessageOrDefault();

if (message is null)
    Console.WriteLine("null object");

// not logical pattern 
if (message is not null)
    Console.WriteLine(message);

//return "is" as an expression evaluation from method
bool IsValidScore(int score) => score is -1 or (>= 0 and <= 100);

//The previous method syntax is similar to:
static bool IsValidScore(int score)
{
    if(score is -1 or (>= 0 and <= 100))
        return true;
    else return false;
}

//The { } matches any non-null object
if (observation.Annotation is { })
    Console.WriteLine($"Observation description: {observation.Annotation}");

var dog = new Dog("Bark");
var cat = new Cat("Meow");

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

string hourOfDay;
int hour = 12;

//Equivalent old-style switch
switch (hour)
{
    case int h when h <= 7:
        hourOfDay = "early morning";
        break;
    case int h when h > 7 && h <= 10:
        hourOfDay = "morning rush hours";
        break;
    case int h when h > 10 && h <= 16:
        hourOfDay = "regular hours";
        break;
    case int h when h > 16 && h <= 19:
        hourOfDay = "evening rush hours";
        break;
    case int h when h > 19:
        hourOfDay = "Late night";
        break;
    default:
        hourOfDay = "unknown";
        break;
}

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
    (var x, 0) => "X-Axis",
    (0, var y) => "Y-Axis",
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
    string? line;
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
//structs are value types stored on the stack
//Microsoft recommendation: Structs should be small, immutable, and contain only value-type fields.
//has a default zero-value
//Cannot inherit or be inherited 


struct Struct
{
    public int X;
    public int Y;
}

//Instantiate a struct
var structInstance = new Struct();
Struct structInstance = new();
var structInstance = new Struct { X = 3, Y = 5 };
Struct structInstance = new() { X = 3, Y = 5 };

public struct BasicStruct
{
    public int X { get; set; }
    public int Y { get; set; }
    public BasicStruct(int x, int y) { X = x; Y = y; }
    public double DistanceTo(BasicStruct other) =>
        Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
}


// Value type — COPY behavior
BasicStruct a = new(1, 2);
BasicStruct b = a;       // b is a full copy
b.X = 99;
Console.WriteLine(a.X); // Still 1 — a is unaffected

//immutable readonly struct (init-only properties)
public readonly struct Temperature
{
    public double Celsius { get; }
    public Temperature(double celsius) => Celsius = celsius;
}


struct Vector2 { public float X, Y; }

void Scale(ref Vector2 v, float factor)
{
    v.X *= factor; 
    v.Y *= factor;
}

var position = new Vector2 { X = 3f, Y = 4f };
Scale(ref position, 2f);// position  { X = 6, Y = 8 }

//record struct
public record struct RecordStruct(int X, int Y); // Immutable, value equality, with-expressions






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
 *                                Regex                             *
 ********************************************************************/

//need to use the Regex namespace before
//using System.Text.RegularExpressions;

//match words (ignores punctuation)
var words = Regex.Matches(sentence, @"\b\w+\b").Select(m => m.Value);

//match letters only
var words = Regex.Matches(sentence, @"\b[a-zA-Z]+\b").Select(m => m.Value);




/********************************************************************
 *                    file-based C# programs                        *
 ********************************************************************/

//Create a cs-extension file anywhere

//Commands to run a file based program

//dotnet new console --use-program-main false (need to investigate this one)
//dotnet build AsciiArt.cs (optional run command will first build and compile)
//dotnet run AsciiArt.cs

//Read command line arguments
//dotnet run AsciiArt.cs -- This is the command line.

if (args.Length > 0)
{
    string message = string.Join(' ', args);
    Console.WriteLine(message);
}

//dotnet run -- input.txt --mode fast --verbose

//multi‑file compilation
//dotnet run a.cs b.cs c.cs

//Example of a simple file‑scoped app

/* 
using System;

class Person
{
    public string Name { get; set; }
    public void SayHello() => Console.WriteLine($"Hello, I'm {Name}");
}

var p = new Person { Name = "Ivan" };
p.SayHello(); */





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

