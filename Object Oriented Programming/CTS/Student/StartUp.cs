namespace Student
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstStudent = new Student("Abradolf", "Stoqnov", "Lincler", "123456", "Oziris 23", "123 321 123", "asl@space.com",
               "Robotics", Speciality.Engineering, University.MIT, Faculty.MathematicsAndInformatics);
            var secondStudent = new Student("Donald", "Petrov", "NotTrump", "8765432", "Mladost", "444 221 312", "dnt@priCoci.com",
               "Cooking", Speciality.Art, University.Harvard, Faculty.History);

            Console.WriteLine(firstStudent.Equals(secondStudent));
            Console.WriteLine(firstStudent.GetHashCode());

            var clonedStudent = (Student)(firstStudent.Clone());
            Console.WriteLine(clonedStudent == firstStudent);

            Console.WriteLine(clonedStudent.CompareTo(firstStudent));
            Console.WriteLine(secondStudent);
        }
    }
}