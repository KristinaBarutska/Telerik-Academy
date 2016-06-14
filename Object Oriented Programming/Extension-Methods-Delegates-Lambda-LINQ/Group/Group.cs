namespace Group
{
    public class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber
        {
            get;
            private set;
        }

        public string DepartmentName
        {
            get; set;
        }
    }
}