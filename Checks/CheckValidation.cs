namespace dev.mamallama.checkrunnerlib.Checks;

public class CheckValidation
{
    public readonly CheckStatus Passed;
    public readonly string CheckName;
    public readonly string Because;
    public readonly CheckValidation[]? InnerValidations;

    public CheckValidation(string CheckName, CheckStatus Passed, string Because)
    {
        this.CheckName = CheckName;
        this.Passed = Passed;
        this.Because = Because;
    }

    public CheckValidation(string CheckName, CheckStatus Passed, string Because, CheckValidation[] InnerValidations)
    {
        this.CheckName = CheckName;
        this.Passed = Passed;
        this.Because = Because;
        this.InnerValidations = InnerValidations;
    }
}
