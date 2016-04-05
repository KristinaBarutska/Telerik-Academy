/*
    Problem 7. Encode/decode
    Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, 
    the second – with the second, etc. When the last key character is reached, the next is the first.
*/

namespace EncodeDecode
{
    using System;
    using System.Text;

    public class EncodeDecode
    {
        public static void Main()
        {
            string text = "Encode/decode";
            string cipher = "CSharp";

            string encodedText = EncodeText(text, cipher);
            Console.WriteLine($"Encoded: {encodedText}");

            string decodedText = DecodeText(encodedText, cipher);
            Console.WriteLine($"Decoded: {decodedText}");
        }

        private static string EncodeText(string text, string cipher)
        {
            var encodedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                encodedText.Append((char) (text[i] ^ cipher[i % cipher.Length]));
            }

            return encodedText.ToString();
        }

        private static string DecodeText(string encodedText, string cipher)
        {
            return EncodeText(encodedText, cipher);
        }
    }
}