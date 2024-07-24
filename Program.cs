

using System.Diagnostics.Metrics;

List<string> todos = new List<string>
{
    "Do the washing up",
    "Clean the kitchen"
};

string userChoice;

do
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userChoice = Console.ReadLine();
    int counter = 1;

    switch (userChoice)
    {
        case "s":
        case "S":
            ShowTodos(todos);
            break;

        case "a":
        case "A":
            AddTodo(todos);
            break;
        case "r":
        case "R":
            RemoveTodo(todos);
            break;
        case "e":
        case "E":
            PrintSelectedOption("Exit");
            Environment.Exit(0);
            break;
        default:
            PrintSelectedOption("Invalid choice!");
            break;


    }
} while (userChoice != "e" && userChoice != "E");




Console.ReadKey();



void ShowTodos(List<string> tudos)
{

    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
    }

    int counter = 1;

    foreach (var item in todos)
    {
        Console.WriteLine($"{counter}. {item}");
        counter++;
    }
}

void AddTodo(List<string> todos)
{
    string userAddedTodo;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        userAddedTodo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userAddedTodo))
        {
            Console.WriteLine("The description cannot be empty.");
        }
        else if (todos.Contains(userAddedTodo))
        {
            Console.WriteLine("The description must be unique.");
        }

    } while (string.IsNullOrWhiteSpace(userAddedTodo) || todos.Contains(userAddedTodo));

    todos.Add(userAddedTodo);
    Console.WriteLine("TODO item added!");
}

void RemoveTodo(List<string> todos)
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }

    bool validIndex = false;
    while (!validIndex)
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");

        int counter = 1;
        foreach (var item in todos)
        {
            Console.WriteLine($"{counter}. {item}");
            counter++;
        }

        if (int.TryParse(Console.ReadLine(), out int userRemovedIndex))
        {
            userRemovedIndex -= 1;

            if (userRemovedIndex >= 0 && userRemovedIndex < todos.Count)
            {
                string removedTodo = todos[userRemovedIndex];
                todos.RemoveAt(userRemovedIndex);
                Console.WriteLine("TODO removed: " + removedTodo);
                validIndex = true;
            }
            else
            {
                Console.WriteLine("Invalid index, no TODO item exists at this position.");
            }
        }
        else
        {
            Console.WriteLine("The given index is not valid.");
        }
    }
}

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}