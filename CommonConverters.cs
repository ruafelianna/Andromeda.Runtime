using System;
using System.Numerics;

namespace Andromeda.Runtime
{
    public static class CommonConverters
    {
        /// <summary>
        /// Converts <see cref="IBinaryInteger{TSelf}"/> number to enum value
        /// </summary>
        ///
        /// <typeparam name="TEnum">
        /// Enum type
        /// </typeparam>
        ///
        /// <typeparam name="TNumber">
        /// Number type
        /// </typeparam>
        ///
        /// <param name="value">
        /// A value to convert to <typeparamref name="TEnum"/> value
        /// </param>
        ///
        /// <returns>
        /// Converted <typeparamref name="TEnum"/> value
        /// </returns>
        ///
        /// <exception cref="InvalidCastException">
        /// Such <typeparamref name="TEnum"/> value is not defined
        /// </exception>
        public static TEnum ToEnum<TEnum, TNumber>(this TNumber value)
            where TEnum : Enum
            where TNumber : IBinaryInteger<TNumber>
            => ConvertToEnum(value, o => (TEnum)(o as object));

        /// <summary>
        /// Converts a <see cref="string"/> value to <typeparamref name="TEnum"/> value
        /// </summary>
        ///
        /// <typeparam name="TEnum">
        /// Enum type
        /// </typeparam>
        ///
        /// <param name="value">
        /// A <see cref="string"/> value to convert to <typeparamref name="TEnum"/> value
        /// </param>
        ///
        /// <returns>
        /// Converted <typeparamref name="TEnum"/> value
        /// </returns>
        ///
        /// <exception cref="InvalidCastException">
        /// Such <typeparamref name="TEnum"/> value is not defined
        /// </exception>
        public static TEnum ToEnum<TEnum>(this string value)
            where TEnum : Enum
            => ConvertToEnum(value, o => (TEnum)Enum.Parse(typeof(TEnum), o));

        /// <summary>
        /// Checks if <typeparamref name="TEnum"/> value is defined.
        /// Converts <paramref name="value"/> to <typeparamref name="TEnum"/> value
        /// using <paramref name="conv"/> function if the value is defined,
        /// and throws exception otherwise
        /// </summary>
        ///
        /// <typeparam name="TEnum">
        /// Enum type
        /// </typeparam>
        ///
        /// <typeparam name="TObj">
        /// 'Value to convert' type
        /// </typeparam>
        ///
        /// <param name="value">
        /// A <typeparamref name="TObj"/> value to convert to <typeparamref name="TEnum"/> value
        /// </param>
        ///
        /// <param name="conv">
        /// Function which is able to convert a <typeparamref name="TObj"/> value to <typeparamref name="TEnum"/> value
        /// </param>
        ///
        /// <returns>
        /// Converted <typeparamref name="TEnum"/> value
        /// </returns>
        ///
        /// <exception cref="InvalidCastException">
        /// Such <typeparamref name="TEnum"/> value is not defined
        /// </exception>
        private static TEnum ConvertToEnum<TEnum, TObj>(
            TObj value,
            Func<TObj, TEnum> conv
        ) where TObj : notnull
            => Enum.IsDefined(typeof(TEnum), value)
                ? conv(value)
                : throw new InvalidCastException(
                    $"Enum value <{value}> is not defined in {typeof(TEnum).AssemblyQualifiedName}"
                );
    }
}
