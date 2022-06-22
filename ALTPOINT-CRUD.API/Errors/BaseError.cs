namespace ALTPOINT_CRUD.API.Errors
{
    public abstract class BaseError
    {
        public int Status { get; }

        public string Code { get; }

        public BaseError(
            int status,
            ErrorCodes code)
        {
            Status = status;
            Code = code.ToString();
        }
    }
}
