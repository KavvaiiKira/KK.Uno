using KK.Uno.Contracts.Enums;
using System.Text.Json.Serialization;

namespace KK.Uno.Contracts.Api
{
    public class KKApiResult<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Body { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KKApiErrorCodesEnum ErrorCode { get; set; }

        public static KKApiResult<T> Empty => new KKApiResult<T>
        {
            Success = true,
            ErrorCode = KKApiErrorCodesEnum.None
        };

        public static KKApiResult<T> Ok(T data = default)
        {
            var result = Empty;
            result.Body = data;
            return result;
        }

        public static KKApiResult<T> BadRequest(string message = "Bad request") => new KKApiResult<T>
        {
            Success = false,
            ErrorCode = KKApiErrorCodesEnum.BadRequest,
            Message = message
        };

        public static KKApiResult<T> Forbidden(string message = "Forbidden") => new KKApiResult<T>
        {
            Success = false,
            ErrorCode = KKApiErrorCodesEnum.Forbidden,
            Message = message
        };

        public static KKApiResult<T> NotFound(string message = "Not found") => new KKApiResult<T>()
        {
            Success = false,
            ErrorCode = KKApiErrorCodesEnum.NotFound,
            Message = message
        };

        public static KKApiResult<T> WithData(T data)
        {
            var result = Empty;
            result.Body = data;
            return result;
        }

        public static implicit operator KKApiResult<T>(T obj)
        {
            return WithData(obj);
        }
    }
}
