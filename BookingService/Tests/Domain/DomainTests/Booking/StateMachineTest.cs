using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;


namespace DomainTests.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAlwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.Status, Is.EqualTo(EStatus.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingABookingWithCreatedStatus()

        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Paid));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Canceled));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Finished));
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Refound);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Refounded));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningABookingWithCanceledStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            booking.ChangeState(Action.Reopen);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Created));
        }

        [Test]
        public void ShouldNotChangeStatusToRefoundWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Refound);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Created));
        }

        [Test]
        public void ShouldNotChangeStatusToRefoundWhenRefoundingABookingWithFinishedStatus()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            booking.ChangeState(Action.Refound);
            Assert.That(booking.Status, Is.EqualTo(EStatus.Finished));

        }
    }
}