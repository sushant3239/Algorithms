using System;

namespace AngryProfessor
{
    class Solution
    {

        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int numberOfStudents = Convert.ToInt32(tokens_n[0]);
                int threashold = Convert.ToInt32(tokens_n[1]);
                string[] a_temp = Console.ReadLine().Split(' ');
                int[] arrivalTime = Array.ConvertAll(a_temp, int.Parse);
                var studentsInTime = TotalStudentsInTime(arrivalTime, threashold, numberOfStudents);
                var lectureStatus = studentsInTime >= threashold ? "YES" : "NO";
                Console.WriteLine(lectureStatus);
                Console.Read();
            }
        }

        private static int TotalStudentsInTime(int[] arrivalTime, int threashold, int numberOfStudents)
        {
            var studentsInTimeCount = 0;
            for (int i = 0; i < numberOfStudents; i++)
            {
                if (arrivalTime[i] >= 0)
                {
                    studentsInTimeCount += 1;
                }
            }
            return studentsInTimeCount;
        }
    }
}
