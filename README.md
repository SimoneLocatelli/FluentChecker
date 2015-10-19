# FluentChecker

Using FluentChecker you can implement a nice and fluent way to verify conditions and do simple parameters validations. 


```C#
public class UserRepository()
{
  public UserRepository(Connection connection)
  {
    Check.IfIsNull(connection)
                              .Throw<ArgumentNullException>( () => connection)
  }

  public User FindByName(string name)\
  {
  Check.IfIsNullOrWhiteSpace(name)
                              .Trow<ArgumentException>( () => name);
  }
}
```

<h4>Extend Fluent Checker</h4>

The *If* methods are all are implemented in the [Check class] (https://github.com/SimoneLocatelli/FluentChecker/blob/master/FluentChecker/Check.cs).

If you want to extend it, the easiest way is to create a new static class; as long your as your methods return a boolean and you add the FluentChecker namespace, you will be able to concatenate them to the Throw methods (since they are extension methods for the bool type).

```C#

using FluentChecker

//...

  public static class CustomCheck :
  {
  
    public static bool IfCustom()
    {
      // Your custom logic goes here
    }
  }
```

And then to use it:

```C#

using FluentChecker

  public static class Foo
  {
  
    public void DoStuff(string value)
    {
      Check.IfIsNullOrWhiteSpace(value).Throw<ArgumentException>( () => value ); 
      CustomCheck.IfCustom(value).Throw<ArgumentException>( () => value );
      //...
    }
  
  }


```

Easy!

<h4>Nuget</h4>

Fluent Checker is available as Nuget package on [Nuget.org] (https://www.nuget.org/packages/FluentChecker/)

```
  Install-Package FluentChecker
```
