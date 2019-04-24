using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models {
    public class BranchHours {
        [Key]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public LibraryBranch Branch { get; set; }
        public int DayOfWeek { get; set; }
        public int OpenTime { get; set; }
        public int CloseTime { get; set; }
    }
}
