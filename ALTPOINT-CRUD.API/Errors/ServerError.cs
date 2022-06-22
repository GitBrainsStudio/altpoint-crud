namespace ALTPOINT_CRUD.API.Errors
{
    public class ServerError : BaseError
    {
        public ServerError() 
            : base(StatusCodes.Status500InternalServerError, ErrorCodes.INTERNAL_SERVER_ERROR)
        {
        }
    }
}
