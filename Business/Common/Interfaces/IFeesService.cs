namespace Business.Common.Interfaces
{
    public interface IFeesService
    {
        public double OneTimeAdministrationFee();
        public double MonthlyAdministrativeFee();
    }
}
