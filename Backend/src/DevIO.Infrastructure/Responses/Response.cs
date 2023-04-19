namespace DevIO.Infrastructure.Responses
{
    public class Response<TReponse>
    {
        public TReponse? Data { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string>? Messages { get; set; }

        public static Response<TReponse> Fail(string message)
        {
            return new Response<TReponse> { Succeeded = false, Messages = new List<string> { message } };
        }

        public static Response<TReponse> Fail(IEnumerable<string> messages)
        {
            return new Response<TReponse> { Succeeded = false, Messages = messages };
        }

        public static Response<TReponse> Success(TReponse data)
        {
            return new Response<TReponse> { Succeeded = true, Data = data };
        }
    }
}
