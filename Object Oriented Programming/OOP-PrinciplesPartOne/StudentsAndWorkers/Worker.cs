namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        private const int WorkDays = 5;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get; private set;
        }

        public double WorkHoursPerDay
        {
            get; private set;
        }

        private decimal CalculateMoneyPerHour()
        {
            decimal moneyPerHour = (this.WeekSalary / WorkDays) / (decimal)this.WorkHoursPerDay;
            return moneyPerHour;
        }
    }
}