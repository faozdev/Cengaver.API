namespace Cengaver.WebAPI.Model
{
    public class SuccessResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        
    }

}
