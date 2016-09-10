using QUp.Domain.Enums;
using QUp.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace QUp.Domain
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime SprintStartDate { get; set; }
        public DateTime SprintEndDate { get; set; }

        public Status Status { get; set; }

        [Required]
        public Project Project { get; set; }


    }
}
