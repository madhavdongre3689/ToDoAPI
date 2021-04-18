using System.Collections.Generic;

namespace ToDoListAPI.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<ToDoItem> ToDoItems { get; set; }
    }
}