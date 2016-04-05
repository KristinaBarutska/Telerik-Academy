namespace AppearanceCount
{
    public static class AppearanceCounter<T>
    {
        public static int CountAppearances(T[] numbers, T number)
        {
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Equals(number))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}