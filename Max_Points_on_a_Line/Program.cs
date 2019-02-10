using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Points_on_a_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[]
            {
                new Point(1,3),
                new Point(2,6),
                new Point(3,3),
            };

            Solution s = new Solution();
            var result = s.MaxPoints(points);
            Console.WriteLine(result != 2 ? "MAL": result.ToString());
            Console.ReadLine();

            //////////////////////////////////////////////

            points = new Point[]
            {

            };

            s = new Solution();
            result = s.MaxPoints(points);
            Console.WriteLine(result != 0 ? "MAL" : result.ToString());

            Console.ReadLine();


            //////////////////////////////////////////////

            points = new Point[]
            {
                new Point(1,3),

            };

            s = new Solution();
            result = s.MaxPoints(points);
            Console.WriteLine(result != 1 ? "MAL" : result.ToString());

            Console.ReadLine();



            //////////////////////////////////////////////

            points = new Point[]
            {
                new Point(1,3),
                new Point(100,3),
                new Point(90,3),
                //new Point(4,3),
                //new Point(5,3),
                new Point(5,3),
                new Point(80,2),
                new Point(40,1),
                new Point(400,10),
                new Point(4000,100),
                new Point(40000,1000),

            };

            s = new Solution();
            result = s.MaxPoints(points);
            Console.WriteLine(result != 5 ? "MAL" : result.ToString());

            Console.ReadLine();

            //////////////////////////////////////////////

            points = new Point[]
            {
                new Point(0,0),
                new Point(94911151,94911150),
                new Point(94911152,94911151)

            };
            int v1 = 94911151;
            double v1d = (double)v1;
            double r1 = 94911150.0 / 94911151.0;
            double r2 = 94911150.0 * 94911151.0;
            double r3 = 94911151.0 / 94911152.0;
            double r4 = 94911151.0 * 94911152.0;

            bool e1 = r1 == r3; 
            bool e2 = r2 == r4;

            s = new Solution();
            result = s.MaxPoints(points);
            Console.WriteLine(result != 2 ? "MAL" : result.ToString());

            Console.ReadLine();
            //[[0,0],[94911151,94911150],[94911152,94911151]]

        }
    }
}
