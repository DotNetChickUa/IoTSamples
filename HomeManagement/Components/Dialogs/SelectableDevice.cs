namespace HomeManagement.Components.Dialogs;

<<<<<<< HEAD
public class NetworkDevice : Device
{
    public int UptimeSeconds { get; init; }
}

public class SelectableDevice
{
    public required NetworkDevice Device { get; init; }
    public bool Selected { get; set; }
}
=======
public class SelectableDevice
{
    public required HomeManagement.Device Device { get; set; }
    public bool Selected { get; set; }
}
>>>>>>> fbc592b (Refactor and enhance device management system)
