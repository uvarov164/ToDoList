namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todoList = new ToDoList();
            todoList.AddToDo("Task #1");
            todoList.AddToDo("Task #2");
            todoList.AddToDo("Task #3");
        }
    }

    public class ToDoList
    {
        private List<ToDoItem> _todos;

        public ToDoList()
        {
            _todos = new List<ToDoItem>();
        }

        public void AddToDo(string description)
        {
            _todos.Add(new ToDoItem(description));
        }
    }

    public class ToDoItem
    {
        public string Description { get; set; }

        public ToDoItem(string description)
        {
            Description = description;
        }
    }
}
