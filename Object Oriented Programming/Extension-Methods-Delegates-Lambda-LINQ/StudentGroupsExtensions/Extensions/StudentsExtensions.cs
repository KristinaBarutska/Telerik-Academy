namespace StudentGroupsExtensions.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Student;

    public static class StudentsExtensions
    {
        public static List<Student> GetStudentsFromGroup(this List<Student> students, int groupNumber)
        {
            var filteredStudents = (from student in students
                                    where student.GroupNumber == groupNumber
                                    orderby student.FirstName
                                    select student).ToList();

            return filteredStudents;
        }
    }
}