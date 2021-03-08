namespace Toystore.AspNetCore.Api.Products.Presentation
{
    public class ProductResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Obj { get; private set; }
        
        protected ProductResponse()
        {
            Success = false;
            Message = string.Empty;
            Obj = default(T);
        }

        public static ProductResponse<T> Create(string message)
        {
            var response = new ProductResponse<T>();
            response.Message = message;
            return response;
        }

        public static ProductResponse<T> Create(string message, T obj)
        {
            var response = new ProductResponse<T>();
            response.Success = true;
            response.Message = message;
            response.Obj = obj;
            return response;
        }
    }
}
