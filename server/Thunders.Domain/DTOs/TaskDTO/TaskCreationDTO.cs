using System.ComponentModel.DataAnnotations;

namespace Thunders.Domain.DTOs.TaskDTO
{
    public class TaskCreationDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
