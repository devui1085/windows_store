using Store.Common.Enum;
using Store.DomainModel.Entity;
using System.Collections.Generic;

namespace Store.Business.Interface
{
    public interface IPersonBiz : IBaseBiz<Person>
    {
        void CreateMembershipForPerson(Person person, string password);
        Person GetPersonByCredentials(string primaryEmail, string password);
        UserAccountStatus GetAccountStatus(Person person);

        ICollection<Role> GetPersonRoles(int personId);

    }
}
