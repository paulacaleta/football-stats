namespace FootballStats.Competitions
{
    using System;

    public class FinalScore
    {
        private int homeTeam;
        private int awayTeam;

        public FinalScore(int homeTeam, int awayTeam)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }

        public int HomeTeam
        {
            get
            {
                return this.homeTeam;
            }

            set
            {
                if (value > 0)
                {
                    this.homeTeam = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Score cannot be negative!");
                }
            }
        }

        public int AwayTeam
        {
            get
            {
                return this.awayTeam;
            }

            set
            {
                if (value > 0)
                {
                    this.awayTeam = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Score cannot be negative!");
                }
            }
        }

        public override string ToString()
        {
            string returnValue = string.Format("FINAL GAME SCORE IS: {0}/{1}\n", this.HomeTeam, this.AwayTeam);
            return returnValue.ToString();
        }
    }
}
