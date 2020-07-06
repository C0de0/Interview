using System;

namespace Interview.Utilities
{
    public static class Assert
    {
        public static T NotNull<T>(string propName, T value) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(propName);
            return value;
        }
    }
}
