namespace dev.mamallama.checkrunnerlib.Checks;

/// <summary>
/// A status field enum for defining the result of a check
/// </summary>
public enum CheckStatus
{
    Pending = 0,
    Succeeded = 1,
    Warning = 2,
    Failed = 3,
    Fatal = 4,
}

public static class GetColorCode_Ext
{
    public static readonly string COLOR_RESET = "\x1B[0m";

    /// <summary>
    /// An Extension method for CheckStatus that returns a suggested ANSI
    /// terminal code for displaying a color related to the CheckStatus.
    /// EG: Red for failed and Yellow for warning
    /// </summary>
    public static string GetColorCode(this CheckStatus status)
    {
        return status switch
        {
            CheckStatus.Succeeded => "\x1B[32m",
            CheckStatus.Warning => "\x1B[33m",
            CheckStatus.Failed or CheckStatus.Fatal => "\x1B[31m",
            _ => COLOR_RESET
        };
    }
}
