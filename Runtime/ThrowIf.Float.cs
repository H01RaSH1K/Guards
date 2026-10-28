using System;
using UnityEngine;

namespace Guards
{
    public static partial class ThrowIf
    {
        [HideInCallstack]
        public static void Nan(float value, string paramName)
        {
            if (float.IsNaN(value))
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be a number.");
        }

        [HideInCallstack]
        public static void NanOrInfinity(float value, string paramName)
        {
            if (float.IsNaN(value) || float.IsInfinity(value))
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be a finite number.");
        }

        [HideInCallstack]
        public static void NegativeOrNan(float value, string paramName)
        {
            if (float.IsNaN(value) || value < 0f)
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be non-negative.");
        }

        [HideInCallstack]
        public static void NegativeOrZeroOrNan(float value, string paramName)
        {
            if (float.IsNaN(value) || value <= 0f)
                throw new ArgumentOutOfRangeException(paramName, value, "Value must be greater than 0.");
        }

        [HideInCallstack]
        public static void LessThanOrNan(float value, float minValueInclusive, string paramName)
        {
            ThrowIfBoundIsNan(minValueInclusive, nameof(minValueInclusive));

            if (float.IsNaN(value) || value < minValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be greater than or equal to {minValueInclusive}."));
        }

        [HideInCallstack]
        public static void GreaterThanOrNan(float value, float maxValueInclusive, string paramName)
        {
            ThrowIfBoundIsNan(maxValueInclusive, nameof(maxValueInclusive));

            if (float.IsNaN(value) || value > maxValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be less than or equal to {maxValueInclusive}."));
        }

        [HideInCallstack]
        public static void OutOfRangeOrNan(float value, float minValueInclusive, float maxValueInclusive, string paramName)
        {
            ThrowIfBoundIsNan(minValueInclusive, nameof(minValueInclusive));
            ThrowIfBoundIsNan(maxValueInclusive, nameof(maxValueInclusive));
            ThrowIfRangeIsInverted(minValueInclusive, maxValueInclusive);

            if (float.IsNaN(value) || value < minValueInclusive || value > maxValueInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, FormattableString.Invariant($"Value must be in range [{minValueInclusive}, {maxValueInclusive}]."));
        }

        [HideInCallstack]
        private static void ThrowIfBoundIsNan(float bound, string boundParamName)
        {
            if (float.IsNaN(bound))
                throw new ArgumentException("Bound must be a number.", boundParamName);
        }

        [HideInCallstack]
        private static void ThrowIfRangeIsInverted(float minValueInclusive, float maxValueInclusive)
        {
            if (minValueInclusive > maxValueInclusive)
                throw new ArgumentException(FormattableString.Invariant($"Min value {minValueInclusive} must be less than or equal to max value {maxValueInclusive}."), nameof(minValueInclusive));
        }
    }
}
