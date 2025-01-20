public class MyClass
{
    public int MyProperty { get; set; }

    public MyClass(int value)
    {
        MyProperty = value;
    }

    public static implicit operator string(MyClass myClass)
    {
        return myClass.MyProperty.ToString();
    }

    public static implicit operator MyClass(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return new MyClass(result);
        }
        else
        {
            // Handle the case where the string cannot be parsed to an integer
            return new MyClass(0); // Or throw an exception
        }
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        MyClass obj1 = new MyClass(10);
        string str1 = obj1; // Implicit conversion to string
        Console.WriteLine(str1); // Output: 10

        string str2 = "20";
        MyClass obj2 = str2; // Implicit conversion from string
        Console.WriteLine(obj2.MyProperty); // Output: 20

        string str3 = "abc";
        MyClass obj3 = str3; // Implicit conversion from string that fails to parse
        Console.WriteLine(obj3.MyProperty); //Output: 0, potential unexpected behavior
    }
}