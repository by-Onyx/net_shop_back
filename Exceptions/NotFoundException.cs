using System.Diagnostics.CodeAnalysis;

namespace net_shop_back.Exceptions
{
    public class NotFoundException : IOException
    {
        public NotFoundException(string? message) : base(message) { }

        public static void ThrowIfNull([NotNull] object? param, string? message = null)
        {
            if (param is null)
                throw new NotFoundException(message);
        }
    }
}
