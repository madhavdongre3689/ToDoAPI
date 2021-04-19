using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAPI.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public User ToDoUser { get; set; }
        public Status status { get; set; } = Status.NotStarted;

        public DateTime? StartDate { get; set; }

        public DateTime? TargetDate { get; set; }
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        Completed

    }
}
