using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Andromeda.Runtime
{
    public static class InteropHelper
    {
        #region Handles

        /// <summary>
        /// Gets pinned GC Handle for <paramref name="input"/>
        /// </summary>
        ///
        /// <param name="input">Object for which it's required to get handle</param>
        ///
        /// <returns>GC handle for <paramref name="input"/></returns>
        public static GCHandle GetPinnedHandle(this object? input)
            => GCHandle.Alloc(
                input,
                GCHandleType.Pinned
            );

        /// <summary>
        /// Gets string from a pinned GC handle adress.
        /// Encoding is chosen automatically
        /// </summary>
        ///
        /// <param name="handle">Pinned GC handle</param>
        ///
        /// <returns>Managed string</returns>
        public static string? GetStringAuto(this GCHandle handle)
            => Marshal.PtrToStringAuto(handle.AddrOfPinnedObject());

        /// <summary>
        /// Gets <c>unmanaged</c> object from pinned GC handle address
        /// </summary>
        ///
        /// <typeparam name="T"><c>unmanaged</c> type</typeparam>
        ///
        /// <param name="handle">Pinned GC handle</param>
        ///
        /// <returns>Object of <c>unmanaged</c> type <typeparamref name="T"/></returns>
        public static T GetStruct<T>(this GCHandle handle)
            where T : unmanaged
            => Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());

        /// <summary>
        /// Copies bytes from pinned GC handle address
        /// </summary>
        ///
        /// <param name="handle">Pinned GC handle</param>
        ///
        /// <param name="size">Number of bytes to copy</param>
        ///
        /// <returns>Array of copied bytes</returns>
        public static byte[] CopyBytes(this GCHandle handle, int size)
        {
            var result = new byte[size];
            Marshal.Copy(handle.AddrOfPinnedObject(), result, 0, size);
            return result;
        }

        #endregion

        #region Endianness

        /// <summary>
        /// Checks if endianness should be changed
        /// </summary>
        ///
        /// <param name="endianness">Endianness to check</param>
        ///
        /// <returns>
        /// Whether <paramref name="endianness"/> is the same
        /// as the system one
        /// </returns>
        public static bool ShouldReverseEndianness(
            Endianness endianness = Endianness.NotSpecified
        ) => endianness != Endianness.NotSpecified
            && endianness != (
                BitConverter.IsLittleEndian
                ? Endianness.LittleEndian
                : Endianness.BigEndian
            );

        #endregion

        #region Size

        /// <summary>
        /// Gets managed size of an <c>unmanaged</c> type
        /// </summary>
        ///
        /// <typeparam name="T"><c>unmanaged</c> type</typeparam>
        ///
        /// <returns>Managed size of the type</returns>
        ///
        /// <exception cref="NotSupportedException">
        /// Is thrown when <paramref name="type"/> is not undentified
        /// </exception>
        public static int SizeOf<T>()
            where T : unmanaged
            => SizeOf(typeof(T));

        /// <summary>
        /// Recursively gets managed size of an <c>unmanaged</c> type
        /// </summary>
        ///
        /// <param name="type"><c>unmanaged</c> type</param>
        ///
        /// <returns>Managed size of the <paramref name="type"/></returns>
        ///
        /// <exception cref="NotSupportedException">
        /// Is thrown when <paramref name="type"/> is not undentified
        /// </exception>
        private static int SizeOf(Type type)
        {
            if (type == typeof(byte)) return sizeof(byte);
            if (type == typeof(sbyte)) return sizeof(sbyte);
            if (type == typeof(ushort)) return sizeof(ushort);
            if (type == typeof(short)) return sizeof(short);
            if (type == typeof(uint)) return sizeof(uint);
            if (type == typeof(int)) return sizeof(int);
            if (type == typeof(ulong)) return sizeof(ulong);
            if (type == typeof(long)) return sizeof(long);
            if (type == typeof(UInt128)) return 16;
            if (type == typeof(Int128)) return 16;
            if (type == typeof(Half)) return 2;
            if (type == typeof(float)) return sizeof(float);
            if (type == typeof(double)) return sizeof(double);
            if (type == typeof(decimal)) return sizeof(decimal);
            if (type == typeof(char)) return sizeof(char);
            if (type == typeof(bool)) return sizeof(bool);

            nint id = type.TypeHandle.Value;
            if (!SizeOfDict.TryGetValue(id, out int len))
            {
                if (type.IsEnum)
                {
                    len = SizeOf(Enum.GetUnderlyingType(type));
                }
                else if (type.IsPointer || type == typeof(nint) || type == typeof(nuint))
                {
                    len = Marshal.SizeOf(type);
                }
                else if (type.IsPrimitive)
                {
                    throw new NotSupportedException("This type is not supported.");
                }
                else
                {
                    len = type
                        .GetFields(
                            BindingFlags.Instance
                            | BindingFlags.Public
                            | BindingFlags.NonPublic
                        )
                        .Select(x => SizeOf(x.FieldType))
                        .Sum();
                }

                SizeOfDict.Add(id, len);
            }
            return len;
        }

        /// <summary>
        /// Dictionary to store already known type sizes
        /// </summary>
        private static readonly Dictionary<nint, int> SizeOfDict = [];

        #endregion
    }
}
