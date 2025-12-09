using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class PlayerStatitic
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Assist {  get; set; }
        public int MinutesPlayed { get; set; }
        public int ScoredGoals { get; set; }
    }
}
