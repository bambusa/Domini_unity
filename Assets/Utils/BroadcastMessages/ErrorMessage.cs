namespace DefaultNamespace.Messages
{
    public class ErrorMessage
    {
        public static readonly string Receiver = "ErrorMessageReceived";

        public string Message;
        public int ShowSeconds = 3;

        public ErrorMessage(string message)
        {
            this.Message = message;
        }
    }
}