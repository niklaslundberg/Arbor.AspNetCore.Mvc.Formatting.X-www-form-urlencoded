namespace Arbor.AspnetCore.Mvc.Formatting.HtmlForms.Tests.Integration
{
    public class SampleClassWithCtor
    {
        public SampleClassWithCtor(string a, int b)
        {
            A = a;
            B = b;
        }

        public string A { get; }

        public int B { get; }
    }
}