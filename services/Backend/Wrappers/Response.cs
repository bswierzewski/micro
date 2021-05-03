namespace Backend.Wrappers
{
    public class Response<T>
    {
        public Response() { }
        public Response(T data)
        {
            IsError = false;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public T Data { get; set; }
        public bool IsError { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}