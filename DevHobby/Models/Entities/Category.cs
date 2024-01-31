﻿namespace DevHobby.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Course>? Courses { get; set; }

    }
}