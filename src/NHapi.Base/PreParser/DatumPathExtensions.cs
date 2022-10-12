/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  Some of the original code can be found in "DatumPath.java".

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): James Agnew, Christian Ohr, Jake Aitchison

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/
namespace NHapi.Base.PreParser
{
    using System;
    using System.Text.RegularExpressions;

    using NHapi.Base.Util;

    public static class DatumPathExtensions
    {
        private const int MAXSIZE = 6;

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1310:Field names should not contain underscore",
            Justification = "Because these are constants and not just fields there is a rule clash.")]
        private const string PATH_SPEC_PATTERN =
            @"^(?<segment>[A-Z]{3})(\((?<segmentRepetition>\d+)\))?-((?<fieldNumber>(?:[1-9]|\d\d\d*))(\((?<fieldRepetition>\d+)\))?)(-(?<component>(?:[1-9]|\d\d\d*)))?(-(?<subComponent>(?:[1-9]|\d\d\d*)))?$";

        /// <summary>
        /// <para>
        /// Compares the numeric parts of <paramref name="input"/> and <paramref name="other"/>. "string style", start from
        /// the left: if this[1] &lt; other[1], then return true, if this[1] &gt; other[1] then
        /// return false, else repeat with [2] ... if we compare all elements, then return
        /// false (they're the same.)
        /// </para>
        /// <para>
        /// What are actually compared are copies of this and other that have been grown
        /// to a capacity of 6 (default values in effect), so they'll have the same size.
        /// </para>
        /// <para>
        /// This is just a little thing that gets used in the class XML. Look there for
        /// a justification of it's existence.
        /// </para>
        /// e.g.
        /// <example>
        /// <code>
        /// [1, 1, 1, 1] &lt; [1, 1, 1, 2]
        /// [1, 2, 1, 1] &lt; [1, 2, 1, 2]
        /// [1, 1, 5, 5] &lt; [1, 2]
        /// [1, 1] &lt; [1, 1, 5, 5]
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="input">Current instance of <see cref="DatumPath"/>.</param>
        /// <param name="other">Instance of <see cref="DatumPath"/> to compare to.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="input"/> is null.</exception>
        /// <returns></returns>
        public static bool NumbersLessThan(this DatumPath input, DatumPath other)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (other is null)
            {
                return false;
            }

            var extendedCopyThis = new DatumPath(input);
            extendedCopyThis.ReSize(MAXSIZE);

            var extendedCopyOther = new DatumPath(other);
            extendedCopyOther.ReSize(MAXSIZE);

            var lessThan = false;
            for (var i = 1; !lessThan && (i < MAXSIZE); ++i)
            {
                var thisPathElement = (int)extendedCopyThis.Get(i);
                var otherPathElement = (int)extendedCopyOther.Get(i);
                if (thisPathElement > otherPathElement)
                {
                    break;
                }

                lessThan = thisPathElement < otherPathElement;
            }

            return lessThan;
        }

        /// <summary>
        /// Determines whether this <see cref="DatumPath"/> instance starts with the same
        /// path elements as the specified <see cref="DatumPath"/>.
        /// <example>
        /// <code>
        /// var result = path.StartsWith(otherPath);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="input">The <see cref="DatumPath"/> instance.</param>
        /// <param name="prefix">The <see cref="DatumPath"/> to compare.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="input"/> is null.</exception>
        /// <returns>
        /// <see langword="true" /> if <paramref name="input"/> starts with the same
        /// path elements as <paramref name="prefix"/>; otherwise, <see langword="false" />.
        /// </returns>
        public static bool StartsWith(this DatumPath input, DatumPath prefix)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (prefix is null)
            {
                return false;
            }

            if (input.Size < prefix.Size)
            {
                return false;
            }

            var result = true;
            for (var i = 0; i < prefix.Size; ++i)
            {
                if (i == 0)
                {
                    result &= (string)input.Get(i) == (string)prefix.Get(i);
                    continue;
                }

                result &= (int?)input.Get(i) == (int?)prefix.Get(i);
            }

            return result;
        }

        public static DatumPath FromPathSpec(this string pathSpec)
        {
            if (pathSpec is null)
            {
                throw new ArgumentNullException(nameof(pathSpec));
            }

            var match = Regex.Match(pathSpec, PATH_SPEC_PATTERN);

            if (!match.Success)
            {
                throw new ArgumentException($"Invalid path specification: {pathSpec}", nameof(pathSpec));
            }

            var segment = match.Groups["segment"].Value;
            int.TryParse(match.Groups["segmentRepetition"].Value, out var segmentRepetition);
            int.TryParse(match.Groups["fieldNumber"].Value, out var fieldNumber);
            int.TryParse(match.Groups["fieldRepetition"].Value, out var fieldRepetition);
            int component = int.TryParse(match.Groups["component"].Value, out component) ? component : 1;
            int subComponent = int.TryParse(match.Groups["subComponent"].Value, out subComponent) ? subComponent : 1;

            var result = new DatumPath();
            result.Add(segment)
                .Add(segmentRepetition)
                .Add(fieldNumber)
                .Add(fieldRepetition)
                .Add(component)
                .Add(subComponent);

            return result;
        }

        public static DatumPath FromPathSpecOriginal(this string pathSpec)
        {
            var tokens = new SupportClass.Tokenizer(pathSpec, "-", false);
            var segmentSpec = tokens.NextToken();
            tokens = new SupportClass.Tokenizer(segmentSpec, "()", false);
            var segmentName = tokens.NextToken();

            var segmentRepetition = 0;
            if (tokens.HasMoreTokens())
            {
                var repetition = tokens.NextToken();
                try
                {
                    segmentRepetition = int.Parse(repetition);
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Invalid path specification: {pathSpec}", nameof(pathSpec), e);
                }
            }

            var indices = Terser.GetIndices(pathSpec);

            var result = new DatumPath();
            result.Add(segmentName)
                .Add(segmentRepetition)
                .Add(indices[0])
                .Add(indices[1])
                .Add(indices[2])
                .Add(indices[3]);

            return result;
        }
    }
}