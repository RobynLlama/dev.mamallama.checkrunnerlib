using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

public interface ICheckRunner
{
    public string CheckGroupID { get; }
    CheckStatus State { get; }
    CheckValidation[] RunAllChecks();
}
