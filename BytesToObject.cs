using System;
using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Text;

namespace Andromeda.Runtime
{
    public static class BytesToObject
    {
        #region Signed integer

        /// <summary>
        /// Gets <see cref="sbyte"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><see cref="sbyte"/> value</returns>
        public static sbyte AsInt8(this ReadOnlySpan<byte> bytes)
            => bytes.AsT(GetSByte, GetSByte);

        /// <summary>
        /// Gets <see cref="short"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="short"/> value</returns>
        public static short AsInt16(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadInt16BigEndian,
            BinaryPrimitives.ReadInt16LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="int"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="int"/> value</returns>
        public static int AsInt32(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadInt32BigEndian,
            BinaryPrimitives.ReadInt32LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="long"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="long"/> value</returns>
        public static long AsInt64(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadInt64BigEndian,
            BinaryPrimitives.ReadInt64LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="Int128"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="Int128"/> value</returns>
        public static Int128 AsInt128(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadInt128BigEndian,
            BinaryPrimitives.ReadInt128LittleEndian,
            endianness
        );

        #endregion

        #region Unsigned integer

        /// <summary>
        /// Gets <see cref="byte"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><see cref="byte"/> value</returns>
        public static byte AsUInt8(this ReadOnlySpan<byte> bytes)
            => bytes.AsT(GetByte, GetByte);

        /// <summary>
        /// Gets <see cref="ushort"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="ushort"/> value</returns>
        public static ushort AsUInt16(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadUInt16BigEndian,
            BinaryPrimitives.ReadUInt16LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="uint"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="uint"/> value</returns>
        public static uint AsUInt32(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadUInt32BigEndian,
            BinaryPrimitives.ReadUInt32LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="ulong"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="ulong"/> value</returns>
        public static ulong AsUInt64(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadUInt64BigEndian,
            BinaryPrimitives.ReadUInt64LittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="UInt128"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="UInt128"/> value</returns>
        public static UInt128 AsUInt128(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadUInt128BigEndian,
            BinaryPrimitives.ReadUInt128LittleEndian,
            endianness
        );

        #endregion

        #region Real number

        /// <summary>
        /// Gets <see cref="Half"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="Half"/> value</returns>
        public static Half AsFloat16(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadHalfBigEndian,
            BinaryPrimitives.ReadHalfLittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="float"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="float"/> value</returns>
        public static float AsFloat32(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadSingleBigEndian,
            BinaryPrimitives.ReadSingleLittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="double"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="double"/> value</returns>
        public static double AsFloat64(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            BinaryPrimitives.ReadDoubleBigEndian,
            BinaryPrimitives.ReadDoubleLittleEndian,
            endianness
        );

        /// <summary>
        /// Gets <see cref="decimal"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="decimal"/> value</returns>
        public static decimal AsDecimal(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => bytes.AsT(
            b => GetDecimal(b, Endianness.BigEndian),
            b => GetDecimal(b, Endianness.LittleEndian),
            endianness
        );

        #endregion

        #region Other object

        /// <summary>
        /// Gets <see cref="Guid"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="Guid"/> value</returns>
        public static Guid AsGuid(
            this ReadOnlySpan<byte> bytes,
            Endianness endianness = Endianness.NotSpecified
        ) => new(
                bytes,
                (
                    endianness == Endianness.NotSpecified
                        ? InteropHelper.SystemEndianness
                        : endianness
                ) == Endianness.BigEndian
            );

        /// <summary>
        /// Gets <see cref="bool"/> value from bytes array.
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="bool"/> value</returns>
        public static bool AsBool(
            this ReadOnlySpan<byte> bytes
        )
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(
                bytes.Length,
                InteropHelper.SizeOf<bool>()
            );

            return bytes[0] != 0;
        }

        /// <summary>
        /// Gets <see cref="string"/> value from bytes array
        /// with required encoding
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="encoding">Encoding</param>
        ///
        /// <returns><see cref="string"/> value</returns>
        public static string AsString(
            this ReadOnlySpan<byte> bytes,
            Encoding? encoding = null
        ) => (encoding ?? Encoding.Default).GetString(bytes.ToArray());

        /// <summary>
        /// Gets system <see cref="string"/> representation
        /// from the bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><see cref="string"/> value</returns>
        public static string? AsOSString(
            this ReadOnlySpan<byte> bytes
        )
        {
            var gcHandle = bytes.ToArray().GetPinnedHandle();
            var result = gcHandle.GetStringAuto();
            gcHandle.Free();

            return result;
        }

        /// <summary>
        /// Gets <typeparamref name="T"/> struct from bytes array.
        /// Uses system byte order
        /// </summary>
        ///
        /// <typeparam name="T">Struct type</typeparam>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><typeparamref name="T"/> value</returns>
        public static T AsStruct<T>(
            this ReadOnlySpan<byte> bytes
        ) where T : struct
            => MemoryMarshal.Read<T>(bytes);

        #endregion

        #region Utils

        /// <summary>
        /// Delegate to describe
        /// <see cref="BinaryPrimitives"/>.ReadXYEndian functions.
        /// Gets <typeparamref name="T"/> value from bytes array
        /// </summary>
        ///
        /// <typeparam name="T">Any type</typeparam>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><typeparamref name="T"/> value</returns>
        private delegate T GetObjectWithEndianness<T>(
            ReadOnlySpan<byte> bytes
        );

        /// <summary>
        /// Gets <see cref="byte"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><see cref="byte"/> value</returns>
        private static byte GetByte(ReadOnlySpan<byte> bytes)
            => bytes[0];

        /// <summary>
        /// Gets <see cref="sbyte"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <returns><see cref="sbyte"/> value</returns>
        private static sbyte GetSByte(ReadOnlySpan<byte> bytes)
            => unchecked((sbyte)bytes[0]);

        /// <summary>
        /// Gets <see cref="decimal"/> value from bytes array
        /// </summary>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><see cref="decimal"/> value</returns>
        private static decimal GetDecimal(
            ReadOnlySpan<byte> bytes,
            Endianness endianness
        )
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(
                bytes.Length,
                InteropHelper.SizeOf<decimal>()
            );

            var fSize = InteropHelper.SizeOf<int>();
            var hSize = InteropHelper.SizeOf<uint>();

            var lo = bytes[(fSize + hSize)..].AsUInt64(endianness);

            var result = new decimal([
                unchecked((int)(lo & 0xFFFF_FFFF)),

                unchecked((int)(lo >> 32)),

                unchecked(
                    (int)bytes[fSize..(fSize + hSize)].AsUInt32(endianness)
                ),

                bytes[..fSize].AsInt32(endianness),
            ]);

            return result;
        }

        /// <summary>
        /// Gets <typeparamref name="T"/> value from bytes array
        /// </summary>
        ///
        /// <typeparam name="T"><c>unmanaged</c> type</typeparam>
        ///
        /// <param name="bytes">Bytes array</param>
        ///
        /// <param name="getObjectBE">Gets Big-Endian value</param>
        ///
        /// <param name="getObjectLE">Gets Little-Endian value</param>
        ///
        /// <param name="endianness">Byte order</param>
        ///
        /// <returns><typeparamref name="T"/> value</returns>
        private static T AsT<T>(
            this ReadOnlySpan<byte> bytes,
            GetObjectWithEndianness<T> getObjectBE,
            GetObjectWithEndianness<T> getObjectLE,
            Endianness endianness = Endianness.NotSpecified
        )
            where T : unmanaged
        {
            ArgumentOutOfRangeException.ThrowIfNotEqual(
                bytes.Length,
                InteropHelper.SizeOf<T>()
            );

            if (endianness == Endianness.NotSpecified)
            {
                endianness = InteropHelper.SystemEndianness;
            }

            return endianness switch
            {
                Endianness.BigEndian => getObjectBE(bytes),

                Endianness.LittleEndian => getObjectLE(bytes),

                _ => throw new ArgumentOutOfRangeException(
                    nameof(endianness)
                ),
            };
        }

        #endregion
    }
}
