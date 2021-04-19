using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Models
{
    public class TodoSeeder
    {
        ToDoContext _context;
        public TodoSeeder(ToDoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Database.CanConnect())
            {
                if(!_context.ToDoItems.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var user = new User
            {
                Email = "abcd@email.com",
                FirstName = "Madhav",
                LastName = "Dongre",
            };
            var toDoItems = new List<ToDoItem>
                 {
                    new ToDoItem{
                     ToDoUser=user,
                     Title="Design",
                     Description="Deisgn the Modules",
                     status=Status.NotStarted
                    },
                    new ToDoItem{

                    Title="Coding",
                    Description="Implement the feature ",
                    status=Status.NotStarted
                    },
                    new ToDoItem{

                    Title="Dev Testing",
                    Description="Test the functionality",
                    status=Status.NotStarted
                    },
                    new ToDoItem{

                    Title ="Code Review",
                    Description="Perform CodeReview",
                    status=Status.NotStarted
                    },
                   
                    new ToDoItem{

                    Title ="Testing",
                    Description="Perform Feature Testing",
                    status=Status.NotStarted
                    },
                    new ToDoItem{

                    Title ="System Testing",
                    Description="Perform System Testing",
                    status=Status.NotStarted
                    },
                    new ToDoItem{

                    Title ="Release",
                    Description="Release the feature",
                    status=Status.NotStarted
                    }
                    
                 };
            _context.Users.Add(user);
            _context.ToDoItems.AddRange(toDoItems);
            _context.SaveChanges();
           
        }
    }
}
