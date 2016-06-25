namespace _64BitArray
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var bitarray = new BitArray64(2000);
            var otherBitArray = new BitArray64(2001);

            Console.WriteLine(bitarray[28]);

            foreach (var bit in bitarray)
            {
                Console.Write(bit + " ");
            }

            Console.WriteLine(Environment.NewLine + (bitarray == otherBitArray));
            Console.WriteLine(bitarray.Equals(otherBitArray));
        }
    }
}