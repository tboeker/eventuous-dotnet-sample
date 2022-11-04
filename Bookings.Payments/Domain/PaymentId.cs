using Eventuous;

namespace Bookings.Payments.Domain;

public record PaymentId(string Value) : AggregateId(Value);