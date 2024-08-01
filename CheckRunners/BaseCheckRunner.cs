using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

public abstract class BaseCheckRunner() : ICheckRunner, ICheck
{
    public abstract string CheckGroupID { get; }

    public CheckStatus State { get; protected set; } = CheckStatus.Pending;
    protected abstract ICheck[] MyChecks { get; }

    public virtual CheckValidation[] RunAllChecks()
    {
        CheckValidation[] validation = new CheckValidation[MyChecks.Length];

        for (int i = 0; i < MyChecks.Length; i++)
        {
            validation[i] = MyChecks[i].RunCheck();

            //Scream
            if (validation[i].Passed == CheckStatus.Fatal)
                break;
        }

        //Determine State
        UpdateState(validation);

        return validation;
    }

    protected virtual void UpdateState(CheckValidation[] Validations)
    {
        //strict checking
        foreach (var item in Validations)
        {
            if ((int)item.Passed > (int)State)
            {
                State = item.Passed;
            }

            if (item.Passed == CheckStatus.Fatal)
            {
                return;
            }
        }
    }

    public virtual CheckValidation RunCheck()
    {
        var validations = RunAllChecks();
        UpdateState(validations);

        return new(CheckGroupID, State, "", validations);
    }
}
