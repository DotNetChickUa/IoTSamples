sudo /home/anastasia/.dotnet/dotnet HomeManagement.dll --urls http://+:80

sudo nano /lib/systemd/system/home-management.service

[Unit]
Description=Home Management
After=network.target

[Service]
Type=idle
WorkingDirectory=/home/anastasia/Projects/HomeManagement/
ExecStart=/home/anastasia/.dotnet/dotnet /home/anastasia/Projects/HomeManagement/HomeManagement.dll --urls http://+80   Restart=on-failure

[Install]
WantedBy=default.target






sudo systemctl daemon-reload
sudo systemctl enable home-management.service
sudo systemctl start home-management.service
sudo systemctl status home-management.service




ssh anastasia@raspberrypi-zero-2w.local
rm -r Projects/HomeManagement


scp -r "./" anastasia@raspberrypi-zero-2w.local:/home/anastasia/Projects/HomeManagement