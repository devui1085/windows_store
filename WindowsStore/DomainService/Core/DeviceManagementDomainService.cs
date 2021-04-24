using System;
using Store.DataAccess.Context;
using Store.DataContract;
using Store.DomainService.Interface;
using Store.Business.Interface;
using Store.Business.Core;
using Store.DomainService.Mapper;
using Store.Common.Configuration;

namespace Store.DomainService.Core
{
    public class DeviceManagementDomainService : IDeviceManagementDomainService
    {
        private readonly WindowsStoreContext _context;
        private IDeviceBiz DeviceBiz { get; }
        private IActiveDeviceHistoryBiz ActiveDeviceHistoryBiz { get; }

        public DeviceManagementDomainService()
        {
            _context = new WindowsStoreContext();
            DeviceBiz = new DeviceBiz(_context);
            ActiveDeviceHistoryBiz = new ActiveDeviceHistoryBiz(_context);
        }

        public ServerDescriptorDataContract RegisterDevice(UserClientDescriptorDataContract descriptor)
        {
            DeviceBiz.RegisterDevice(descriptor.GetDevice());
            ActiveDeviceHistoryBiz.IncrementTodayActiveDevicesCount();
            _context.SaveChanges();

            return new ServerDescriptorDataContract()
            {
                SupportedUserClientMinVersion = ConfigurationReader.SupportedUserClientMinVersion,
                SupportedUserClientMaxVersion = ConfigurationReader.SupportedUserClientMaxVersion,
                SupportedDeveloperClientMaxVersion = ConfigurationReader.SupportedDeveloperClientMinVersion,
                SupportedDeveloperClientMinVersion = ConfigurationReader.SupportedDeveloperClientMaxVersion,
            };
        }
    }
}
