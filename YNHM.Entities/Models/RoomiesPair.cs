using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YNHM.Entities.Models
{
    public class RoomiesPair
    {
        [Key]
        [Column(Order = 1)]
        public int RoomieOneId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RoomieTwoId { get; set; }
        public int MatchPercentage { get; set; }
    }
}
