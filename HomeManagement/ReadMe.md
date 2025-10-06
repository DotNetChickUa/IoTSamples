<<<<<<< HEAD
sudo /home/anastasia/.dotnet/dotnet HomeManagement.dll --urls http://+:80
=======
sudo /home/anastasia/.dotnet/dotnet HomeManagement.dll --urls http://+:80
>>>>>>> be8e5f2 (Home Management)

sudo nano /lib/systemd/system/home-management.service

[Unit]
Description=Home Management
After=network.target

[Service]
Type=idle
<<<<<<< HEAD
WorkingDirectory=/home/anastasia/Projects/HomeManagement/
ExecStart=/home/anastasia/.dotnet/dotnet /home/anastasia/Projects/HomeManagement/HomeManagement.dll --urls http://+80   Restart=on-failure
=======
WorkingDirectory=/home/anastasia/Projects/HomeManagement/
ExecStart=/home/anastasia/.dotnet/dotnet /home/anastasia/Projects/HomeManagement/HomeManagement.dll --urls http://+80   Restart=on-failure
>>>>>>> be8e5f2 (Home Management)

[Install]
WantedBy=default.target






sudo systemctl daemon-reload
sudo systemctl enable home-management.service
sudo systemctl start home-management.service
sudo systemctl status home-management.service
<<<<<<< HEAD




ssh anastasia@raspberrypi-zero-2w.local
rm -r Projects/HomeManagement


scp -r "./" anastasia@raspberrypi-zero-2w.local:/home/anastasia/Projects/HomeManagement
=======
>>>>>>> be8e5f2 (Home Management)
