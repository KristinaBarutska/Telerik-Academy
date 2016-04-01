/*
    Problem 2. Bonus Score
    Write a program that applies bonus score to given score in the range [1…9] by the following rules:
    If the score is between 1 and 3, the program multiplies it by 10.
    If the score is between 4 and 6, the program multiplies it by 100.
    If the score is between 7 and 9, the program multiplies it by 1000.
    If the score is 0 or more than 9, the program prints “invalid score”.
*/

namespace BonusScore
{
    using System;

    public class BonusScore
    {
        private static void Main()
        {
            Console.Write("Score : ");
            int score = int.Parse(Console.ReadLine());

            if (score < 0 || score > 9)
            {
                Console.WriteLine("Invalid score");
            }
            else
            {
                Console.WriteLine(ApplyBonusScore(score));
            }
        }

        private static int ApplyBonusScore(int score)
        {
            if (score >= 1 && score <= 3)
            {
                return score * 10;
            }
            else if (score >= 4 && score <= 6)
            {
                return score * 100;
            }
            else
            {
                return score * 1000;
            }
        }
    }
}