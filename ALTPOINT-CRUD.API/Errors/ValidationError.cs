using Microsoft.AspNetCore.Mvc.ModelBinding;

using ALTPOINT_CRUD.API.Exceptions;

namespace ALTPOINT_CRUD.API.Errors
{
    public class ValidationError : BaseError
    {
        public List<ValidationException> Exceptions { get; }

        public ValidationError(ModelStateDictionary modelState) 
            : base(StatusCodes.Status422UnprocessableEntity, ErrorCodes.VALIDATION_EXCEPTION)
        {
            Exceptions = GetValidationExceptions(modelState);
        }

        private List<ValidationException> GetValidationExceptions(ModelStateDictionary modelState)
        {
            return modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x =>
                    new ValidationException(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
