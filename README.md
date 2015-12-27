PREDATOR
================

## How to Set Up the Local Dev Environment
To get started, install all the required software first and then follow the instructions to set up each software step-by-step. If you have any problems during the set up, refer to the [Common Set Up Problems & Solutions](####Common) section towards the end of the document.

####Required Software
* [Git Client](https://git-scm.com/downloads)
* [Node.js](http://nodejs.org/)
* Visual Studio 2013
* [IIS Manager](https://www.microsoft.com/en-us/download/details.aspx?id=2299)

####Cloning the Predator Repository

1. Open **Git Bash** or preferred git utility.
2. Right-click your Desktop, and select Git Bash Here. This will open the Git command prompt from your Desktop's directory.
3. Clone the Predator repo from GitHub in your local machine.
	`git clone https://github.com/rwhat357/Predator.git`
4. Enter in your Git-hub use name and password.


####How to Set Up Node.js *****these instructions need to be checkededited

1. Open **Node.js Command Prompt**.
2. Navigate inside the **app** folder (i.e. `cd C:\Users\fwhatley\Desktop\Predator\Predator.App\app`)
3. Run the commands below in order. 
	* `npm install -g grunt-cli`
	* `npm install` which will bring in all the dependencies 
	* `grunt dev` which will
		* process **.styl** files down to the site.css file required to run the site 
        * watch your files and provide livereload
		* kick off a local web server [http://localhost:3000](http://localhost:3000)

####How to Set Up Visual Studio 2013

Opening the Predator project

1. Open Visual Studio 2013.
2. Open the Predator project located inside **Predator** folder by going to menu **FILE > Open > Project/Solution** and selecting **Predator.sln**.

Setting Up the Web API Project Properties

1. Once the solution is opened to set up the Web API project, select the **Predator.Api** project in the Solution Explorer section.
3.  Right click on the project and select properties.
4. In the properties window, select the **Web** tab and select 
	* Start Action: "Don't open a page. Wait for request from an external application."
	* Servers: Local IIS
	* Once the two options are selected, click "Create Virtual Directory".
5. Hit **Ctrl + S** to save all the changes and **Ctrl + F4** to close the properties window.

Setting Up the Solution Properties

1. In the Solution Explorer section, right click on the solution and choose properties.
2. In the properties window on the left panel, go to **Common Properties > Startup Project**.
3. On the right panel, choose "Single startup project" and select "Predator.Api" and click **OK** to close the window.

Testing Predator.Api with Swagger

Navigate to this address to open swagger to test the endpoints.
http://localhost/Predator.Api/swagger

####How to Set Up IIS
Setting Up Predator.Api

1. Open IIS 7 Manager.
2. [Enable Anonymous Authentication](http://www.iis.net/configreference/system.webserver/security/authentication/anonymousauthentication) (for OPTIONS API request, authorization for OPTIONS is set in web.config).
3. Enable Windows Authentication.
	
Setting Up Predator.App

1. Enable Anonymous Authentication because the first call this app makes is to get the current user information from the API which requires authentication. We do this so that the user doesn't have to authenticate twice.

#### Common Set Up Problems & Solutions
* [How to enable  IIS Management Console in Windows 7](http://forums.asp.net/t/1704482.aspx?INSTALLING+IIS+MANAGEMENT+CONSOLE)
* [How to fix: Handler “PageHandlerFactory-Integrated” has a bad module “ManagedPipelineHandler” in its module list](http://stackoverflow.com/questions/6846544/how-to-fix-handler-pagehandlerfactory-integrated-has-a-bad-module-managedpip)
* [ASP.NET IIS 7.5 HTTP 500.21 error](http://stackoverflow.com/questions/22952115/asp-net-iis-7-5-http-500-21-error)
* [IIS - this configuration section cannot be used at this path (configuration locking?)](http://stackoverflow.com/questions/9794985/iis-this-configuration-section-cannot-be-used-at-this-path-configuration-lock)
* [How can I enable assembly binding logging](http://stackoverflow.com/questions/17681432/how-can-i-enable-assembly-binding-logging)
* [In IIS, why doesn't Window Authentication show up as one of the options for my web application?](http://stackoverflow.com/questions/8067448/in-iis-why-doesnt-window-authentication-show-up-as-one-of-the-options-for-my-w)

## How to Deploy the App

### Requirements
* IIS Server
* Microsoft .NET 4.5 Framework

### Deploy the front-end
1. Open a terminal and navigate to **Predator.App** folder. 
2. Run `grunt prod` which will run tasks to optimize and minify the front-end. The server ready files will be placed under the folder **dist**.
3. Use an FTP or SSH client to upload the contents of **dist** to the server.

### Deploy the back-end
1. Navigate to **Predator.Api** folder.
1. Open and FTP or SSH client and upload the contents **Predator.Api** to the server.

## How to Tag a Build

1. Merge all branches to `master`.
3. After the merge is complete, tag and push `master`.
	* `git tag PD4` *(change **PD4** to your release version)*
	* `git push origin master --tag`
