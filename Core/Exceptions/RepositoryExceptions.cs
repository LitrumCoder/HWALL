// RepositoryException.cs
namespace UserRegistrationApp.Core.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}