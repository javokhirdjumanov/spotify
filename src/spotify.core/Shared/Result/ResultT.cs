namespace spotify.core.Shared;
public class Result<TValue> : Result
{
    /// <summary>
    /// Бу коддаги "привате реадонлй TValue? _value;" TValue номли генериc тип параметри билан ишлатилган "readonly" ва "nullable" (TValue?) (private) (field) белгиланган.
    /// </summary>
    private readonly TValue? _value;

    /// <summary>
    /// Result<TValue> синфи Result синфига асосланган (Result синфида isSuccess ва Error хусусиятларини ўз ичига олган) ва протеcтед интернал билан конструктор ташкил этилган.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isSuccess"></param>
    /// <param name="error"></param>
    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error) => _value = value;

    /// <summary>
    /// Value хусусияти, Result<TValue> синфида TValue типидаги маълумотларга мурожаат қилиш учун ишлатилади.
    /// </summary>
    public TValue Value => IsSuccess 
        ? _value! : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    /// <summary>
    /// Бу оператор, Result<TValue> типидаги обектларни TValue? (нуллабле) типидан ўзгарувчиларга ўгириш имконини беради.
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
