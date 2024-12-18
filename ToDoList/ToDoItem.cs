

namespace ToDoList
{
    internal partial class Program
    {
        public class ToDoItem
        {
            public string Description { get; set; }
            public ToDoStatus Status { get; set; }

            public ToDoItem(string description, ToDoStatus status)
            {
                Description = description;
                Status = status;
            }

            public void ChangeDescription(string newDescription)
            {
                Description = newDescription;
            }

            public void ChangeStatus(ToDoStatus newStatus)
            {
                Status = newStatus;
            }

            public override string ToString()
            {
                return Description;
            }
        }
    }
}