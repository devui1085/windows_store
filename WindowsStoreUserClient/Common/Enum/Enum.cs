namespace WindowsStore.Client.User.Common.Enum
{
    //
    //--- A
    //
    public enum AppType
    {
        Application = 1,
        Game = 2
    }

    public enum AppPricing : byte
    {
        FreeApp = 1,
        NonFreeApp = 2
    }

    public enum AppOrderMethod : byte
    {
        Top = 1,
        BestRated = 2,
        NewAndRising = 3
    }

    public enum AppScreenshotSize : byte
    {
        Original = 1,
        Thumbnail = 2,
    }

    public enum AppScreenshotType : byte
    {
        Mobile = 1,
        Desktop = 2,
    }

    //
    //--- C
    //


    //
    //--- D
    //
    public enum DownloadStatus
    {
        Idle = 0,
        Running = 1,
        PausedByApplication = 2,
        PausedCostedNetwork = 3,
        PausedNoNetwork = 4,
        Completed = 5,
        Canceled = 6,
        Error = 7,
        PausedSystemPolicy = 32
    }

    // I
    public enum InstallationStatus
    {
        None,
        Installing,
        InstallingAttempt2,
        InstallingAttempt3,
        Waiting,
        Installed,
        InstallationFailed
    }

    //
    //--- S
    //
    public enum Sexuality
    {
        Male = 1,
        Female = 2
    }

    //
    //--- U
    //
    public enum UserAccountStatus
    {
        Activated = 1,
        NotActivated = 2,
        Blocked = 3
    }



}
