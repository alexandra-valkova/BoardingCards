namespace Domain.Exceptions
{
    public class MoreThanOneStartingPointBoardingCardException : BoardingCardException
    {
        public MoreThanOneStartingPointBoardingCardException() : base("More than one starting point found!")
        {
        }
    }
}
