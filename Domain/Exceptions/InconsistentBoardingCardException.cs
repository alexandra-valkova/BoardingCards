namespace Domain.Exceptions
{
    public class InconsistentBoardingCardException : BoardingCardException
    {
        public InconsistentBoardingCardException() : base("Inconsistent boarding cards!")
        {
        }
    }
}
