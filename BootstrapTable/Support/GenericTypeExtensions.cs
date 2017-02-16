using System;

namespace BootstrapTable.Support
{
    internal static class GenericTypeExtensions
    {
        /// <summary>
        /// Determines whether the object is null using the <see cref="Object.ReferenceEquals"/> static method of <see cref="Object"/> class
        /// to avoid using an overwritten operator logic.
        /// </summary>
        /// <typeparam name="TObject">The object type.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns>true if the object is null; otherwise, false.</returns>
        public static bool IsNull<TObject>(this TObject @object)
         where TObject : class
        {
            return Object.ReferenceEquals(@object, null);
        }

        /// <summary>
        /// Determines whether the object is not null using the <see cref="Object.ReferenceEquals"/> static method of <see cref="Object"/> class
        /// to avoid using an overwritten operator logic.
        /// </summary>
        /// <typeparam name="TObject">The object type.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns>true if the object is not null; otherwise, false.</returns>
        public static bool IsNotNull<TObject>(this TObject @object)
            where TObject : class
        {
            return !IsNull(@object);
        }

        /// <summary>
        /// Determines whether the struct value is equals to its defaul value or not.
        /// </summary>
        /// <remarks>
        /// The default value is determined by default(TValue), where TValue is the struct type
        /// </remarks>
        /// <typeparam name="TValue">The struct type.</typeparam>
        /// <param name="value">The struct.</param>
        /// <returns>true if the struct value is equal to its default value; otherwise, false.</returns>
        public static bool IsDefault<TValue>(this TValue value)
            where TValue : struct
        {
            return value.Equals(default(TValue));
        }

        /// <summary>
        /// Converts an object to int type
        /// </summary>
        /// <typeparam name="TObject">Object to convert</typeparam>
        /// <param name="object">Object to convert</param>
        /// <returns>Object converted to int type</returns>
        public static int ToInt<TObject>(this TObject @object)
        {
            return Convert.ToInt32(@object);
        }

        /// <summary>
        /// Converts an object to int or its default value
        /// </summary>
        /// <typeparam name="TObject">Object to convert</typeparam>
        /// <param name="object">Object to convert</param>
        /// <returns>Object converted to int type</returns>
        public static int ToIntOrDefault<TObject>(this TObject @object)
        {
            try
            {
                return Convert.ToInt32(@object);
            }
            catch
            {
                return default(int);
            }
        }

        /// <summary>
        /// Converts an object to double
        /// </summary>
        /// <typeparam name="TObject">Object to convert</typeparam>
        /// <param name="object">Object to convert</param>
        /// <returns>Object converted to double type</returns>
        public static double ToDouble<TObject>(this TObject @object)
        {
            return Convert.ToDouble(@object);
        }

        /// <summary>
        /// Converts an object to double or its default value
        /// </summary>
        /// <typeparam name="TObject">Object to convert</typeparam>
        /// <param name="object">Object to convert</param>
        /// <returns>Object converted to double type</returns>
        public static double ToDoubleOrDefault<TObject>(this TObject @object)
        {
            try
            {
                return Convert.ToDouble(@object);
            }
            catch
            {
                return default(double);
            }
        }

        /// <summary>
        /// Cast a instance to the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>The instance specified</returns>
        public static T As<T>(this object instance) where T : class
        {
            if (instance.IsNull())
            {
                return default(T);
            }

            return instance as T;
        }
    }
}
