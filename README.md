Freighter
================

[Development Process](/DevProcess.md) 



## How to Set Up the Local Dev Environment
To get started, install all the required software first and then follow the instructions to set up each software step-by-step. If you have any problems during the set up, refer to the [Common Set Up Problems & Solutions](####Common) section towards the end of the document.

####Required Software
* [Git Client](https://git-scm.com/downloads)
* [Node.js](http://nodejs.org/)
* Visual Studio 2013
* [IIS Manager](https://www.microsoft.com/en-us/download/details.aspx?id=2299)
* [RoboMongo](http://robomongo.org/)

####Cloning the Freighter Repository

1. Open **Git Bash** or preferred git utility.
2. Clone the Freighter repo from GitHub in your local machine.
	`git clone https://github.com/FrontlineTechnologies/Freighter.git`


####How to Set Up Node.js

1. Open **Node.js Command Prompt**.
2. Navigate inside the **app** folder (i.e. `cd C:\Users\fwhatley\Desktop\Freighter\Freighter.App\app`)
3. Run the commands below in order. 
	* `npm install -g grunt-cli`
	* `npm install` which will bring in all the dependencies 
	* `grunt dev` which will
		* process **.styl** files down to the site.css file required to run the site 
        * watch your files and provide livereload
		* run unit tests with karma
		* kick off a local web server [http://localhost:3000](http://localhost:3000)

####How to Set Up Visual Studio 2013

Opening the Freighter project

1. Open Visual Studio 2013.
2. Open the Freighter project located inside **Freighter** folder by going to menu **FILE > Open > Project/Solution** and selecting **Freighter.sln**.

Setting Up the Web API Project Properties

1. Once the solution is opened to set up the Web API project, select the **Freighter.API** project in the Solution Explorer section.
3.  Right click on the project and select properties.
4. In the properties window, select the **Web** tab and select 
	* Start Action: "Don't open a page. Wait for request from an external application."
	* Servers: Local IIS
	* Once the two options are selected, click "Create Virtual Directory".
5. Hit **Ctrl + S** to save all the changes and **Ctrl + F4** to close the properties window.

Setting Up the Solution Properties

1. In the Solution Explorer section, right click on the solution and choose properties.
2. In the properties window on the left panel, go to **Common Properties > Startup Project**.
3. On the right panel, choose "Single startup project" and select "Freighter.Api" and click **OK** to close the window.


####How to Set Up IIS
Setting Up Freighter.Api

1. Open IIS 7 Manager.
2. [Enable the Application Pool to run 32-bit applications](https://help.webcontrolcenter.com/kb/a1114/how-to-enable-32-bit-application-pool-iis-7-dedicatedvps.aspx)  so the site can work properly because the FTP third party DLL is 32-bit.
3. [Enable Anonymous Authentication](http://www.iis.net/configreference/system.webserver/security/authentication/anonymousauthentication) (for OPTIONS API request, authorization for OPTIONS is set in web.config).
4. Enable Windows Authentication.
5. (Optional) If working with functionality that needs to reach out to the Aesop DB, you will need to get the credentials for the corp\svc_st_dev_web service account so the application has the correct permissions to access the appropriate DB.
	* You will need to go into the IIS site to determine which Application Pool you're running as (under Advanced Settings of the site).
	* Once you have the Application Pool name, go into Application Pools and select the one you are running as.
	* Click advanced settings -> Identity option -> Custom Account and use the corp\svc_st_dev_web account credentials.
	* In production, this will get configured with the proper account on the IIS server this project is running on.
	
Setting Up Freighter.App

1. Enable Anonymous Authentication because the first call this app makes is to get the current user information from the API which requires authentication. We do this so that the user doesn't have to authenticate twice.

####Required third party DLL registration 
Note: This is a pre-build step. This part might not be necessary

* The FTP DLL (SFTPCOMInterface.dll) must be registered on every machine this app runs on
	* The Octopus Deploy step handles this when deploying. 
	* It needs to be done locally, even if you don't want to use the FTP functionality.   
	* http://help.globalscape.com/help/gs_com_api/com_remotely_administering_eft_server_using_the_com_api.htm#register

#### Testing FTP functionality
* To test FTP in a local env, download and install EFT Enterprise Edition without SQL Server from http://www.globalscape.com/support/eft.aspx

#### Common Set Up Problems & Solutions
* [How to enable  IIS Management Console in Windows 7](http://forums.asp.net/t/1704482.aspx?INSTALLING+IIS+MANAGEMENT+CONSOLE)
* [How to fix: Handler “PageHandlerFactory-Integrated” has a bad module “ManagedPipelineHandler” in its module list](http://stackoverflow.com/questions/6846544/how-to-fix-handler-pagehandlerfactory-integrated-has-a-bad-module-managedpip)
* [ASP.NET IIS 7.5 HTTP 500.21 error](http://stackoverflow.com/questions/22952115/asp-net-iis-7-5-http-500-21-error)
* [IIS - this configuration section cannot be used at this path (configuration locking?)](http://stackoverflow.com/questions/9794985/iis-this-configuration-section-cannot-be-used-at-this-path-configuration-lock)
* [How can I enable assembly binding logging](http://stackoverflow.com/questions/17681432/how-can-i-enable-assembly-binding-logging)
* [In IIS, why doesn't Window Authentication show up as one of the options for my web application?](http://stackoverflow.com/questions/8067448/in-iis-why-doesnt-window-authentication-show-up-as-one-of-the-options-for-my-w)


## Supporting documentation
####Rally C# DLL
* Code (https://github.com/RallyTools/RallyRestToolkitFor.NET)
* Wiki (https://github.com/RallyTools/RallyRestToolkitFor.NET/wiki/User-Guide)
