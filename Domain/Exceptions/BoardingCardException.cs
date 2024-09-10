namespace Domain.Exceptions
{
    public class BoardingCardException : Exception
    {
        public BoardingCardException()
        {
        }

        public BoardingCardException(string message) : base(message)
        {
        }

        public BoardingCardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
