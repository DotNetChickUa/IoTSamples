using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Maui.Alerts;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace BluetoothController.Client;

public partial class MainPage : ContentPage
{
    public ObservableCollection<IDevice> Devices { get; set; } = new();

    public ObservableCollection<string> Commands { get; set; } = new()
    {
        "GPIO",
        "REBOOT",
        "SHUTDOWN"
    };

<<<<<<< HEAD
	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var ble = CrossBluetoothLE.Current;
		var adapter = CrossBluetoothLE.Current.Adapter;
		ble.StateChanged += (s, e) =>
		{
			Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
		};
		adapter.DeviceDiscovered += async (s, a) =>
		{
			try
			{
				await adapter.ConnectToDeviceAsync(a.Device);
				var service = await a.Device.GetServiceAsync(Guid.Parse("12345678-1234-5678-1234-56789abcdef0"));
				var characteristic = await service.GetCharacteristicAsync(Guid.Parse("12345678-1234-5678-1234-56789abcdef1"));
<<<<<<< HEAD:BluetoothGpioController.Client/MainPage.xaml.cs
				await characteristic.WriteAsync(Encoding.Default.GetBytes("19;1"));
				await characteristic.WriteAsync(Encoding.Default.GetBytes("19;0"));
=======
<<<<<<< HEAD
				await characteristic.WriteAsync(Encoding.Default.GetBytes("19;OUTPUT;1"));
				await characteristic.WriteAsync(Encoding.Default.GetBytes("19;OUTPUT;0"));
=======
				await characteristic.WriteAsync(Encoding.Default.GetBytes("10;OUTPUT;1;password"));
				await characteristic.WriteAsync(Encoding.Default.GetBytes("10;INPUT;0;password"));
>>>>>>> 9e2922b (Add Password)
>>>>>>> 8b67ad0 (Add Password):BluetoothGpioController/BluetoothGpioController.Client/MainPage.xaml.cs
			}
			catch (Exception e)
			{
				// ... could not connect to device
			}
		};
		await adapter.StartScanningForDevicesAsync();
	}
=======
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        Password.Text = Preferences.Get("Password", string.Empty);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CommandsPicker.SelectedIndex = 0;
        await Permissions.RequestAsync<Permissions.Bluetooth>();
        CrossBluetoothLE.Current.StateChanged += async (s, e) =>
        {
            await Toast.Make($"The bluetooth state changed to {e.NewState}").Show();
        };
        CrossBluetoothLE.Current.Adapter.DeviceDiscovered += async (s, a) =>
        {
            if (!Devices.Contains(a.Device))
            {
                Devices.Add(a.Device);
            }
        };
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await CrossBluetoothLE.Current.Adapter.StartScanningForDevicesAsync();
    }

    private async void SelectableItemsView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var device = e.CurrentSelection.OfType<IDevice>().FirstOrDefault();
        if (device == null) return;
        try
        {
            await CrossBluetoothLE.Current.Adapter.ConnectToDeviceAsync(device, new ConnectParameters(true, true, ConnectionParameterSet.Balanced));
            var services = await device.GetServicesAsync();
            var service = await device.GetServiceAsync(Guid.Parse("12345678-1234-5678-1234-56789abcdef0"));
            var characteristic =
                await service.GetCharacteristicAsync(Guid.Parse("12345678-1234-5678-1234-56789abcdef1"));
            await characteristic.WriteAsync(
                Encoding.Default.GetBytes($"{Password};{CommandsPicker.SelectedItem};10;OUTPUT;1;"));
        }
        catch (Exception ex)
        {
            await Toast.Make(ex.Message).Show();
        }
    }

    private void Password_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Preferences.Set("Password", e.NewTextValue);
    }
>>>>>>> 65b15a8 (Rework client)
}