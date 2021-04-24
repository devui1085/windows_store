using Store.DomainModel.Entity;

namespace Store.Business.Interface
{
    public interface IMembershipBiz : IBaseBiz<Membership>
    {
        void CreateMembershipForPerson(Person person, string password);
        bool ExistEmail(string email);
        bool ActivateAccount(string email, int activationCode);
        int SetNewVerificationCode(string email);
    }
}
