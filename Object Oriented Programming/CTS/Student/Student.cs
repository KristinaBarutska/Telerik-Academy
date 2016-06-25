namespace Student
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student()
        {
        }

        public Student(string firstName, string middleName, string lastName, string ssn, string permanentAdress,
            string mobilePhone, string email, string course, Speciality speciality, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAdress = permanentAdress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string MiddleName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public string SSN
        {
            get;
            private set;
        }

        public string PermanentAdress
        {
            get;
            private set;
        }

        public string MobilePhone
        {
            get;
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public string Course
        {
            get;
            private set;
        }

        public Speciality Speciality
        {
            get;
            private set;
        }

        public University University
        {
            get;
            private set;
        }

        public Faculty Faculty
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if ((Student)obj == null)
            {
                return false;
            }
            else
            {
                var otherStudent = obj as Student;
                bool areEqual = (this.FirstName == otherStudent.FirstName) && (this.MiddleName == otherStudent.MiddleName) &&
                    (this.LastName == otherStudent.LastName) && (this.SSN != otherStudent.SSN) && (this.PermanentAdress == otherStudent.PermanentAdress) &&
                    (this.MobilePhone == otherStudent.MobilePhone) && (this.Email == otherStudent.Email) && (this.Course == otherStudent.Course) &&
                    (this.Speciality == otherStudent.Speciality) && (this.University == otherStudent.University) && (this.Faculty == otherStudent.Faculty);

                return areEqual;
            }
        }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            var result = new StringBuilder();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);

                if (value != null)
                {
                    result.AppendLine(string.Format("{0}: {1}", property.Name, property.GetValue(this)));
                }
            }

            return result.ToString().Trim();
        }

        public override int GetHashCode()
        {
            var hashCode = this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.MiddleName.GetHashCode() ^
                this.SSN.GetHashCode() ^ this.Email.GetHashCode() ^ this.MobilePhone.GetHashCode() ^ this.PermanentAdress.GetHashCode() ^
                this.Course.GetHashCode() ^ this.Speciality.GetHashCode() ^ this.University.GetHashCode() ^ this.Faculty.GetHashCode();

            return hashCode;
        }

        public object Clone()
        {
            var clonedStudent = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAdress,
                this.MobilePhone, this.Email, this.Course, this.Speciality, this.University, this.Faculty);

            return clonedStudent;
        }

        public int CompareTo(Student other)
        {
            int namesCompareResult = this.FirstName.CompareTo(other.FirstName);

            if (namesCompareResult != 0)
            {
                return namesCompareResult;
            }
            else
            {
                return this.SSN.CompareTo(other.SSN);
            }
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }
    }
}