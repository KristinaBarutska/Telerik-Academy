namespace School
{
    public class StartUp
    {
        public static void Main()
        {
            Student firstStudent = new Student("First Student", "123456");
            firstStudent.Comment = "Brilliant student!";

            Teacher firstTeacher = new Teacher("First Teacher");
        }
    }
}