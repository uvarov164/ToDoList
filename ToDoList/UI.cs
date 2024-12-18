namespace ToDoList
{
    internal partial class Program
    {
        public class UI
        {
            private ToDoList _todoList;
            private Dictionary<ToDoStatus, ConsoleColor> _statusColor;

            public UI(ToDoList todoList, Dictionary<ToDoStatus, ConsoleColor> statusColor)
            {
                _todoList = todoList;
                _statusColor = statusColor;
            }

            public void DisplayAllToDo()
            {
                if (_todoList.IsEmpty)
                {
                    DisplayEmptyToDoList();
                    return;
                }

                foreach (var item in _todoList.GetAllToDos())
                {
                    DisplayToDoItem(item);
                }

                Console.ReadKey(true);
            }

            public ToDoItem SelectToDo()
            {
                if (_todoList.IsEmpty)
                {
                    DisplayEmptyToDoList();
                    return null;
                }

                while (true)
                {
                    DisplayWithHighlited();
                    var inputKey = Console.ReadKey(true).Key;
                    switch (inputKey)
                    {
                        case ConsoleKey.UpArrow:
                            _todoList.SelectedIndex -= 1;
                            break;
                        case ConsoleKey.DownArrow:
                            _todoList.SelectedIndex += 1;
                            break;
                        case ConsoleKey.Enter:
                            return _todoList[_todoList.SelectedIndex];
                        default:
                            break;
                    }
                    Console.SetCursorPosition(0, 0);
                }
            }

            public void DisplayWithHighlited()
            {

                for (int i = 0; i < _todoList.Count; i++)
                {
                    if (i == _todoList.SelectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        DisplayToDoItem(_todoList[i]);
                        Console.ResetColor();
                        continue;
                    }
                    DisplayToDoItem(_todoList[i]);
                }
            }

            private void DisplayToDoItem(ToDoItem item)
            {
                Console.Write(item + " ");
                Console.ResetColor();
                Console.ForegroundColor = _statusColor[item.Status];
                Console.Write(item.Status);
                Console.ResetColor();
                Console.WriteLine();
            }

            public void DisplayEmptyToDoList()
            {
                Console.WriteLine("Список задач пуст!");
                Console.ReadKey(true);
            }
        }
    }

    
}

