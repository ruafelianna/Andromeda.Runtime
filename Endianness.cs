namespace Andromeda.Runtime
{
    /// <summary>
    /// Order of bytes
    /// </summary>
    public enum Endianness : byte
    {
        /// <summary>
        /// Use system endianness
        /// </summary>
        NotSpecified = 0,

        /// <summary>
        /// The least significant byte of a word at the smallest memory address
        /// and the most significant byte at the largest
        /// </summary>
        LittleEndian = 1,

        /// <summary>
        /// The most significant byte of a word at the smallest memory address
        /// and the least significant byte at the largest
        /// </summary>
        BigEndian = 2,
    }
}
