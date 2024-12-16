

namespace ToDoList
{
    internal partial class Program
    {
        public class ToDoItem
        {
            public string Description { get; set; }

            public ToDoItem(string description)
            {
                Description = description;
            }

            public void ChangeDescription(string newDescription)
            {
                Description = newDescription;
            }

            public override string ToString()
            {
                return Description;
            }
        }
    }
}