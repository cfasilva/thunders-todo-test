using System.ComponentModel.DataAnnotations;

namespace Thunders.Domain.DTOs.TaskDTO
{
    public class TaskEditDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
