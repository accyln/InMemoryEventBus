using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventQueueWithCAP.DataContext
{
    [Table("TestRun")]
    public class TestRun
    {


            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public int TestCaseId { get; set; }
            public int TestResultId { get; set; }
            public string? RunCode { get; set; }
        
    }
}
