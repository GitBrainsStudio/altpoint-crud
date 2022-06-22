namespace ALTPOINT_CRUD.API.Errors
{
    public class EntityNotFoundError : BaseError
    {
        public EntityNotFoundError() 
            : base(StatusCodes.Status404NotFound, ErrorCodes.ENTITY_NOT_FOUND)
        {
        }
    }
}
