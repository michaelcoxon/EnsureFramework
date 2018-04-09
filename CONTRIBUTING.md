# Contributing to EnsureFramwork

I am open to contributions as long as the following conditions are met:-

 - `System.Diagnostics.DebuggerNonUserCodeAttribute` is used on every 
   extension method that throws an exception.

 - Code re-use is thrown out the window. Each extension method should be 
   self-contained and not use any other extension method. This is super
   important so that assertions aren't broken if one needs to be changed.

   > I do realise that this is an antipattern to some, but in this case my decision 
   cannot be changed. This decision has been made for the integrity of the project

 - You write tests for your extension methods. These tests need to cover as many cases
   as you feel worthy. Keep in mind that the premise of this project is to simplify
   argument checking - something that happens a lot - so make sure your code is solid 
   and simple.

 - You write XML documentation on all public methods and classes you write. A library
   is pointless without documentation regardless of how 'simple to use' or 'self documenting'
   your methods are.

 - Read to classes already defined in the project. Follow the coding style already used 
   even if you disagree with it. It will keep the codebase maintainable.


Thank you for your interest in contributing to this project!