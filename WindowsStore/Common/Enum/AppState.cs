namespace Store.Common.Enum
{
    public enum AppState : byte
    {
        Incomplete = 0,
        Completed = 1,
        Confirmed = 2,
        Published = 3,
        Unpublished = 4,
        BlockedByAdmin = 5
    }
}
