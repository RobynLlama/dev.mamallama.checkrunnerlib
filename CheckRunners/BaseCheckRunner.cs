using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

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
