using static ToDoList.Program;

namespace ToDoList
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var todoList = new ToDoList();
            var availableKeys = new List<ConsoleKey>() { ConsoleKey.A, ConsoleKey.Q, ConsoleKey.S, ConsoleKey.E, ConsoleKey.R, ConsoleKey.D };
            var statusColor = new Dictionary<ToDoStatus, ConsoleColor>()
            {
                [ToDoStatus.InProgress] = ConsoleColor.Yellow,
                [ToDoStatus.Complete] = ConsoleColor.Green
            };

            todoList.AddToDo("Task #1");
            todoList.AddToDo("Task #2");
            todoList.AddToDo("Task #3");
            todoList.AddToDo("Task #4");

            var ui = new UI(todoList, statusColor);

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
                        ui.DisplayAllToDo();
                        break;
                    case ConsoleKey.E:
                        EditToDo(todoList, ui);
                        break;
                    case ConsoleKey.R:
                        RemoveToDo(todoList, ui);
                        break;
                    case ConsoleKey.D:
                        FinishToDo(todoList, ui);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private static void FinishToDo(ToDoList todoList, UI ui)
        {
            var selectedItem = ui.SelectToDo();
            selectedItem.ChangeStatus(ToDoStatus.Complete);
        }

        private static void RemoveToDo(ToDoList todoList, UI ui)
        {
            var selectedItem = ui.SelectToDo();
            todoList.Remove(selectedItem);
        }

        private static void EditToDo(ToDoList todoList, UI ui)
        {
            var selectedItem = ui.SelectToDo();

            if (selectedItem == null)
                return;

            Console.Clear();
            Console.WriteLine("Введите новое описание задачи:");
            var newDesctription = Console.ReadLine();
            selectedItem.ChangeDescription(newDesctription);
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
            Console.WriteLine("Отметить задачу как выполненную - D");
        }
    }

    
}

