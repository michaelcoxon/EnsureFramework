using System.Collections.Concurrent;
using System.Text.RegularExpressions;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class StringAssertions
    {
        private readonly static ConcurrentDictionary<(string regex, RegexOptions options), Regex> _regexCache = new();

        public static IAssertionResult IsNotEmpty(string source)
        {
            if (source == string.Empty)
            {
                return AssertionResult.Fail(Resources.Strings.The_string_is_empty);
            }
            return AssertionResult.Ok;
        }

        public static IAssertionResult IsNotEmptyOrWhiteSpace(string source)
        {
            if (source == string.Empty)
            {
                return AssertionResult.Fail(Resources.Strings.The_string_is_empty);
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (!char.IsWhiteSpace(source[i]))
                {
                    return AssertionResult.Ok;
                }
            }

            return AssertionResult.Fail(Resources.Strings.The_string_is_whitespace);
        }

        public static IAssertionResult Matches(string source, string regex)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            var result = regexEngine.IsMatch(source);

            if (!result)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_string_does_not_match_the_regex_Format, regex));
            }
            return AssertionResult.Ok;
        }

        public static IAssertionResult Matches(string source, string regex, RegexOptions regexOptions)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, regexOptions | RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            var result = regexEngine.IsMatch(source);

            if (!result)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_string_does_not_match_the_regex_Format, regex));
            }
            return AssertionResult.Ok;
        }
    }
}
