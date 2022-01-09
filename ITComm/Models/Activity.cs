using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITComm.Models
{
    [Table("ACTIVITIES")]
    public class Activity
    {
        [Key]
        [Column("ACT_NAME")]
        public string activityName { get; set; }
        [Column("CATEGORY")]
        public string category { get; set; }

        public Activity(string activityName, string category)
        {
            this.activityName = activityName;
            this.category = category;
        }
    }
}
