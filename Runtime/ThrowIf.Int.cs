using System;
using UnityEngine;

namespace Guards
{
    public static partial class ThrowIf
    {
        [HideInCallstack]
        public static void Zero(int value, string paramName)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException(paramName, value, "Value must not be 0.");
        }

        [HideInCallstack]
        public static void Negative(int value, string paramName)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be non-negative.");
        }

        [HideInCallstack]
        public static void NegativeOrZero(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be greater than 0.");
        }

        [HideInCallstack]
        public static void LessThan(int value, int minValueInclusive, string paramName)
        {
            if (value < minValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be greater than or equal to {minValueInclusive}."));
        }

        [HideInCallstack]
        public static void GreaterThan(int value, int maxValueInclusive, string paramName)
        {
            if (value > maxValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be less than or equal to {maxValueInclusive}."));
        }

        [HideInCallstack]
        public static void OutOfRange(int value, int minValueInclusive, int maxValueInclusive, string paramName)
        {
            ThrowIfRangeIsInverted(minValueInclusive, maxValueInclusive);

            if (value < minValueInclusive || value > maxValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be in range [{minValueInclusive}, {maxValueInclusive}]."));
        }

        [HideInCallstack]
        public static void IndexOutOfRange(int index, int count, string paramName)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(paramName, index, FormattableString.Invariant($"Index must be in range [0, {count})."));
        }

        [HideInCallstack]
        private static void ThrowIfRangeIsInverted(int minValueInclusive, int maxValueInclusive)
        {
            if (minValueInclusive > maxValueInclusive)
                throw new ArgumentException(FormattableString.Invariant($"Min value {minValueInclusive} must be less than or equal to max value {maxValueInclusive}."), nameof(minValueInclusive));
        }
    }
}
