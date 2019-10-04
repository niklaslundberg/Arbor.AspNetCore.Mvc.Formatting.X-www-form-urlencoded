namespace Arbor.AspNetCore.Formatting.Tests.Integration
{
    public class SubListItem
    {
        public string Note { get; set; }

        public override string ToString()
        {
            return $"{nameof(Note)}: '{Note}'";
        }
    }
}
