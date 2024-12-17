

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
                    default:
                        break;
                }
                Console.Clear();
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
        }
    }
}