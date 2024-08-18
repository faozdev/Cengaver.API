namespace Cengaver.WebAPI.Model
{
    public class SuccessResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
        public SuccessResponse(T data)
        {
            IsSuccess = true;
            Data = data;
            ErrorMessage = null;
        }
    }
}
