namespace GameStore.Bll.Infrastructure
{
    public class OptionalDetails
    {
        public OptionalDetails(string message, bool succeed)
        {
            Message = message;
            Succeed = succeed;
        }

        public string Message { get; }

        public bool Succeed { get; }
    }
}
