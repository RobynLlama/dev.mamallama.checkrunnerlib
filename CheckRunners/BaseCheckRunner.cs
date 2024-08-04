using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

/// <summary>
/// A Basic ICheckRunner implementation that already handles running all its
/// children and updating its own state based on their state.
/// </summary>
public abstract class BaseCheckRunner() : ICheckRunner
{
    public abstract string CheckID { get; }
    public CheckStatus State { get; protected set; } = CheckStatus.Pending;
    public abstract ICheckRunner[] MyChecks { get; }

    public virtual void RunChecks()
    {
        //run every check
        foreach (var item in MyChecks)
        {
            item.RunChecks();
            UpdateState(item.State);
        }

    }

    protected virtual void UpdateState(CheckStatus IncState)
    {
        if ((int)IncState > (int)State)
        {
            State = IncState;
        }
    }
}
