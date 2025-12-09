using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public bool IsInjurned { get; set; }
        public string Name { get; set; }
        [ForeignKey("Position")]
        public int Postionid { get; set; }
        public int SquadNumber { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public Position Position { get; set; }
    }
}
