using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.ExtensionMethods;
using Ical.Net.Interfaces;
using NUnit.Framework;

namespace ical.NET.UnitTests
{
    [TestFixture]
    public class EventTest
    {
        private string _tzid;

        [TestFixtureSetUp]
        public void InitAll()
        {
            _tzid = "US-Eastern";
        }
        
        /// <summary>
        /// Ensures that events can be properly added to a calendar.
        /// </summary>
        [Test, Category("Event")]
        public void Add1()
        {
            IICalendar iCal = new ICalendar();
            
            var evt = new Event();
            evt.Summary = "Testing";
            evt.Start = new CalDateTime(2010, 3, 25);
            evt.End = new CalDateTime(2010, 3, 26);
            
            iCal.Events.Add(evt);
            Assert.AreEqual(1, iCal.Children.Count);
            Assert.AreSame(evt, iCal.Children[0]);            
        }

        /// <summary>
        /// Ensures that events can be properly removed from a calendar.
        /// </summary>
        [Test, Category("Event")]
        public void Remove1()
        {
            IICalendar iCal = new ICalendar();

            var evt = new Event();
            evt.Summary = "Testing";
            evt.Start = new CalDateTime(2010, 3, 25);
            evt.End = new CalDateTime(2010, 3, 26);

            iCal.Events.Add(evt);
            Assert.AreEqual(1, iCal.Children.Count);
            Assert.AreSame(evt, iCal.Children[0]);

            iCal.RemoveChild(evt);
            Assert.AreEqual(0, iCal.Children.Count);
            Assert.AreEqual(0, iCal.Events.Count);
        }

        /// <summary>
        /// Ensures that events can be properly removed from a calendar.
        /// </summary>
        [Test, Category("Event")]
        public void Remove2()
        {
            IICalendar iCal = new ICalendar();

            var evt = new Event();
            evt.Summary = "Testing";
            evt.Start = new CalDateTime(2010, 3, 25);
            evt.End = new CalDateTime(2010, 3, 26);

            iCal.Events.Add(evt);
            Assert.AreEqual(1, iCal.Children.Count);
            Assert.AreSame(evt, iCal.Children[0]);

            iCal.Events.Remove(evt);
            Assert.AreEqual(0, iCal.Children.Count);
            Assert.AreEqual(0, iCal.Events.Count);
        }
    }
}
