namespace GroupedByGroupNumber.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Student;

    public static class Extensions
    {
        public static List<Student> GroupStudentsByGroupNumber(this List<Student> students)
        {
            return (from student in students
                    orderby student.GroupNumber
                    select student).ToList();
        }
    }
}