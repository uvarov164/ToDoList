

using static ToDoList.Program;

namespace ToDoList
{
    internal partial class Program
    {
        public class ToDoList
        {
            private List<ToDoItem> _todos;
            private int _selectedIndex = 0;

            public ToDoList()
            {
                _todos = new List<ToDoItem>();
            }

            public bool IsEmpty => _todos.Count == 0;
            public int Count => _todos.Count;
            public int SelectedIndex 
            { 
                get 
                {
                    return Count == 0 ? -1 : _selectedIndex;
                }
                set
                {
                    _selectedIndex = (Count + value % Count) % Count;
                }
            }

            public ToDoItem this[int index]
            {
                get { return _todos[index]; }
                set { _todos[index] = value; }
            }

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

            public void Remove(int index)
            {
                _todos.RemoveAt(index);
            }
        }
    }
}