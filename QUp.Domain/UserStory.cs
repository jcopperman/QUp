using QUp.Domain.Enums;
using QUp.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace QUp.Domain
{
    public class UserStory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsAutomated { get; set; }

        public Keywords Keywords { get; set; }

        public Status Status { get; set; }

        [Required]
        public Feature Feature { get; set; }

    }
}
