using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var sortedGrades = Students.OrderByDescending(s => s.AverageGrade).ToList();

            int studentsInEachPercentile = (int)Math.Ceiling(Students.Count / 5.0);

            for (int i = 0; i < 5; i++)
            {
                int gradeStartIndex = i * studentsInEachPercentile;
                int gradeEndIndex = (i + 1) * studentsInEachPercentile - 1;

                gradeEndIndex = Math.Min(gradeEndIndex, sortedGrades.Count - 1);

                if (sortedGrades[gradeEndIndex].AverageGrade <= averageGrade)
                {
                    switch (i)
                    {
                        case 0:
                            return 'A';
                        case 1:
                            return 'B';
                        case 2:
                            return 'C';
                        case 3:
                            return 'D';
                        default:
                            return 'F';
                    }
                }
            }

            return 'F';
        }
    public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
