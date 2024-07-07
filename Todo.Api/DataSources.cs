using Todo.Domain.Models;

namespace Todo.Api
{
    public class DataSource
    {
        public DataSource()
        {
            TodoLists = GenerateTodoLists();
        }

        public List<TodoItem> TodoLists { get; set; }

        private List<TodoItem> GenerateTodoLists()
        {
            return new List<TodoItem>
      {
        new TodoItem
        {
            Title = "Membuat todo list",
            Description = "Memuat todo list untuk latihan C# pertama",
            Deadline = DateTime.Now.AddHours(2),
        },
        new TodoItem
        {
            Title = "Membuat expense tracker",
            Description = "Membuat expense tracker dengan DDD",
            Deadline = DateTime.Now.AddDays(2),
        },
        new TodoItem
        {
            Title = "Belajar ASP.NET",
            Description = "Mempelajari dasar-dasar ASP.NET Core",
            Deadline = DateTime.Now.AddDays(3),
        },
        new TodoItem
        {
            Title = "Implementasi Repository Pattern",
            Description = "Mengimplementasikan Repository Pattern pada proyek",
            Deadline = DateTime.Now.AddHours(5),
        },
        new TodoItem
        {
            Title = "Membuat unit test",
            Description = "Menulis unit test untuk aplikasi",
            Deadline = DateTime.Now.AddDays(1),
        },
        new TodoItem
        {
            Title = "Refactor kode",
            Description = "Melakukan refactor pada kode yang ada",
            Deadline = DateTime.Now.AddHours(4),
        },
        new TodoItem
        {
            Title = "Setup CI/CD",
            Description = "Mengatur Continuous Integration dan Continuous Deployment",
            Deadline = DateTime.Now.AddDays(5),
        },
        new TodoItem
        {
            Title = "Pelajari Design Patterns",
            Description = "Mempelajari berbagai design patterns dalam pemrograman",
            Deadline = DateTime.Now.AddDays(7),
        },
        new TodoItem
        {
            Title = "Integrasi API",
            Description = "Melakukan integrasi dengan API eksternal",
            Deadline = DateTime.Now.AddHours(8),
        },
        new TodoItem
        {
            Title = "Membuat dokumentasi proyek",
            Description = "Menulis dokumentasi untuk proyek yang sedang dikerjakan",
            Deadline = DateTime.Now.AddDays(10),
        }
      };
        }
    }
}
