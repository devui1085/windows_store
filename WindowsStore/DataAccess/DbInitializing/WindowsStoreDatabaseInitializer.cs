using Store.Common.Enum;
using Store.Common.Security;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System;
using System.Data.Entity.Migrations;

namespace Store.DataAccess.DbInitializing
{
    public class WindowsStoreDatabaseInitializer
    {
        public WindowsStoreDatabaseInitializer()
        {
        }

        public void Seed(WindowsStoreContext context)
        {
            #region Platform
            var platform1 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10Universal,
                Title = "ویندوز 10، یونیورسال"
            };
            var platform2 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10Desktop,
                Title = "ویندوز 10، خانواده دسکتاپ"
            };
            var platform3 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10Mobile,
                Title = "ویندوز 10، خانواده موبایل"
            };
            var platform4 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10XBox,
                Title = "ویندوز 10، خانواده XBox"
            };
            var platform5 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10Iot,
                Title = "ویندوز 10، خانواده IOT"
            };
            var platform6 = new Platform
            {
                PlatformCategory = PlatformCategory.Windows10HoloLens,
                Title = "ویندوز 10، خانواده HoloLens"
            };

            context.Platforms.AddRange(
                new Platform[] { platform1, platform2, platform3, platform4, platform5, platform6 });

            #endregion

            #region AppCategory
            var appCategory1 = new AppCategory { AppType = AppType.Application, Title = "کسب و کار" };
            var appCategory2 = new AppCategory { AppType = AppType.Application, Title = "توسعه نرم افزار" };
            var appCategory3 = new AppCategory { AppType = AppType.Application, Title = "غذا و آشپزی" };
            var appCategory4 = new AppCategory { AppType = AppType.Application, Title = "خانواده" };
            var appCategory5 = new AppCategory { AppType = AppType.Application, Title = "سبک زندگی" };
            var appCategory6 = new AppCategory { AppType = AppType.Application, Title = "موسیقی" };
            var appCategory7 = new AppCategory { AppType = AppType.Application, Title = "مسافرت-نقشه" };
            var appCategory8 = new AppCategory { AppType = AppType.Application, Title = "خبر-آب‌ و‌ هوا" };
            var appCategory9 = new AppCategory { AppType = AppType.Application, Title = "تصویر و ویدیو" };
            var appCategory10 = new AppCategory { AppType = AppType.Application, Title = "خرید" };
            var appCategory11 = new AppCategory { AppType = AppType.Application, Title = "ابزار" };
            var appCategory12 = new AppCategory { AppType = AppType.Application, Title = "کتاب‌ها و مراجع" };
            var appCategory13 = new AppCategory { AppType = AppType.Application, Title = "خرید" };
            var appCategory14 = new AppCategory { AppType = AppType.Application, Title = "اجتماعی" };
            var appCategory15 = new AppCategory { AppType = AppType.Application, Title = "ورزش" };
            var appCategory16 = new AppCategory { AppType = AppType.Application, Title = "ابزار" };
            var appCategory17 = new AppCategory { AppType = AppType.Game, Title = "اکشن" };
            var appCategory18 = new AppCategory { AppType = AppType.Game, Title = "کارت و تخته" };
            var appCategory19 = new AppCategory { AppType = AppType.Game, Title = "آموزشی" };
            var appCategory20 = new AppCategory { AppType = AppType.Game, Title = "پلتفرمر" };
            var appCategory21 = new AppCategory { AppType = AppType.Game, Title = "معمایی" };
            var appCategory22 = new AppCategory { AppType = AppType.Game, Title = "پرواز" };
            var appCategory23 = new AppCategory { AppType = AppType.Game, Title = "تیراندازی" };
            var appCategory24 = new AppCategory { AppType = AppType.Game, Title = "شبیه‌سازی" };
            var appCategory25 = new AppCategory { AppType = AppType.Game, Title = "استراتژی" };
            var appCategory26 = new AppCategory { AppType = AppType.Game, Title = "کلمات" };

            context.AppCategories.AddRange (new AppCategory[] {
              appCategory1, appCategory2, appCategory3, appCategory4, appCategory5,
              appCategory6, appCategory7, appCategory8, appCategory9, appCategory10,
              appCategory11, appCategory12, appCategory13, appCategory14, appCategory15,
              appCategory16, appCategory17, appCategory18, appCategory19, appCategory20,
              appCategory21, appCategory22, appCategory23, appCategory24, appCategory25,
              appCategory26 }
            );
            #endregion

            #region Role
            var AdminRole = new Role { Title = "Admin", Name = "Admin" };
            var developerRole = new Role { Title = "Developer", Name = "Developer" };
            context.Roles.AddRange(new Role[] { AdminRole, developerRole });
            #endregion

            #region LegalPerson
            var paasteelCompany = new LegalPerson
            {
                PrimaryEmail = "info@paasteel.ir",
                Name = "پاستیل",
                Membership = new Membership
                {
                    CreateDate = DateTime.Now,
                    FailedPasswordAttemptCount = 0,
                    IsApproved = true,
                    IsIdentityVerified = true,
                    IsLockedOut = true,
                    Password = SecurityHelper.ComputeSha256Hash("12345"),
                    VerificationCodeLastSendDate = DateTime.Now,
                    VerificationCode = 0
                }
            };

            var paasteelAppProvider = new LegalPerson
            {
                PrimaryEmail = "provider@paasteel.ir",
                Name = "(گرد آورنده: پاستیل)",
                Membership = new Membership
                {
                    CreateDate = DateTime.Now,
                    FailedPasswordAttemptCount = 0,
                    IsApproved = true,
                    IsIdentityVerified = true,
                    IsLockedOut = true,
                    Password = SecurityHelper.ComputeSha256Hash("12345"),
                    VerificationCodeLastSendDate = DateTime.Now,
                    VerificationCode = 0
                }
            };
            context.LegalPeople.AddRange (new LegalPerson[] { paasteelCompany , paasteelAppProvider});
            #endregion

            #region Natural Person
            var mehrdad = new NaturalPerson
            {
                PrimaryEmail = "mehrta.misc@live.com",
                FirstName = "مهرداد",
                LastName = "تاجدینی",
                Age = 29,
                Sexuality = Sexuality.Male,
                Membership = new Membership
                {
                    CreateDate = DateTime.Now,
                    FailedPasswordAttemptCount = 0,
                    IsApproved = true,
                    IsIdentityVerified = true,
                    IsLockedOut = true,
                    Password = SecurityHelper.ComputeSha256Hash("12345"),
                    VerificationCodeLastSendDate = DateTime.Now,
                    VerificationCode = 0
                }
            };
            mehrdad.Roles.Add(AdminRole);
            mehrdad.Roles.Add(developerRole);

            var vahid = new NaturalPerson
            {
                PrimaryEmail = "va.ansari@gmail.com",
                FirstName = "وحید",
                LastName = "انصاری",
                Age = 29,
                Sexuality = Sexuality.Male,
                Membership = new Membership
                {
                    CreateDate = DateTime.Now,
                    FailedPasswordAttemptCount = 0,
                    IsApproved = true,
                    IsIdentityVerified = true,
                    IsLockedOut = true,
                    Password = SecurityHelper.ComputeSha256Hash("12345"),
                    VerificationCodeLastSendDate = DateTime.Now,
                    VerificationCode = 0
                }
            };
            vahid.Roles.Add(AdminRole);
            vahid.Roles.Add(developerRole);

            context.NaturalPeople.AddRange(new NaturalPerson[] { mehrdad, vahid });
            #endregion

            #region App
            var paasteelApp = new App
            {
                Guid = Guid.Empty,
                Developer = paasteelCompany,
                Name = "پاستیل",
                Description = "پاستیل",
                Icon128X128 = new byte[1],
                Icon256X256 = new byte[1],
                AppCategory = appCategory16,
                State = AppState.Unpublished,
                CpuArchitectureFlags = CpuArchitecture.Arm,
            };
            paasteelApp.Platforms.Add(platform1);
            paasteelApp.AppVersions.Add(new AppVersion()
            {
                Downloads = 0,
                PublishDate = DateTime.Now,
                Description = "پاستیل",
                Version = "1.0.0.0",
                Size = 0
            });
            context.Apps.Add(paasteelApp);
            #endregion

            context.SaveChanges();
        }
    }
}
