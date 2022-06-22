using Newtonsoft.Json;

namespace ALTPOINT_CRUD.API.Exceptions
{
    public class ValidationException
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Field { get; }

        public string? Message { get; }

        public ValidationException(
            string field, 
            string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
