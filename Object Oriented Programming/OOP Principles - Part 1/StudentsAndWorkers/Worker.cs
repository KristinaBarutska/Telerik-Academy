namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        private const int WeekWorkDays = 5;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get;
            private set;
        }

        public int WorkHoursPerDay
        {
            get;
            private set;
        }

        public decimal MoneyPerHour()
        {
            decimal salaryPerDay = this.WeekSalary / WeekWorkDays;
            decimal salaryPerHour = salaryPerDay / this.WorkHoursPerDay;

            return salaryPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} Money per hour: {2:0.00}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}