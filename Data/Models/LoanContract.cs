namespace Data.Models
{
    public class LoanContract
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int Duration { get; set; }
        public double AnnualInterestRatePercentage { get; set; }
    }
}
