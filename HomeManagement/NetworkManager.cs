<<<<<<< HEAD
using HomeManagement.Components.Dialogs;
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
using System.Net.NetworkInformation;
using System.Net.Sockets;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
using System.Text.Json;
using System.Text.Json.Serialization;
=======
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
using System.Text.Json;
using System.Text.Json.Serialization;
>>>>>>> a319cbf (Get Status, Update to .NET 10)
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)

namespace HomeManagement;

public class NetworkManager
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
    public static async Task<List<Device>> ScanNetworkAsync(string baseIP, int timeout, CancellationToken token)
=======
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public static async Task<List<NetworkDevice>> ScanNetworkAsync(string baseIp, int timeout, CancellationToken token)
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
<<<<<<< HEAD
=======
    public static async Task<List<NetworkDevice>> ScanNetworkAsync(string baseIP, int timeout, CancellationToken token)
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
    {
        var tasks = new List<Task<NetworkDevice?>>();
=======
    {
        var tasks = new List<Task<Device?>>();
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)

        for (var i = 1; i <= 254; i++)
        {
            var ip = baseIp + i;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
    public static async Task<List<Device>> ScanNetworkAsync(string baseIP, int timeout, CancellationToken token)
    {
        var tasks = new List<Task<Device?>>();

        for (int i = 1; i <= 254; i++)
        {
            string ip = baseIP + i;
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
            tasks.Add(PingAndResolveAsync(ip, timeout, token));
        }

        var results = await Task.WhenAll(tasks);
<<<<<<< HEAD
        return results.OfType<NetworkDevice>().ToList();
    }

    static async Task<NetworkDevice?> PingAndResolveAsync(string ip, int timeout, CancellationToken token)
=======
        return results.OfType<Device>().ToList();
    }

    static async Task<Device?> PingAndResolveAsync(string ip, int timeout, CancellationToken token)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
    {
        using Ping ping = new();
        try
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
            var reply = await ping.SendPingAsync(ip, TimeSpan.FromMilliseconds(timeout), cancellationToken: token);
=======
            PingReply reply = await ping.SendPingAsync(ip, TimeSpan.FromMilliseconds(timeout), cancellationToken: token);
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
=======
            var reply = await ping.SendPingAsync(ip, TimeSpan.FromMilliseconds(timeout), cancellationToken: token);
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
            var reply = await ping.SendPingAsync(ip, TimeSpan.FromMilliseconds(timeout), cancellationToken: token);
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
            if (reply.Status == IPStatus.Success)
            {
                return await GetDeviceInfoAsync(ip, token);
            }
        }
        catch
        {
            // Ignore failures
        }

        return null;
    }

    public static string? GetLocalSubnet()
    {
        var subnetBytes = GetSubnets();
        if (subnetBytes is null)
        {
            return null;
        }

        return $"{subnetBytes[0]}.{subnetBytes[1]}.{subnetBytes[2]}.";
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
    public static string? GetLocalIp()
    {
        var subnetBytes = GetSubnets();
        if (subnetBytes is null)
        {
            return null;
        }

        return $"{subnetBytes[0]}.{subnetBytes[1]}.{subnetBytes[2]}.{subnetBytes[3]}";
    }
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
<<<<<<< HEAD
=======
    public static string? GetLocalIp()
    {
        var subnetBytes = GetSubnets();
        if (subnetBytes is null) return null;
        return $"{subnetBytes[0]}.{subnetBytes[1]}.{subnetBytes[2]}.{subnetBytes[3]}";
    }
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)

    public static byte[]? GetSubnets()
    {
        foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======

    public static byte[]? GetSubnets()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
        {
            if (ni.OperationalStatus != OperationalStatus.Up)
            {
                continue;
            }

            if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
            {
                continue; // skip loopback
            }

            var ipProps = ni.GetIPProperties();
            foreach (var ipInfo in ipProps.UnicastAddresses)
            {
                if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    var ipBytes = ipInfo.Address.GetAddressBytes();
                    return ipBytes;
                }
            }
        }

        return null;
    }

<<<<<<< HEAD
    public static async Task<NetworkDevice?> GetDeviceInfoAsync(string address, CancellationToken token)
=======
    private static async Task<Device?> GetDeviceInfoAsync(string ip, CancellationToken token)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
        using var httpClient = new HttpClient();
        return await httpClient.GetFromJsonAsync<Device>($"http://{ip}/info", token);
=======
        try
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<NetworkDevice>($"http://{address}/info", JsonSerializerOptions, token);
<<<<<<< HEAD
=======
        try
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<NetworkDevice>($"http://{address}/info", token);
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
        }
        catch (Exception)
        {
            return null;
        }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
<<<<<<< HEAD
=======
>>>>>>> 3548e6a (Get Status, Update to .NET 10)
<<<<<<< HEAD
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
        using var httpClient = new HttpClient();
        return await httpClient.GetFromJsonAsync<Device>($"http://{ip}/info", token);
>>>>>>> eeff7ac (Refactor and enhance device management system)
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
=======
=======
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
<<<<<<< HEAD
>>>>>>> a319cbf (Get Status, Update to .NET 10)
=======
>>>>>>> 0efb677 (Add Dashboard, Add Auth)
>>>>>>> 5be7bab (Add Dashboard, Add Auth)
>>>>>>> a123fff (Add Dashboard, Add Auth)
>>>>>>> 3d0106c (Add Dashboard, Add Auth)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
=======
=======
>>>>>>> a319cbf (Get Status, Update to .NET 10)
>>>>>>> 0de0591 (Get Status, Update to .NET 10)
>>>>>>> d4eca16 (Get Status, Update to .NET 10)
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 5e15dfb (Refactor and enhance device management system)
=======
>>>>>>> 33bd328 (Add Dashboard, Add Auth)
>>>>>>> 0e1ba11 (Add Dashboard, Add Auth)
=======
>>>>>>> 5e49c9a (Get Status, Update to .NET 10)
    }
}
