## How to install Windows-Service

### 1) File-Deployment
Unless anyone takes the time to modify the build and deployment jobs the deployment of the Windows-Service has to be done manually. 

***NOTE***: In order to do that, remember to build your local solution using the "**Release**" setting.

After successful build you just need to get all the files from the bin/release directory of the project **IG.Win.Service**. It will contain every file we need to run the service on any VM given the machines are configured correctly. So a good thing to do would be to just compress the whole release folder into a zip-file to facility transport to the virtual machines.

### 2) Uninstall
***NOTE***: Since Windows-Services might actually need the .exe file of the installed version to be uninstalled, ***ALWAYS*** uninstall a running service first. To do that just use the powershell script that is included in the release directory of your build. The script '**UninstallService.ps1**' will stop the service and then remove it from the windows service environment.

### 3) Copy the zip
My suggestion would be to create a new *working directory* within **c:\apps\\** of the virtual machines. Maybe call it **c:\apps\trayport-service**. 

***NOTE***: DON'T use the temporary storage drive D on the azure VMs. 

***NOTE***: If you use the same directory for every single deployment, you should always **UNINSTALL** the service first (see 2)) before you copy the new files into the directory. Now just decompress the contents of your zip file into your *working directory* as base of operations.

***NOTE***: SOMETIMES it might happen that, after Uninstalling the service and trying to reinstall the updated service, you will get an error message that "The specified service has been marked for deletion". In that case, before you can reinstall the service, you probably only have to close all management windows (*.msc-Tools or MMC) because they might have a lock on the Win32_Service - class object. If closing them does not help, a reboot will (worst case).

### 4) Install the Service
To install the service you only need to run the powershell script '**InstallService.ps1**' with your elevated user (i. e. your user needs administrative access to install a windows service). After registering your service exe with the windows service environment, the powershell script will automagically start the service... given all requirements are properly met.

***NOTE***: After installation, the service will start up... that process might take some time, it will have to connect to the databases, connect to the Trayport GlobalVision Server and initialize and run a WebApi. So before Windows is considering the service up and running, you may have to wait a couple seconds. In my VM (8cores 28GB ram) it takes ~35 seconds.


## Check if the Service is up and running
a) First you can have a look into the event viewer, under "Applications and Service Logs" you will find a new entry "IG.Win.Service" which will contain the regular logging events of the service. Any red exclamation marks? => something might be wrong.
b) run the user interface. In order to make it as comfortable as you are used to, the service hosts its own Swagger-UI allowing you to talk to the service. 

The point of entry is by default: **http://localhost:5000/swagger/ui/index#/**


c) and yes. the file-log under c:\logs\IG.Win.Service.log is still maintained.

## Requirements
Please ensure the implementation/installation of all pre-requirements below. Failing to do so, will probably leave you frustrated and stuck in developers hell. That actually is one of the few places most developers try to avoid to get into. But these days it is not so uncommon anymore that doing the OPS part of a devops specialist is required of any developer. So please bear with me a couple more minutes setting up these pre-reqs to earn a quick exit.

### a) Certificates
I have been so kind as to enhance the certificate provider (found in Eon.SharedComponents.dll) to - as a fallback solution - also look into the certificate-store cert:\localmachine\my and thereby allow it to find certificates that are installed in your computers store instead of your users store. That will allow you to enable everyone using a single computer to access or run the EAI locally without having to install the certificates for each user.

To run the Windows-Service you will need to install the CredentialCrypt certificates (i'd suggest to install both, then you can switch your local ConnectionStrings.config to any environment and it will just work) as well as the general certificates for each environment. With these 6 certificates in place you will be able to run the Windows-Service locally or on a VM of your choice.

### b) Service-User
That one is actually not anymore necessary. Due to the change that certificates can be stored in the computers certificate store, the need of a service user is not anymore present. The service will be installed and run under the local system account.

### c) Windows 10 SDK
I can not tell you why... but at my initial attempts to install the service and then run the service, the start-attempt always broke up stating that the activation context failed due to a missing signtool.exe.Manifest. I have actually no clue what that would trouble our usual windows computer, but after quite some googling I came to the conclusion that the Windows 10 SDK has to be installed on the computer running the Windows-Service. It seems, that at Service-Start Windows tries to "sign" our unregistered com-component to allow it to run. To do that it will need the Windows 10 SDKs signtools. I have not tried to figure out which one actually is required. As the VM is nearly empty, I just decided to install the WHOLE Windows 10 SDK Kit... the will be about 700MB of uncompressed data... but, one restart later your machine can run the GlobalVision-API com-component.

***NOTE***: But, after installing the Windows Service to VMs, it seems they - beeing Windows Server 2012 - have no trouble with this signing stuff and are able to run the service without installing the Windows 10 SDK Kit.

### d) Configuration
 - Database: Since I have not had the time to create automatic setup/deployment, **you** will **have to configure the app.config-file** of the service **yourself**. It should be as easy as selecting the correct line in the "ConnectionStrings.config" file in accordance to your environment.
 - Service WebAPI Port: using the App-Setting "**IG.Win.Service.ServicePort**" you can configure the port used for the Swagger-UI. Choose any unused value > 1024.

