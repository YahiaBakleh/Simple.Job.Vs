using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExample.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        public Category CategoryID { get; set; }

    }
}