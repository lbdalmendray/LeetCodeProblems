using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadNCharactersGivenRead4II_CallMultipleTimes
{
     /**
     * The Read4 API is defined in the parent class Reader4.
     *     int Read4(char[] buf);
     */

    public class Solution : Reader4
    {
        private LinkedList<char> rest = new LinkedList<char>();

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */
        public int Read(char[] buf, int n)
        {
            if (n < 0)
                throw new ArgumentException("n has to be GT -1");

            int result = 0;
            
            for (int i = 0; n - result > 0 && rest.Count != 0; i++)
            {
                buf[result] = rest.First.Value;
                result++;
                rest.RemoveFirst();
            }

            if (n - result == 0)
                return result;

            char[] auxBuf = new char[4];
            while (n - result > 0)
            {
                int read4Result = Read4(auxBuf);
                if (read4Result == 0)
                    break;

                int maxRead = Math.Min(read4Result, n - result);

                for (int i = 0; i < maxRead; i++)
                {
                    buf[result + i] = auxBuf[i];
                }

                result += maxRead;

                if (maxRead < read4Result)
                {
                    for (int i = maxRead; i < read4Result; i++)
                    {
                        rest.AddLast(auxBuf[i]);
                    }
                }
            }

            return result;            
        }
    }
}
