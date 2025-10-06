namespace HomeManagement.Components.Dialogs;

public class DeviceEditModel
{
    public string Name { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public List<DeviceActionEditModel> Actions { get; set; } = new();
}

public class DeviceActionEditModel
{
    public string Action { get; set; } = string.Empty;
    public string Command { get; set; } = string.Empty;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
    public CommandType CommandType { get; set; } = CommandType.Get;
    public string? CommandArgs { get; set; } = null;
=======
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
=======
    public CommandType CommandType { get; set; } = CommandType.Get;
    public string? CommandArgs { get; set; } = null;
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
}
