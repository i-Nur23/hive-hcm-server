namespace Core.Events
{
    public class EmailSendEvent
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
