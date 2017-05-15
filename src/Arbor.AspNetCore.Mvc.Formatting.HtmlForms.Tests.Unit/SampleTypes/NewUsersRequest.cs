using System.Collections.Generic;

namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.SampleTypes
{
    public class NewUsersRequest
    {
        public NewUsersRequest(IEnumerable<string> newUsers)
        {
            NewUsers = newUsers;
        }

        public IEnumerable<string> NewUsers { get; }
    }
}