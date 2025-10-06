sudo /home/anastasia/.dotnet/dotnet IpCameraWeb.dll --urls http://+:80

sudo nano /lib/systemd/system/ipcamera.service

[Unit]
Description=IpCameraWeb
After=network.target

[Service]
Type=idle
WorkingDirectory=/home/anastasia/Projects/IpCamera/
ExecStart=/home/anastasia/.dotnet/dotnet /home/anastasia/Projects/IpCamera/IpCameraWeb.dll --urls http://+80
Restart=on-failure

[Install]
WantedBy=default.target