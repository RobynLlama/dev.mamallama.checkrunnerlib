namespace dev.mamallama.checkrunnerlib.Checks;

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
