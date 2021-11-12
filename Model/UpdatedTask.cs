using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tasks.Model
{
    public class UpdatedTask
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public DateTimeOffset OnADay { get; set; }

        public DateTimeOffset AtATime { get; set; }

        public ETaskStatusModel? Status { get; set; }

        public ETaskRepeatModel? Repeat { get; set; }

        public ETaskPriorityModel? Priority { get; set; }

        public TaskLocation Location { get; set; }

        public string Url { get; set; }
    }
}