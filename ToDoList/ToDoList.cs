

namespace ToDoList
{
    internal partial class Program
    {
        public class ToDoList
        {
            private List<ToDoItem> _todos;

            public ToDoList()
            {
                _todos = new List<ToDoItem>();
            }

            public bool IsEmpty => _todos.Count == 0;

            public void AddToDo(string description)
            {
                _todos.Add(new ToDoItem(description));
            }

            public IEnumerable<ToDoItem> GetAllToDos()
            {
                foreach (var item in _todos)
                {
                    yield return item;
                }
            }
        }
    }
}