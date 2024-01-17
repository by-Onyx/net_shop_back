namespace net_shop_back.Exceptions;

public class ForbiddenException : IOException
{
    public ForbiddenException(string? message) : base(message) { }
    
    public static void ThrowIfDeny(string? message = null)
    {
        throw new ForbiddenException(message);
    }
}