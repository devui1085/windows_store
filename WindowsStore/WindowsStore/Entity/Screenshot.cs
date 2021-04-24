using Store.Common.Enum;

namespace Store.DomainModel.Entity
{
    public partial class Screenshot
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public ScreenshotType Type  { get; set; }
        public string FileName { get; set; }
        public virtual App App { get; set; }
    }
}
