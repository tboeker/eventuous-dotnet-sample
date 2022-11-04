using Eventuous;

namespace Bookings.Payments.Domain;

public record PaymentState : State<PaymentState> {
    public string BookingId { get; init; } = null!;
    public float  Amount    { get; init; }

    public PaymentState() {
        On<PaymentEvents.PaymentRecorded>(
            (state, recorded) => state with {
                BookingId = recorded.BookingId,
                Amount = recorded.Amount
            }
        );
    }
}