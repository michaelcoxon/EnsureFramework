# EnsureFramework
EnsureFramework is designed to take the pain out of null checking and making sure (ensuring) your 
methods are being used the way they were intended and throwing exceptions when unsupported values 
are passed to them. 

You can make sure values are in a specific range or simply make sure that an argument is not null.

It was designed to be readable and fluent based, meaning you can chain ensurables together and the 
first one that fails will result in the exception.

# 101
1. Add the namespace 
   ```cs
   namespace EnsureFramework;
   ```
2. Ensure things!  
   *argument-string method*
   ```cs
   public void MyMethod(string anArgument)
   {
       Ensure.Arg(anArgument, nameof(anArgument)).IsNotNullOrEmpty();
   }
   ```
   ... or you can use expressions...  
   *expression based method*
   ```cs
   public void MyMethod(string anArgument)
   {
       Ensure.Arg(() => anArgument).IsNotNullOrEmpty();
   }
   ```

---

# Other things
You can ensure your arguments directly using the *argument-string* override or with the expression override. 
You need to be aware that if performance is desired the *argument-string* override is the best.

#Supported types
There are extensions for common types in .NET but not much else outside of that. We support:
 - IComparable
 - IEnumerable
 - Guid
 - Object
 - String

# Well Mike, my type isn't supported...
That's cool friend, just create your own by adding extension methods to your project. 
Here is a simple one that should point you in the right direction:
```cs
public static IArgumentAssertionBuilder<string> IsNotNullOrEmpty(this IArgumentAssertionBuilder<string> @this)
{
    if (@this.Argument == null)
    {
        throw new ArgumentNullException(@this.ArgumentName);
    }
    if (@this.Argument == string.Empty)
    {
        throw new ArgumentException(null, @this.ArgumentName);
    }
    return @this;
}
```

Check out the code and tests (or lack-there-of) for a bit more info - the project is quite simple.