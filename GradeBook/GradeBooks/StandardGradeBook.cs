using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    
    public class StandardGradeBook : BaseGradeBook
    {
       
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Standard;
        }

      
        public override char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return 'A';
            if (averageGrade >= 80)
                return 'B';
            if (averageGrade >= 70)
                return 'C';
            if (averageGrade >= 60)
                return 'D';
            return 'F';
        }
    }
}
