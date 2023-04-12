using System.Drawing;

namespace ecommerce.domain.Shared;
public class Error : IEquatable<Error>
{
    public Error(string code, string message)
    {
        this.code = code;
        this.message = message;
    }
    public string code { get; }
    public string message { get; }

    public static implicit operator string(Error error) => error.code;
    public bool Equals(Error? other)
    {
        if(other is null)
        {
            return false;
        }

        return 
            this.code == other.code && message == other.message;
    }
}
