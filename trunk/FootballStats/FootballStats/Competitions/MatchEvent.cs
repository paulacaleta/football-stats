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
            this.minuteOfEvent = minuteOfEvent;
            this.activeSide = activeSide;
            this.passiveSide = passiveSide;
            this.playerInvolved = playerInvolved;
            this.eventType = eventType;
        }

        public int MinuteOfEvent
        {
            get
            {
                return this.minuteOfEvent;
            }
            set
            {
                // TODO: 1 to 130
                this.minuteOfEvent = value;
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
    }
}
