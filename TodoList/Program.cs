var todos = new List<string>();

Console.WriteLine("Hello!");

bool shallExit = false;

while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODO's");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]remove a TODO");
    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "S":
            SeeAllTodos();
            break;
        case "A":
            AddTodo();
            break;
        case "R":
            RemoveTodo();
            break;
        case "E":
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid input!");
            break;
    }
}

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description: ");
        description = Console.ReadLine();
    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The description cannot be empty!");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine("The description must be unique!");
        return false;
    }

    return true;
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove: ");
        SeeAllTodos();
    }
    while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine($"TODO removed: {todoToBeRemoved}");
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();

    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty!");
        return false;
    }

    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }

    Console.WriteLine("Invalid index!");
    return false;

}

void ShowNoTodosMessage()
{
    Console.WriteLine("No TODO's have been added yet!");
}