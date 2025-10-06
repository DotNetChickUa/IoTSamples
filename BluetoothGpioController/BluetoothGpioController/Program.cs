using BluetoothGpioController;

/*
 * 1. rfkill unblock bluetooth
 * 2. bluetoothctl
 * 3. power on
 * 4. agent on
 * 5. default-agent
 * 5. scan on
 * 6. pair <MAC>
 * 7. trust <MAC>
 * 8. connect <MAC>
<<<<<<< HEAD
 * 9. scp -r "linux-arm64/*.*" anastasia@raspberrypi-zero-2w.local:/home/anastasia/Projects/BluetoothGpioController
 * 10. ssh anastasia@raspberrypi-zero-2w.local
 * 11. chmod +x /home/anastasia/Projects/BluetoothGpioController/BluetoothGpioController
 * 12. chmod +x /home/anastasia/Projects/BluetoothGpioController/BluetoothGpioController.dll
 * 13. rm BluetoothGpioController -d -r
=======
 * 9. scp "linux-arm64/*.*" anastasia@raspberrypi-zero-2w.local:/home/anastasia/Projects/BluetoothGpioController
 * 10. ssh anastasia@raspberrypi-zero-2w.local
 * 11. chmod +x /home/anastasia/Projects/BluetoothGpioController/BluetoothGpioController
 * 12. chmod +x /home/anastasia/Projects/BluetoothGpioController/BluetoothGpioController.dll
>>>>>>> fec4208 (Add Reboot and Shutdown commands)
 */

const string logFilePath = "Logs.txt";
if (File.Exists(logFilePath))
{
    File.Delete(logFilePath);
}

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<AppSettings>(builder.Configuration);
#if DEBUG
builder.Services.AddLogging(b => b.AddConsole().AddProvider(new FileSystemLoggerProvider(logFilePath)));
#endif

var host = builder.Build();
host.Run();