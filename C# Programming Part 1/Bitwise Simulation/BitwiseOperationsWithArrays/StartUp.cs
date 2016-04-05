namespace BitwiseOperationsWithArrays
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            // Reading 32 bit integer
            int number = int.Parse(Console.ReadLine());

            // Array holding the 32 bits of the number
            var bits = new int[32];

            // NOTE: for 64 bit numbers, the array has a size of 64 and the loop will start to loop from 64 not 32

            // Loop that copies the real bits of number to the array
            for (int i = 0; i < 32; ++i)
            {
                bits[i] = (number >> i) & 1;
            }

            // We have to reverse the bit sequence, because it was copied backwards
            Array.Reverse(bits);

            // Display the bit sequence
            // The print method is not important, it just shows the proper sequence
            PrintBitSequence(bits);

            // TASK: Check if the value of the bit at position p is 1
            int positionToCheck = 3;

            Console.Write($"The bit on position {positionToCheck} is 1 ? ");

            if (bits[positionToCheck] == 1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            Console.WriteLine($"The value of the bit on position {positionToCheck} is {bits[positionToCheck]}");

            // TASK: Swap bits on position 1 and position 2
            // IMPORTANT: THE FIRST BIT IS THE LAST ELEMENT IN THE ARRAY
            // the last element is 31: (n - 1) where n = 32 
            bits[31] ^= bits[30];
            bits[30] ^= bits[31];
            bits[31] ^= bits[30];

            // Another version of swapping process
            // int temp = bits[1];
            // bits[1] = bits[2];
            // bits[2] = temp;

            // TASK: Modify the bit on given position
            // if the position of the bit that we have to modify is 4, the actual position is (n - 1 - positionToModify)
            // that means we have 32 - 1 - 4 = 27 => the position we need to change in our array
            int positionToModify = 4;
            int positionInArrayToModify = 32 - 1 - positionToModify;
            int newBitValue = 1;

            bits[positionInArrayToModify] = newBitValue;

            // CONVERT THE BIT SEQUENCE TO A NUMBER
            // Reverse the bit sequence to its normal state
            PrintBitSequence(bits);
            string binaryString = string.Join(string.Empty, bits);
            int resultNumber = Convert.ToInt32(binaryString, 2);

            Console.WriteLine($"New number: {resultNumber}");
        }

        private static void PrintBitSequence(int[] bits)
        {
            var formattedSequence = new StringBuilder();

            for (int i = 0; i < bits.Length; ++i)
            {
                if (i % 8 == 0)
                {
                    formattedSequence.Append(' ');
                }

                formattedSequence.Append(bits[i]);
            }

            Console.WriteLine(formattedSequence.ToString().Trim());
        }
    }
}