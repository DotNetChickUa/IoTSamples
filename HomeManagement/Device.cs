namespace HomeManagement;

<<<<<<< HEAD
public class Device
{
    public required string Name { get; init; }

    public required string Ip { get; init; }

    public IList<DeviceAction> Actions { get; init; } = [];
=======
public record Device(string Name, string Ip, int UptimeSeconds)
{
    public IList<DeviceAction> Actions { get; init; } = new List<DeviceAction>();
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
}

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> fbc592b (Refactor and enhance device management system)
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
<<<<<<< HEAD
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
>>>>>>> fbc592b (Refactor and enhance device management system)
public record DeviceAction(string Action, CommandType CommandType, string Command, string? CommandArgs = null);

public enum CommandType
{
    Get,
    Post
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
>>>>>>> fbc592b (Refactor and enhance device management system)
}
=======
public record DeviceAction(string Action, string Command);
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> fbc592b (Refactor and enhance device management system)
=======
}
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
<<<<<<< HEAD
=======
=======
}
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
>>>>>>> fbc592b (Refactor and enhance device management system)
