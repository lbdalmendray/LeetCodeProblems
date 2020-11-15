namespace ReadNCharactersGivenRead4II_CallMultipleTimes
{
    public class Reader4
    {
        int currentIndex = 0;

        public static string StringToRead = ""; 

        protected int Read4(char[] buf)
        {
            if (currentIndex == StringToRead.Length)
                return 0;

            int index = 0;
            for (; index < 4 && currentIndex < StringToRead.Length; index++, currentIndex++)
            {
                buf[index] = StringToRead[currentIndex];
            }

            return index;
        }
    }
}