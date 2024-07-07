using System;
using NUlid;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models
{
    public class TodoItem
    {

        public TodoItem()
        {
            Id = Ulid.NewUlid().ToString();
            IsDone = false;
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public static class TodoItemExtensions
    {
        public static bool IsValid(this TodoItem todoItem)
        {
            if (string.IsNullOrEmpty(todoItem.Title))
            {
                return false;
            }

            if (string.IsNullOrEmpty(todoItem.Description))
            {
                return false;
            }

            if (todoItem.Deadline <= DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}

