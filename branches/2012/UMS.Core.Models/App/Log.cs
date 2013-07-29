using System;
using System.ComponentModel.DataAnnotations;

namespace UMS.Core.Data.Models.App
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        [StringLength(20)]
        public string Level { get; set; }

        [StringLength(255)]
        public string Logger { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }
    }
}
