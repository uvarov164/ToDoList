using static ToDoList.Program;

namespace ToDoList
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var todoList = new ToDoList();
            var availableKeys = new List<ConsoleKey>() { ConsoleKey.A, ConsoleKey.Q, ConsoleKey.S, ConsoleKey.E, ConsoleKey.R };

            

            while (true)
            {
                DrawMainMenu();
                var inputKey = Console.ReadKey(true).Key;

                if (availableKeys.Contains(inputKey))
                    Console.Clear();

                switch (inputKey)
                {
                    case ConsoleKey.Q:
                        return;
                    case ConsoleKey.A:
                        AddCommandExecute(todoList);
                        break;
                    case ConsoleKey.S:
                        ShowAllToDo(todoList);
                        break;
                    case ConsoleKey.E:
                        EditToDo(todoList);
                        break;
                    case ConsoleKey.R:
                        RemoveToDo(todoList);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private static void RemoveToDo(ToDoList todoList)
        {
            var selectedItem = SelectToDo(todoList);
            todoList.Remove(selectedItem);
        }

        private static void EditToDo(ToDoList todoList)
        {
            var selectedItem = SelectToDo(todoList);

            if (selectedItem == null)
                return;

            Console.Clear();
            Console.WriteLine("Введите новое описание задачи:");
            var newDesctription = Console.ReadLine();
            selectedItem.ChangeDescription(newDesctription);
        }

        private static ToDoItem SelectToDo(ToDoList todoList)
        {
            if (todoList.IsEmpty)
            {
                DisplayEmptyToDoList();
                return null;
            }

            while (true)
            {
                DisplayWithHighlited(todoList);
                var inputKey = Console.ReadKey(true).Key;
                switch (inputKey)
                {
                    case ConsoleKey.UpArrow:
                        todoList.SelectedIndex -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        todoList.SelectedIndex += 1;
                        break;
                    case ConsoleKey.Enter:
                        return todoList[todoList.SelectedIndex];
                    default:
                        break;
                }
                Console.SetCursorPosition(0, 0);
            }
        }

        private static void DisplayWithHighlited(ToDoList todoList)
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                if (i == todoList.SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(todoList[i]);
                    Console.ResetColor();
                    continue;
                }
                Console.WriteLine(todoList[i]);
            }
        }

        private static void ShowAllToDo(ToDoList todoList)
        {
            if (todoList.IsEmpty)
            {
                Console.WriteLine("Список задач пуст!");
                Console.ReadKey(true);
                return;
            }

            foreach (var item in todoList.GetAllToDos())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey(true);
        }

        private static void AddCommandExecute(ToDoList todoList)
        {
            Console.WriteLine("Введите описание задачи:");
            var description = Console.ReadLine();
            todoList.AddToDo(description);
        }

        private static void DrawMainMenu()
        {
            Console.WriteLine("Добавить задачу - A");
            Console.WriteLine("Выйти - Q");
            Console.WriteLine("Показать все задачи - S");
            Console.WriteLine("Редактировать задачу - E");
            Console.WriteLine("Удалить задачу - R");
        }

        private static void DisplayEmptyToDoList()
        {
            Console.WriteLine("Список задач пуст!");
            Console.ReadKey(true);
        }
    }
}