using QUp.Domain.Enums;
using QUp.Domain.Interfaces;
using System;

namespace QUp.Domain
{
    public class Feature 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Keywords Keywords { get; set; }

        public Status Status { get; set; }
        //TODO: Add attachments

        [Required]
        public Sprint Sprint { get; set; }

    }
}
