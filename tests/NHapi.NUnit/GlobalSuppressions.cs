// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "StyleCop.CSharp.ReadabilityRules",
    "SA1124:Do not use regions",
    Justification = "Allow regions in unit test projects because it improves readability.")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.OrderingRules",
    "SA1201:Elements should appear in the correct order",
    Justification = "Allow different ordering in unit test projects to improve organization and readability.")]

[assembly: SuppressMessage(
    "StyleCop.CSharp.OrderingRules",
    "SA1202:Elements should be ordered by access",
    Justification = "Allow different ordering in unit test projects to improve organization and readability.")]
