using System;
using UnityEngine;

namespace Guards
{
    public static partial class ThrowIf
    {
        [HideInCallstack]
        public static void Null<T>(T value, string paramName) where T : class
        {
            if (value is null || (value is UnityEngine.Object unityObject && unityObject == null))
                throw new ArgumentNullException(paramName);
        }
    }
}
