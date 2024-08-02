using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

public interface ICheckRunner
{
    string CheckID { get; }
    CheckStatus State { get; }
    ICheckRunner[] MyChecks { get; }
    void RunChecks();
}
