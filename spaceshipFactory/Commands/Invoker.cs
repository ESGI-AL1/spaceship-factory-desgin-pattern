namespace spaceshipFactory.Commands;

public class Invoker
{
    private readonly Queue<ICommand> _commands = new Queue<ICommand>();

    public void SetCommand(ICommand command)
    {
        _commands.Enqueue(command);
    }

    public void ExecuteCommands()
    {
        while (_commands.Count > 0)
        {
            var command = _commands.Dequeue();
            command.Execute();
        }
    }
}
