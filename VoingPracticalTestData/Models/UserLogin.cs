using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoingPracticalTestData.Models
{
    public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserLoginId { get; set; }
        [ForeignKey("UserDetail")]
        public long UserId { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLoggedOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
