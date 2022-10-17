using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(MaxTaskTitle)]
        public string Title { get; set; }
        [Required]
        [StringLength(MaxTaskDescription)]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; init; }
        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; init; }
    }
}
