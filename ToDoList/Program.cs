
namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todoList = new ToDoList();
            var availableKeys = new List<ConsoleKey>() { ConsoleKey.A, ConsoleKey.Q };
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
                        Console.WriteLine("Введите описание задачи:");
                        var description = Console.ReadLine();
                        todoList.AddToDo(description);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private static void DrawMainMenu()
        {
            Console.WriteLine("Добавить задачу - A");
            Console.WriteLine("Выйти - Q");
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
}