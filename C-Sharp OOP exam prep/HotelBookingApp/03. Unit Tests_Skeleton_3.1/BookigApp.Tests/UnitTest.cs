using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private Room room;
        private Booking booking;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Lazarus", 5);
            room = new Room(4, 2);
            booking = new Booking(1, room, 1);

        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var expectedName = "Lazarus";
            var expectedCategory = 5;
            var actualName = hotel.FullName;
            var actualCategory = hotel.Category;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCategory, actualCategory);
        }

        [Test]
        public void IfFullNameIsNullOrWhiteSpaceThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var hotel2 = new Hotel(null, 5);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                var hotel2 = new Hotel(" ", 5);
            });
        }

        [Test]
        public void CategoryThrowsExceptionIfZeroOrLessAndSixorMore()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var hotel2 = new Hotel("Lazarus", 0);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var hotel2 = new Hotel("Lazarus", 6);
            });
        }

        [Test]
        public void TurnOverShouldBeZeroWhenInitialized()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void AddRoomAddsARoomToTheHotel()
        {
            var room2 = new Room(5, 5);
            hotel.AddRoom(room2);
            Assert.AreEqual(room2, hotel.Rooms.FirstOrDefault(r => r.Equals(room2)));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoomThrowsExceptionIfAdultsAreZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 2, 2, 2);
            });
        }

        [Test]
        public void BookRoomThrowsExceptionIfChildrenAreLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, -1, 2, 2);
            });
        }

        [Test]
        public void BookRoomThrowsExceptionIfDurationIsLessThanOne()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 2, 0, 2);
            });
        }

        [Test]
        public void BookRoomDoesntAddABookingIfBedsAreLessThanBedsNeeded()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(4, 2, 2, 2);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookRoomDoesntAddABookingIfBudgetIsNotEnough()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(4, 2, 2, 2);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookRoomShouldWorkCorrectly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 2, 2, 5);
            var expectedTurnOver = 4;
            Assert.AreEqual(expectedTurnOver, hotel.Turnover);
            Assert.That(hotel.Bookings.Count.Equals(1));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }
    }
}