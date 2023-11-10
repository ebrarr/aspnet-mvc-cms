namespace Cms.Web.Shared.ServiceResult
{
    public class ServiceResult : IServiceResult
    {
        public bool Success { get; private set; }

        public string Message { get; private set; }

        public int StatusCode { get; private set; }
    }

    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        public T? Data { get; internal set; }
    }
}
