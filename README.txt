***
README FOR ULTIMATE TECH APPLCATION

Developer: Alex Meyer
Last updated on: 6/20/2013
Contact email: alex.itguy@gmail.com

***

This application provides a simple way for end users to get information about their computer
as well as generate easy to read reports that can be emailed to an IT contact or someone
with more expertise. The information the app can generate is as follows:

Local Computer:
Computer Name
Current User
Domain
Ram Usage (with progress bar)
Cpu Usage (with progress bar)

Network:
Current Interface
Gateway IP
IP Address
MAC Address
Subnet Mask
Primary DNS IP
	Tasks that can be performed:
	-Network Test (ping internal NIC, DNS IP's, and www.google.com)
	-Get current ARP table (essentially runs arp -a and gives you results)
	-Reset current connection (runs ipconfig /release -> /flushdns -> /renew as well as stops are then
	starts network services)
	
Local Storage:
Drive Volume
Drive Format
Drive Label
Storage Space (Used/Total)
Percent of Ised Space
	Tasks that can be performed:
	-Start an SFC scan on OS drive
	-Schedule a check disk on the current selected drive from the drop down menu)
	
Software:
Current OS Version
All Programs List as well as version number

Hardware:
Lists devices found in Device Manager and lists their current status

Under File Menu:
Output to Text File -> Outputs a Log.txt file on the desktop of the current user with all information
	found in all of the tabs
Take a Screenshot -> Generates a screenshot of the current display and saves it as Screenshot.bmp to 
	the desktop
	
Any comments, questions, or suggestions can be emailed directly to me at alex.itguy@gmail.com
Thanks for using the application and I hope you enjoy!