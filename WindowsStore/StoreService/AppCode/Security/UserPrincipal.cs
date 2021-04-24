namespace Store.StoreService.AppCode.Security
{
    public class UserPrincipal 
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string[] Roles { get; set; }
    }
}