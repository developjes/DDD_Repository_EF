namespace Example.Ecommerce.Transversal.Common.Generic
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? ValidationErrors { get; set; }
    }
}
