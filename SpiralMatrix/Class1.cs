using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            if ( matrix == null || matrix.Length == 0 || matrix[0].Length == 0  )
                return new List<int>();
            
            int n = matrix.Length ;            
            int m = matrix[0].Length ;            

            LinkedList<int> result = new LinkedList<int>();
        
            int x = 0;
            int y = 0;
            
            while( n > 1 && m > 1)
            {
                for( int i = 0 + y ; i < y + m ; i ++)              
                {
                    result.AddLast(matrix[x][i]);                    
                }
                y += m - 1 ;
                for( int i = 1 + x ; i < x + n-1 ; i ++)              
                {
                    result.AddLast(matrix[i][y]);                    
                }
                x+= n-1;
                for( int i = y - 0 ; i > y - m ; i--)
                {
                     result.AddLast(matrix[x][i]);     
                }
                y -= m-1;
                for ( int i = x - 1 ; i > x - ( n - 1 ) ; i--)        
                {
                    result.AddLast(matrix[i][y]);
                }
                x -= (n - 2);
                y++;
                n -= 2;
                m -= 2;                              
            }     

            if( n == 1)
            {
                for( int i = 0 + y ; i < y + m ; i ++)              
                {
                    result.AddLast(matrix[x][i]);                    
                }                
            }
            else if ( m == 1)
            {
                for( int i = 0 + x ; i < x + n ; i ++)              
                {
                    result.AddLast(matrix[i][y]);                    
                }
            }       
            
            return result.ToList();
        }
    }
}
