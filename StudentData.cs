using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Basic
{
    public class StudentData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configure as auto-incrementing primary key
        public int StudentId { get; set; }

        // Other properties
        public string StudentName { get; set; }
        public int StudentFees { get; set; }
        public string StudentHomeCity { get; set; }
    }
}
