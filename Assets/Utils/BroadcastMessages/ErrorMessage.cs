namespace Utils.BroadcastMessages
{
    public class ErrorMessage : BroadcastMessage
    {
        public string Message;
        public int ShowSeconds = 3;

        public ErrorMessage(string message)
        {
            Message = message;
        }

        public ErrorMessage(string message, int showSeconds)
        {
            Message = message;
            ShowSeconds = showSeconds;
        }
    }
}