namespace Domain.Exceptions
{
    public class MoreThanOneNextCardMatchBoardingCardException : BoardingCardException
    {
        public MoreThanOneNextCardMatchBoardingCardException() : base("More than one next card match found!")
        {
        }
    }
}
