using System.Net;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos
{
    public class BaseRestViewModel<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
