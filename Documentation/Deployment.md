# Deployment

## **Prerequisites**
- [Node.js](https://nodejs.org/en/download/)
    
    make sure to use LTS, and to download the 64 bit windows msi file
- [.NET Core version 3.0](https://dotnet.microsoft.com/download)
    
    make sure to download the SDK as it comes with a built in runtime, this makes it easier on you to install
    
 Once these are downloaded and installed you can head over to our source code reposity and grab our [first release](https://github.com/japperales/CS495-Capstone-Puma/releases)
 
 ## **Running our software**
 
 1. You will recieve a .zip archive that you need to extract, you will receive two folders.
 - PumaV1
 - SimV1
 
2. Both of these need to be run in order for the project to work
Open both folders, you will find windows application files named
 - CS495-Capstone-Puma
 - CheetahApiSimulator
 
3. if youre having trouble finding these files inside the mess of .dll files, organize the files within the folder by file type, this will bring the application to the top of the list. 

4. Upon Running these for the first time you may encounter the Windows 10 untrusted publisher screen, click on more info and run anyway to get around this

5. Once running properly you'll have a command prompt telling you which port the project is running on, select and copy the port like this 'https://localhost:5001' paste it into your browser and run, at this point the browser may warn you of a security risk, click on advanced, and go anyway.

## **Troubleshooting**
at this point the projects should be up and running. If they aren't due to an error, the most common error we have run into is 'dotnet dev-certs https' needs to be run on the project root

Example: if you were to be running our project from your desktop and needed to run 'dotnet dev-certs https' you would run this command in your cmd 'cd Desktop\V1.0\PumaV1' this would get you to the root of the puma project, you can then run 'dotnet dev-certs https' and youll be good to go. Make sure you do this to both projects though, both PumaV1 and SimV1. 
