namespace Arbor.AspNetCore.Mvc.Formatting.HtmlForms.Core.Tests.Unit.SampleTypes
{
    public class BookingCancellationRequest
    {
        public BookingCancellationRequest(int bookingId, string reason)
        {
            BookingId = bookingId;
            Reason = reason;
        }

        public string Reason { get; }

        public int BookingId { get; }
    }
}
