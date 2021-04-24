using Store.Business.Interface;
using Store.Common.ExtensionMethod;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System;

namespace Store.Business.Core
{
    public class DeviceBiz : BaseBiz<Device>, IDeviceBiz
    {
        private readonly WindowsStoreContext _context;

        public DeviceBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }

        public Device RegisterDevice(Device device)
        {
            if (device.DeviceId == Guid.Empty) throw new ArgumentException();
            var foundDevice = SingleOrDefault(d => d.DeviceId == device.DeviceId);
            if (foundDevice != null) {
                foundDevice.AutomaticUpdateEnabled = device.AutomaticUpdateEnabled;
                return foundDevice;
            };

            Create(device);
            return device;
        }
    }
}
