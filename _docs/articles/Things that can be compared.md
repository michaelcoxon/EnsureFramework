# Things that can be compared

EnsureFramework supports doing ranged comparisons on your assertions. 

## Is equal to

Let's start simple.

The point of this assertion to make sure the incoming argument is equal to a specific
value. 

```cs
public void ThrowIfNotEqualToThree(int value)
{
    Ensure.Arg(value, nameof(value)).IsEqualTo(3);
}
```