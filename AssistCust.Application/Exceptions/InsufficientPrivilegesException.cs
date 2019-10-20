namespace AssistCust.Application.Exceptions
{
    public class InsufficientPrivilegesException : System.Exception
    {
        public InsufficientPrivilegesException(string name)
           : base($"You lack permissions to create \"{name}\" entity")
        {
        }
    }
}
