using dev.mamallama.checkrunnerlib.Checks;

namespace dev.mamallama.checkrunnerlib.CheckRunners;

/// <summary>
/// The basic contract for a CheckRunner
/// </summary>
public interface ICheckRunner
{
    /// <summary>
    /// A string describing the check. Should be print-friendly
    /// </summary>
    string CheckID { get; }

    /// <summary>
    /// The state of the check. Should remain "pending" until it has completed
    /// and then take on any other value to represent how it completed
    /// </summary>
    CheckStatus State { get; }

    /// <summary>
    /// Checks are organized in a brach -> leaf style. This should be either an
    /// array of additional sub checks on "branches" or an empty array on
    /// "leaves"
    /// </summary>
    ICheckRunner[] MyChecks { get; }

    /// <summary>
    /// This method should be used to run all the checks on a branch or leaf
    /// and modify the current check's state 
    /// </summary>
    void RunChecks();
}
