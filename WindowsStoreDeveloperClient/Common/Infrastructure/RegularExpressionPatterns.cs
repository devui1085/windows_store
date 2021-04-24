namespace WindowsStore.Client.Developer.Common.Infrastructure
{
    public static class RegularExpressionPatterns
    {
        public const string Names = @"\A\p{L}+([\p{Zs}\-][\p{L}]+)*\z";

        public const string Email =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
    }
}
