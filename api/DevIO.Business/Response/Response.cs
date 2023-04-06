namespace DevIO.Business.Response
{
    public class Response<C> where C : Response<C>
    {
        private IList<string>? _MessageList = new List<string>();
        public IList<string>? MessageList
        {
            get => _MessageList;
            set => _MessageList = value;
        }
    }
}
