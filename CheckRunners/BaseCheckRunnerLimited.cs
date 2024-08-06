using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

/// <summary>
/// A BaseCheckRunner that has a maximum allowed returned error level from
/// it's children. Useful if a whole line of checks should only return a warn
/// on failure, for example
/// </summary>
/// <param name="ErrorLevel"></param>The maximum error level this runner's children can return
public abstract class BaseCheckRunnerLimited() : BaseCheckRunner
{
    public required CheckStatus ErrorLevel { get; init; }

    protected override void UpdateState(CheckStatus IncState)
    {
        if ((int)IncState > (int)ErrorLevel)
            IncState = ErrorLevel;

        base.UpdateState(IncState);
    }
}
