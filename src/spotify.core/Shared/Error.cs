namespace spotify.core.Shared;
public class Error : IEquatable<Error>
{
    /// <summary>
    /// "None" ўзгарувчиси, Error синфи яратилган обектни ўз ичига олади ва уни бўш хато коди ва бўш хабар билан таъминлайди.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// NullValue ўзгарувчиси, Error синфи яратилган обектни ўз ичига олади ва уни фойдаланувчига берилган хато коди ва хато хабар билан таъминлайди.
    /// </summary>
    public static readonly Error NullValue = new("Error.NullValue","The specified result value is null");

    /// <summary>
    /// Error синфи учун конструктор.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Error обжеcтининг Code ва Message properties
    /// </summary>
    public string Code { get; set; }
    public string Message { get; set; }

    /// <summary>
    /// Агар Code ва Message хусусиятларининг қийматлари ҳам тенг бўлса, true қайтаради, акс ҳолда (Code ёки Message тенг эмас бўлса), false қайтаради.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public virtual bool Equals(Error? other)
    {
        if(other is null) return false;

        return Code == other.Code && Message == other.Message;
    }

    /// <summary>
    /// "implicit" оператори Error типидаги обектларни string типига ўгиради. Оператор ёрдамида Error обектини "Code" номли string майдони билан таъминлайди.
    /// </summary>
    /// <param name="error"></param>
    public static implicit operator string(Error error) => error.Code;

    /// <summary>
    /// == оператори ўзгарувчиларнинг мослигини солиштиради ва bool (мантиқий) қийматни қайтаради.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null) return true;

        if (a is null || b is null) return false;

        return a.Equals(b);
    }

    /// <summary>
    /// != операторининг ёрлиқ методи эса шу натижани яна ўзгартириб true ёки false қийматини қайтаради.ди.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Error? a, Error? b) => !(a == b);

    /// <summary>
    /// Equals методининг ихтиёрий версиясини (Equals(object? obj)) ишлатиш ёки уникал солиштирувчи код (GetHashCode) вақти келганда бошқа ёълда ишлатилишида, обектларни мослигини аниқлашда жуда қулайлик яратади
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is Error error && Equals(error);

    /// <summary>
    /// Бу мисолда GetHashCode методида HashCode.Combine усули билан Code ва Message хусусиятлари комбинатсияси сифатида уникал код ҳосил қилинади.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(Code, Message);

    /// <summary>
    /// Демак, error ўзгарувчисини экранга чиқаришда "Code" ёки Error.Code га тенг бўлган қиймат кўрсатилади.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Code;
}
