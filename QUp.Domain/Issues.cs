using QUp.Domain.Enums;

namespace QUp.Domain
{
    public class Issues
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        //Is Hotfix?git 
        public bool IsHotfix { get; set; }

        //TODO: Attachment

        [Required]
        public Feature Feature { get; set; }
        [Required]
        public UserStory Story { get; set; }
    }
}
