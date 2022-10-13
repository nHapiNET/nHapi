/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "DatumPath.java".

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): James Agnew, Jake Aitchison

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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// <para>
    /// An object of this class represents a variable-size path for identifying
    /// the location of a datum within an HL7 message, which we can use for
    /// maintaining parser state and for generating a suitable string key (in the
    /// <c>ZYX[a]-b[c]-d-e</c> style) for a piece of data in the message (see <see cref="ToString" />).
    /// </para>
    /// <para>
    /// The elements are:
    /// segmentID / segmentRepIdx / fieldIdx / fieldRepIdx / compIdx / subcompIdx
    /// ("rep" means "repetition").
    /// </para>
    /// <para>
    /// segmentID is a <see cref="string"/>, the rest are <see cref="int"/>.
    /// </para>
    /// <para>
    /// It is variable-size path-style in that if it has a size of 1, the one element
    /// will be the segmentID; if it has a size of two, element 0 will be the segmentID
    /// and element 1 will be the segmentRepIdx, etc.  This class can't represent a
    /// fieldIdx without having segmentID / segmentRepIdx, etc. etc.
    /// </para>
    /// <para>
    /// Possible sizes: 0 to 6 inclusive.
    /// </para>
    /// <para>
    /// As <see cref="ToString" /> simply converts this' integer values to strings <c>(1 => "1")</c>, and
    /// since for some reason the <c>ZYX[a]-b[c]-d-e</c> style counts b, d, e starting from 1
    /// and a, c from 0 -- it is intended that one store the numeric values in this
    /// class starting from 1 for fieldIdx (element 2), compIdx (4) and subcompIdx
    /// (5), and from 0 for segmentRepIdx (1) and fieldRepIdx (3).
    /// </para>
    /// <para>
    /// Default values provided by <see cref="ReSize" /> and by <see cref="ToString" /> do this.
    /// </para>
    /// </summary>
    public class DatumPath : IEquatable<DatumPath>, ICloneable
    {
        private const int MAXSIZE = 6;

        private readonly List<object> path;

        /// <summary>
        /// Creates a new instance of the <see cref="DatumPath"/> class.
        /// </summary>
        public DatumPath()
        {
            this.path = new List<object>(MAXSIZE);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DatumPath"/> class from the values of another instance.
        /// </summary>
        /// <param name="other"></param>
        public DatumPath(DatumPath other)
            : this()
        {
            this.Copy(other);
        }

        /// <summary>
        /// Gets the number of elements in the path.
        /// </summary>
        public int Size => this.path.Count;

        public static bool operator ==(DatumPath left, DatumPath right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(DatumPath left, DatumPath right)
        {
            return !(left == right);
        }

        /// <summary>
        /// <para>
        /// Grows <see cref="DatumPath"/> by 1, inserting <paramref name="newValue"/> at the end.
        /// </para>
        /// <para>
        /// <paramref name="newValue" /> must be a <see cref="string"/> or an <see cref="int"/>
        /// depending on the index where it will be inserted, as noted at <see cref="Set(int, int?)"/>.
        /// </para>
        /// <para>
        /// If being inserted at index 0 then the type of <paramref name="newValue"/> must be a <see cref="string"/>
        /// otherwise it must be an <see cref="int" />.
        /// </para>
        /// <example>
        /// This method can be chained:
        /// <code>
        /// path.Add("ZYX").Add(1).Add(2);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="newValue"></param>
        /// <exception cref="ArgumentOutOfRangeException">If <see cref="Size"/> is already equal to 6.</exception>
        /// <exception cref="InvalidOperationException">If <see cref="Size"/> is less then 1.</exception>
        /// <returns>this.</returns>
        public DatumPath Add(int newValue)
        {
            if (this.Size < 1)
            {
                throw new InvalidOperationException("Cannot add value type of int to a DatumPath with no elements.");
            }

            if (this.Size == MAXSIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(Size), "Cannot add value to a DatumPath with 6 elements.");
            }

            this.path.Add(newValue);

            return this;
        }

        /// <summary>
        /// <para>
        /// Grows <see cref="DatumPath"/> by 1, inserting <paramref name="newValue"/> at the end.
        /// </para>
        /// <para>
        /// <paramref name="newValue" /> must be a <see cref="string"/> or an <see cref="int"/>
        /// depending on the index where it will be inserted, as noted at <see cref="Set(int, string)"/>.
        /// </para>
        /// <para>
        /// If being inserted at index 0 then the type of <paramref name="newValue"/> must be a <see cref="string"/>
        /// otherwise it must be an <see cref="int" />.
        /// </para>
        /// <example>
        /// This method can be chained:
        /// <code>
        /// path.Add("ZYX").Add(1).Add(2);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns>this.</returns>
        /// <exception cref="InvalidOperationException">If <see cref="Size"/> is not equal to 0.</exception>
        public DatumPath Add(string newValue)
        {
            if (this.Size != 0)
            {
                throw new InvalidOperationException("Cannot add value type of string to a DatumPath which already contains elements.");
            }

            this.path.Add(newValue);

            return this;
        }

        /// <summary>
        /// Gets an element of the path at the specified index.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The type of the value returned is determined by the index.
        /// </para>
        /// <para>
        /// If the index equal to 0 then the value returned is a <see cref="string"/>.
        /// </para>
        /// <para>
        /// If the index is greater than 1 then the value returned is a <see cref="int"/>.
        /// </para>
        /// </remarks>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index specified is less than 0 or greater than <see cref="Size"/>.
        /// </exception>
        public object Get(int index)
        {
            return this.path[index];
        }

        /// <summary>
        /// Sets an element of the path, at the specified index.
        /// </summary>
        /// <param name="index">Location to add element.</param>
        /// <param name="newValue">Value to add.</param>
        /// <exception cref="ArgumentException">When attempting to set an int value to index position 0.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="newValue"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="index" /> is less than 0 or greater than or equal to <see cref="Size"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">if <paramref name="index" /> is greater than 6.</exception>
        public void Set(int index, int? newValue)
        {
            if (index > MAXSIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(Size), "Cannot add value to a DatumPath with 6 elements.");
            }

            if ((index < 0) || (index >= this.path.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                throw new ArgumentException("When setting the value at index 0 the value must be of type string", nameof(index));
            }

            this.path[index] = newValue ?? throw new ArgumentNullException(nameof(newValue));
        }

        /// <summary>
        /// Sets an element of the path, at the specified index.
        /// </summary>
        /// <param name="index">Location to add element.</param>
        /// <param name="newValue">Value to add.</param>
        /// <exception cref="ArgumentException">When attempting to set a string value to index position other than 0.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="newValue"/> is null.</exception>
        public void Set(int index, string newValue)
        {
            if (index != 0)
            {
                throw new ArgumentException("When setting a value of type string you can only supply an index of 0", nameof(index));
            }

            this.path[index] = newValue ?? throw new ArgumentNullException(nameof(newValue));
        }

        /// <summary>
        /// <para>
        /// Resize the <see cref="DatumPath"/>.
        /// </para>
        /// <para>
        /// If <paramref name="newSize"/> is greater than the current
        /// size, then the new elements are set to default values.
        /// </para>
        /// <para>
        /// Then we put default values into the new elements: i.e. <see cref="string.Empty"/>
        /// into the string element, 1 into the elements 2, 4, and 5, and 0 into elements 1 and 3.
        /// </para>
        /// <para>
        /// If <paramref name="newSize"/> is less than the current size, then the last elements are removed.
        /// </para>
        /// </summary>
        /// <param name="newSize">The desired size for the path.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="newSize" /> is greater than 6.</exception>
        /// <returns>this.</returns>
        public DatumPath ReSize(int newSize)
        {
            if (newSize > MAXSIZE)
            {
                throw new ArgumentOutOfRangeException(nameof(Size), "DatumPath cannot contain more than 6 elements.");
            }

            var oldSize = this.path.Count;

            while (this.path.Count < newSize)
            {
                this.path.Add(null);
            }

            while (this.path.Count > newSize)
            {
                this.path.RemoveAt(this.path.Count - 1);
            }

            if (newSize <= oldSize)
            {
                return this;
            }

            // give the new elements some default values:
            for (var i = oldSize; i < newSize; ++i)
            {
                if (i == 0)
                {
                    this.Set(i, string.Empty);
                }
                else
                {
                    this.Set(i, (i == 1 || i == 3) ? 0 : 1);
                }
            }

            return this;
        }

        /// <summary>
        /// Resets the <see cref="DatumPath"/> to the default state.
        /// </summary>
        /// <returns></returns>
        public DatumPath Clear()
        {
            this.ReSize(0);
            return this;
        }

        /// <summary>
        /// Clones the <see cref="DatumPath"/>.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new DatumPath(this);
        }

        /// <summary>
        /// Copy the path elements from the specified <see cref="DatumPath"/>.
        /// </summary>
        /// <param name="other">The instance of <see cref="DatumPath"/> to copy path elements from.</param>
        /// <exception cref="InvalidOperationException">
        /// If the values of the <paramref name="other" /> are not of the expected types (either <see cref="string"/> or <see cref="int"/>).
        /// </exception>
        public void Copy(DatumPath other)
        {
            this.ReSize(0);
            for (var i = 0; i < other.Size; ++i)
            {
                var pathElement = other.Get(i);
                switch (pathElement)
                {
                    case int intValue:
                        this.Add(intValue);
                        break;
                    case string stringValue:
                        this.Add(stringValue);
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected type in DatumPath.Copy: {pathElement?.GetType()}");
                }
            }
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="DatumPath"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Outputs the path (from segmentID onward) in the <c>ZYX[a]-b[c]-d-e</c>
        /// style (TODO: give it a name), suitable for a key in a map of message datum paths to values.
        /// </para>
        /// <para>
        /// Integer values are converted to strings directly <c>(1 => "1")</c> so when you
        /// constructed this you should have started counting from 1 for everything but
        /// the "repeat" fields, if you truly want the <c>ZYX[a]-b[c]-d-e</c> style.
        /// </para>
        /// <para>
        /// If <see cref="ToString"/> is called when this has a size in [1, 6) (=> missing numeric
        /// elements), then we act as though the elements in [size(), 6) are 0 or 1 as
        /// appropriate for each element.  We don't provide a default for the element 0.
        /// </para>
        /// <example>
        /// <code>
        /// new DatumPath().Add("ZYX").Add(2).Add(6).ToString();
        /// </code>
        /// Would yield "ZYX[2]-6[0]-1-1"
        /// </example>
        /// </remarks>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.path.Count < 1)
            {
                return "???[?]-?[?]-?-?";
            }

            var builder = new StringBuilder();

            var extendedCopy = (DatumPath)this.Clone();
            extendedCopy.ReSize(MAXSIZE);

            for (var i = 0; i < extendedCopy.Size; ++i)
            {
                if (i == 0)
                {
                    builder.Append(extendedCopy.Get(i));
                }
                else if (i is 1 or 3)
                {
                    builder.Append("[").Append(extendedCopy.Get(i)).Append("]");
                }
                else if (i is 2 or 4 or 5)
                {
                    builder.Append("-").Append(extendedCopy.Get(i));
                }
            }

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != typeof(DatumPath))
            {
                return false;
            }

            var other = (DatumPath)obj;

            return this.path.SequenceEqual(other.path);
        }

        public override int GetHashCode()
        {
            return path != null ? path.GetHashCode() : 0;
        }

        public bool Equals(DatumPath other)
        {
            return Equals((object)other);
        }
    }
}