![image](https://github.com/caleb1000/CShark/assets/30327564/13eace11-62ec-4655-ac38-128508d8def1)
# C# Shark: A Raw-Socket Based Network Sniffer
## This is a work-in-progress!
## Summary:
### C# Shark is a raw-socket based network sniffer. The code is written in C# and uses WinForms for the GUI. This project was inspired by WireShark, hence the name C#Shark.

## Youtube Video:
[![Watch the video](https://user-images.githubusercontent.com/30327564/250964540-8ad97196-24e2-4404-bb42-28e8b3f8ffbe.png)](https://youtu.be/K4bObd_8Qvc)

## TO:DO
* Recognize more protocols
* Add more filter options
* Allow post-run filtering of packets (currently only supports filtering active run)
* Optimize code (currently if too many packets come in user input is sluggish/non-responsive)
* Clean up code
* Save traffic in PCAP format
* Support packet injection (will need to use 3rd party lib as raw sockets cannot send tcp packets on windows)
* Add network statistics monitoring

  

