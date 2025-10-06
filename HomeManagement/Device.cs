namespace HomeManagement;

public class Device
{
    public required string Name { get; init; }

    public required string Ip { get; init; }

    public IList<DeviceAction> Actions { get; init; } = [];
}

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
public record DeviceAction(string Action, CommandType CommandType, string Command, string? CommandArgs = null);

public enum CommandType
{
    Get,
    Post
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
}
=======
public record DeviceAction(string Action, string Command);
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
=======
}
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
