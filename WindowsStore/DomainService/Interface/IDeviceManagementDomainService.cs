using Store.DomainModel.Entity;
using Store.DataContract;
using System.Collections.Generic;
using Store.Common.Infrastructure;

namespace Store.DomainService.Interface
{
    public interface IDeviceManagementDomainService
    {
        ServerDescriptorDataContract RegisterDevice(UserClientDescriptorDataContract descriptor);
    }
}
