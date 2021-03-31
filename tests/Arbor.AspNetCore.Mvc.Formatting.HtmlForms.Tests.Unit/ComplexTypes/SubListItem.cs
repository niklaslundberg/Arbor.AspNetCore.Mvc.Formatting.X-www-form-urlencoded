namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.ComplexTypes
{
    public class SubListItem
    {
        public string? Note { get; set; }

        public override string ToString() => $"{nameof(Note)}: '{Note}'";
    }
}