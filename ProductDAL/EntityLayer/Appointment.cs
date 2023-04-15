using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.EntityLayer
{

    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime AptDate { get; set; }

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        //public User User { get; set; }

    }
}
