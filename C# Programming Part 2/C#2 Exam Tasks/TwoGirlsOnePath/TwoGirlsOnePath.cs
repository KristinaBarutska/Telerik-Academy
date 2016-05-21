namespace TwoGirlsOnePath
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class TwoGirlsOnePath
    {
        public static void Main()
        {
            int[] path = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int mollyIndex = 0;
            int dollyIndex = path.Length - 1;
            string winner = string.Empty;

            BigInteger mollyTotalFlowers = 0;
            BigInteger dollyTotalFlowers = 0;

            while (true)
            {
                int currentMollyFlowers = 0;
                int currentDollyFlowers = 0;
                
                if (mollyIndex == dollyIndex)
                {
                    int halfFlowers = path[mollyIndex] / 2;

                    path[mollyIndex] %= 2;
                    currentMollyFlowers = halfFlowers;
                    currentDollyFlowers = halfFlowers;
                }
                else
                {
                    currentMollyFlowers = path[mollyIndex];
                    path[mollyIndex] = 0;

                    currentDollyFlowers = path[dollyIndex];
                    path[dollyIndex] = 0;
                }

                mollyTotalFlowers += currentMollyFlowers;
                dollyTotalFlowers += currentDollyFlowers;

                int nextMollyPosition = GetMollyNextPosition(mollyIndex, currentMollyFlowers, path.Length);
                int nextDollyPosition = GetDollyNextPosition(dollyIndex, currentDollyFlowers, path.Length);

                if (path[nextMollyPosition] == 0)
                {
                    winner = "Dolly";
                    dollyTotalFlowers += path[nextDollyPosition];
                    break;
                }
                else if (path[nextDollyPosition] == 0)
                {
                    winner = "Molly";
                    mollyTotalFlowers += path[nextMollyPosition];
                    break;
                }
                else if (path[nextMollyPosition] == 0 && path[nextDollyPosition] == 0)
                {
                    winner = "Draw";
                    break;
                }
                
                mollyIndex = nextMollyPosition;
                dollyIndex = nextDollyPosition;
            }

            Console.WriteLine(winner);
            Console.WriteLine("{0} {1}", mollyTotalFlowers, dollyTotalFlowers);
        }

        private static int GetMollyNextPosition(int currentIndex, int currentFlowers, int pathLength)
        {
            return (currentIndex + currentFlowers) % pathLength;
        }

        private static int GetDollyNextPosition(int currentPosition, int currentFlowers, int pathLength)
        {
            int nextPosition = (currentPosition - currentFlowers) % pathLength;

            if (nextPosition < 0)
            {
                nextPosition = pathLength + nextPosition;
            }

            return nextPosition;
        }
    }
}