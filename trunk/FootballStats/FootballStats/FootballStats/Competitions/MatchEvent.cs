namespace FootballStats.Competitions
{
    using System;
    using FootballStats.Clubs;
    using FootballStats.Persons;

    public class MatchEvent
    {
        private int minuteOfEvent;
        private Club activeSide;
        private Club passiveSide;
        private Player playerInvolved;
        private EventType eventType;

        public MatchEvent(int minuteOfEvent, Club activeSide, Club passiveSide, Player playerInvolved, EventType eventType)
        {
            this.MinuteOfEvent = minuteOfEvent;
            this.ActiveSide = activeSide;
            this.PassiveSide = passiveSide;
            this.PlayerInvolved = playerInvolved;
            this.EventType = eventType;
        }

        #region Properties

        public int MinuteOfEvent
        {
            get
            {
                return this.minuteOfEvent;
            }

            set
            {
                if (value > 0 && value < 130)
                {
                    this.minuteOfEvent = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Club ActiveSide
        {
            get
            {
                return this.activeSide;
            }

            set
            {
                this.activeSide = value;
            }
        }

        public Club PassiveSide
        {
            get
            {
                return this.passiveSide;
            }

            set
            {
                this.passiveSide = value;
            }
        }

        public Player PlayerInvolved
        {
            get
            {
                return this.playerInvolved;
            }

            set
            {
                this.playerInvolved = value;
            }
        }

        public EventType EventType
        {
            get
            {
                return this.eventType;
            }

            set
            {
                this.eventType = value;
            }
        }

        #endregion

        public override string ToString()
        {
            string information = string.Format("Event Type: {0}\nEvent minute:{1}\nEvent active side: {2}\n" +
            "Event passive side: {3}\nEvent player involved: {4}\n",
            this.EventType, this.MinuteOfEvent, this.ActiveSide.Name, this.PassiveSide.Name, this.PlayerInvolved.GetName());

            return information.ToString();
        }
    }
}
