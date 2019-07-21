using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExample.Models
{
    public class Category
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        
        public virtual ICollection<Job> jobs { get; set; }
        public Category()
        {
            this.jobs = new HashSet<Job>();
        }
    }
}