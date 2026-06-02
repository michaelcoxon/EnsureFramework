namespace EnsureFramework.ArgumentAssertionBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerNonUserCode]
    internal sealed record ArgumentAssertionBuilder<T>([DisallowNull] T Argument, string? ArgumentName, List<string> PassedAssertions) : IArgumentAssertionBuilder<T>;
}
