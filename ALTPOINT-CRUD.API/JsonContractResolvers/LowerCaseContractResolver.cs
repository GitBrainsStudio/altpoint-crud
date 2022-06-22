using Newtonsoft.Json.Serialization;

namespace ALTPOINT_CRUD.API.JsonContractResolvers
{
    public class LowerCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
