namespace Credit.Protocol
{
    public enum ReturnCode : short
    {
        Correct,
        ParameterCountError,
        UndefinedOperation,
        InvalidOperation,
        AlreadyExisted,
        InvalidParameter,
        PermissionDeny,
        NotExisted,
        DatabaseError
    }
}
