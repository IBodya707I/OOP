using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class Bet
    {
        public int BetId { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public string Prediction { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }
    }
}
