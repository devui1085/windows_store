using System;
using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppVersion : ValidatableBindableBase
    {
        private string _version;
        private string _description;

        public int Id { get; set; }
        public int AppId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper),
            ErrorMessageResourceName = "VersionNumberRequiredErrorMessage")]
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public DateTime PublishDate { get; set; }
        public int Downloads { get; set; }

        public CpuArchitecture? CpuArchitectureFlags { get; set; }

        public long Size { get; set; }
        public long? ArmPackageSize { get; set; }
        public long? X64PackageSize { get; set; }
        public long? X86PackageSize { get; set; }

        public bool HasX64Package { get; set; }
        public bool HasX86Package { get; set; }
        public bool HasArmPackage { get; set; }

        public bool AppVersionIsComplete
            => CpuArchitectureFlags != null && ((!CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.Arm) ||
                                                 HasArmPackage)
                                                &&
                                                (!CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.X64) ||
                                                 HasX64Package)
                                                &&
                                                (!CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.X86) ||
                                                 HasX86Package));
        public bool IsComplete =>!(string.IsNullOrWhiteSpace(Version) || string.IsNullOrWhiteSpace(Description));
    }
}
