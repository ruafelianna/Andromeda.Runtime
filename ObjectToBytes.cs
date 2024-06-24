using System;
using System.Buffers.Binary;
using System.Linq;
using System.Text;

namespace Andromeda.Runtime
{
    public static class ObjectToBytes
    {
        #region Integer numbers

        #region Signed

        /// <summary>
        /// Gets array with a single element: byte value
        /// representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="sbyte"/> value to represent as a byte array
        /// </param>
        ///
        /// <returns>
        /// Byte array with single element
        /// </returns>
        public static byte[] GetBytes(this sbyte value)
            => [unchecked((byte)value)];

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="short"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this short value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteInt16BigEndian,
                BinaryPrimitives.WriteInt16LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="int"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this int value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteInt32BigEndian,
                BinaryPrimitives.WriteInt32LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="long"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this long value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteInt64BigEndian,
                BinaryPrimitives.WriteInt64LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="Int128"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this Int128 value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteInt128BigEndian,
                BinaryPrimitives.WriteInt128LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="nint"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this nint value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteIntPtrBigEndian,
                BinaryPrimitives.WriteIntPtrLittleEndian,
                endianness
            );

        #endregion

        #region Unsigned

        /// <summary>
        /// Gets array with a single element: byte value
        /// representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="byte"/> value to represent as a byte array
        /// </param>
        ///
        /// <returns>
        /// Byte array with single element
        /// </returns>
        public static byte[] GetBytes(this byte value)
            => [value];

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="ushort"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this ushort value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteUInt16BigEndian,
                BinaryPrimitives.WriteUInt16LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="uint"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this uint value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteUInt32BigEndian,
                BinaryPrimitives.WriteUInt32LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="ulong"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this ulong value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteUInt64BigEndian,
                BinaryPrimitives.WriteUInt64LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="UInt128"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this UInt128 value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteUInt128BigEndian,
                BinaryPrimitives.WriteUInt128LittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="nuint"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this nuint value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteUIntPtrBigEndian,
                BinaryPrimitives.WriteUIntPtrLittleEndian,
                endianness
            );

        #endregion

        #endregion

        #region Real numbers

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="Half"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this Half value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteHalfBigEndian,
                BinaryPrimitives.WriteHalfLittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="float"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this float value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteSingleBigEndian,
                BinaryPrimitives.WriteSingleLittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="double"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this double value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                BinaryPrimitives.WriteDoubleBigEndian,
                BinaryPrimitives.WriteDoubleLittleEndian,
                endianness
            );

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="decimal"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this decimal value,
            Endianness endianness = Endianness.NotSpecified
        )
            => value.GetBytes(
                (s, v) => GetBytes_Decimal(v, s, Endianness.BigEndian),
                (s, v) => GetBytes_Decimal(v, s, Endianness.LittleEndian),
                endianness
            );

        #endregion

        #region Other objects

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="char"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this char ch,
            Endianness endianness = Endianness.NotSpecified
        ) => ((ushort)ch).GetBytes(endianness);

        /// <summary>
        /// Gets array with byte representation of <paramref name="value"/>
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="bool"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this bool b
        ) => BitConverter.GetBytes(b);

        /// <summary>
        /// Gets array with byte representation of <paramref name="guid"/>
        /// </summary>
        ///
        /// <param name="guid">
        /// <see cref="Guid"/> value to represent as a byte array
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        public static byte[] GetBytes(
            this Guid guid,
            Endianness endianness = Endianness.NotSpecified
        ) => guid.ToByteArray(
                (
                    endianness == Endianness.NotSpecified
                        ? InteropHelper.SystemEndianness
                        : endianness
                ) == Endianness.BigEndian
            );

        /// <summary>
        /// Gets bytes of the <see cref="string"/> value
        /// in required <paramref name="encoding"/>.
        /// If <paramref name="encoding"/> is <see cref="null"/>
        /// <see cref="Encoding.Default"/> is used
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="string"/> value to be represented as bytes
        /// </param>
        ///
        /// <param name="encoding">
        /// Encoding of the <paramref name="value"/>
        /// </param>
        ///
        /// <returns>
        /// Array of bytes in required <paramref name="encoding"/>
        /// </returns>
        public static byte[] GetBytes(
            this string? value,
            Encoding? encoding = null
        ) => value is null
            ? []
            : (encoding ?? Encoding.Default).GetBytes(value);

        #endregion

        #region Utils

        /// <summary>
        /// Gets bytes representation of <paramref name="value"/>.
        /// Delegate type for <see cref="BinaryPrimitives"/>.WriteXYEndian
        /// methods
        /// </summary>
        ///
        /// <typeparam name="T">
        /// Any type
        /// </typeparam>
        ///
        /// <param name="span">
        /// Span to store bytes, starting from the beginning
        /// </param>
        ///
        /// <param name="value">
        /// Value which should be represented as bytes
        /// </param>
        private delegate void GetBytesWithEndianness<T>(
            Span<byte> span,
            T value
        );

        /// <summary>
        /// Gets bytes representation of the <see cref="decimal"/> value
        /// </summary>
        ///
        /// <param name="value">
        /// <see cref="decimal"/> value to represent as bytes
        /// </param>
        ///
        /// <param name="span">
        /// Span to store bytes, starting from the beginning
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        private static void GetBytes_Decimal(
            decimal value,
            Span<byte> span,
            Endianness endianness
        )
        {
            // parts[0], parts[1] = _lo <ulong> [0]=lo, [1]=hi
            // parts[2] = _hi <uint>
            // parts[3] = _flags <int>
            var parts = decimal.GetBits(value);

            var hi = ((ulong)parts[1]) << 32;
            var lo = (ulong)parts[0];

            new byte[][]
            {
                parts[3].GetBytes(endianness),
                unchecked((uint)parts[2]).GetBytes(endianness),
                (hi | lo).GetBytes(endianness),
            }
                .SelectMany(x => x)
                .ToArray()
                .CopyTo(span);
        }

        /// <summary>
        /// Gets bytes representation of the <c>unmanaged</c>
        /// <typeparamref name="T"/> value
        /// </summary>
        ///
        /// <typeparam name="T">
        /// <c>unmanaged</c> type
        /// </typeparam>
        ///
        /// <param name="value">
        /// <typeparamref name="T"/> value to be represented as bytes
        /// </param>
        ///
        /// <param name="getBytesBE">
        /// Function to get bytes representation as Big-Endian
        /// </param>
        ///
        /// <param name="getBytesLE">
        /// Function to get bytes representation as Little-Endian
        /// </param>
        ///
        /// <param name="endianness">
        /// Byte order
        /// </param>
        ///
        /// <returns>
        /// Byte array
        /// </returns>
        private static byte[] GetBytes<T>(
            this T value,
            GetBytesWithEndianness<T> getBytesBE,
            GetBytesWithEndianness<T> getBytesLE,
            Endianness endianness = Endianness.NotSpecified
        )
            where T : unmanaged
        {
            var buffer = new byte[InteropHelper.SizeOf<T>()];

            if (endianness == Endianness.NotSpecified)
            {
                endianness = InteropHelper.SystemEndianness;
            }

            switch (endianness)
            {
                case Endianness.BigEndian:
                    getBytesBE(buffer, value);
                    break;
                case Endianness.LittleEndian:
                    getBytesLE(buffer, value);
                    break;
            }

            return buffer;
        }

        #endregion
    }
}
