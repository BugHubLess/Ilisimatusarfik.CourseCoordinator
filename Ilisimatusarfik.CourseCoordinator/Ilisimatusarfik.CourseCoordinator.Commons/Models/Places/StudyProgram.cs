using System;
using System.Collections.Generic;

namespace Ilisimatusarfik.CourseCoordinator.Commons.Models.Places
{
    public class StudyProgram
    {
        public int StudyProgramID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Semester> SemesterCourses { get; set; }

        public static implicit operator StudyProgramInternal(StudyProgram input)
        {
            return new StudyProgramInternal
            {
                Description = input.Description,
                Name = input.Name,
                StudyProgramID = input.StudyProgramID,
                SemesterCourses = new Lazy<IList<Semester>>(() => input.SemesterCourses)
            };
        }
    }
}