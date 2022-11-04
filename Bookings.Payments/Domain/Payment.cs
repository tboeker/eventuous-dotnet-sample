using Eventuous;
using static Bookings.Payments.Domain.PaymentEvents;

namespace Bookings.Payments.Domain;

public class Payment : Aggregate<PaymentState> {
    public void ProcessPayment(
        PaymentId paymentId, string bookingId, Money amount, string method, string provider
    )
        => Apply(new PaymentRecorded(paymentId, bookingId, amount.Amount, amount.Currency, method, provider));
}