using System;

namespace wedding_planner.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAT { get; set; }
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAT = DateTime.Now;
        }
    }
}