namespace Cengaver.WebAPI.Model
{
    public class ValidationErrorResponse
    {
        public bool IsSuccess { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }

}
