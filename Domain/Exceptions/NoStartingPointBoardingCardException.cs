namespace Domain.Exceptions
{
    public class NoStartingPointBoardingCardException : BoardingCardException
    {
        public NoStartingPointBoardingCardException() : base("No starting point found!")
        {
        }
    }
}
