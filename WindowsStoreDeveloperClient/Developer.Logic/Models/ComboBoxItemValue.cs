namespace WindowsStore.Client.Developer.Logic.Models
{
    public class ComboBoxItemValue
    {
        public int Id { get; set; }

        public string Value { get; set; }
        
        public override string ToString()
        {
            // Narrator support
            return Value.ToString();
        }
    }
}
