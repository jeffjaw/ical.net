using System;
using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Interfaces.General;
using Ical.Net.Serialization.iCalendar.Serializers.DataTypes;

namespace Ical.Net.DataTypes
{
    /// <summary>
    /// Represents a time offset from UTC (Coordinated Universal Time).
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class UtcOffset : EncodableDataType, IUtcOffset
    {
        public TimeSpan Offset { get; set; }

        public bool Positive => Offset >= TimeSpan.Zero;

        public int Hours => Math.Abs(Offset.Hours);

        public int Minutes => Math.Abs(Offset.Minutes);

        public int Seconds => Math.Abs(Offset.Seconds);

        public UtcOffset() { }

        public UtcOffset(string value) : this()
        {
            Offset = UtcOffsetSerializer.GetOffset(value);
        }

        public UtcOffset(TimeSpan ts)
        {
            Offset = ts;
        }

        static public implicit operator UtcOffset(TimeSpan ts) => new UtcOffset(ts);

        static public explicit operator TimeSpan(UtcOffset o) => o.Offset;

        virtual public DateTime ToUtc(DateTime dt) => DateTime.SpecifyKind(dt.Add(-Offset), DateTimeKind.Utc);

        virtual public DateTime ToLocal(DateTime dt) => DateTime.SpecifyKind(dt.Add(Offset), DateTimeKind.Local);

        protected bool Equals(UtcOffset other)
        {
            return Offset == other.Offset;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((UtcOffset)obj);
        }

        public override int GetHashCode()
        {
            return Offset.GetHashCode();
        }

        public override void CopyFrom(ICopyable obj)
        {
            base.CopyFrom(obj);
            if (obj is IUtcOffset)
            {
                var utco = (IUtcOffset)obj;
                Offset = utco.Offset;
            }
        }

        public override string ToString()
        {
            return (Positive ? "+" : "-") + Hours.ToString("00") + Minutes.ToString("00") +
                   (Seconds != 0 ? Seconds.ToString("00") : string.Empty);
        }
    }
}