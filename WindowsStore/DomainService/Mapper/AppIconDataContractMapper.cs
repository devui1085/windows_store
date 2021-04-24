using Store.Common.Drawing;
using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class AppIconDataContractMapper
    {
        public static App ToApp(this AppIconDataContract appIconDataContract)
        {
            return new App()
            {
                Id = appIconDataContract.AppId,
                Icon128X128 = ImageConverter.ResizeByteArrayImage(appIconDataContract.Icon256X256, 128,128),
                Icon256X256 = appIconDataContract.Icon256X256
            };
        }

        public static AppIconDataContract ToAppIconDataContract(this App app)
        {
            var dataContract = new AppIconDataContract()
            {
                AppId = app.Id,
                Icon128X128 = app.Icon128X128,
                Icon256X256 = app.Icon256X256
            };

            return dataContract;
        }
    }
}
