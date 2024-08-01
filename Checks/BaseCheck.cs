namespace dev.mamallama.checkrunnerlib.Checks;

public abstract class BaseCheck(CheckStatus ErrorLevel = CheckStatus.Failed) : ICheck
{
    public abstract string CheckID { get; }
    protected CheckStatus ErrorLevel = ErrorLevel;
    public abstract CheckValidation RunCheck();
}
