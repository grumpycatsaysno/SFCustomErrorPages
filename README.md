# SFCustomErrorPages
Code for registering custom error pages in Sitefinity and custom section with user control to control the response status code for the 404 page.

### Requirements

* Sitefinity license
* .NET Framework 4
* Visual Studio 2012
* Microsoft SQL Server 2008R2 or later versions

### License information

This project has been released under the Apache License, version 2.0, the text of which is included in the repository.

### Installation instructions

* Clone the repository to your file system
* Open SitefintiyWebApp in Visual Studio
* Copy the files from the repository to the SitefinityWebApp and replace the web.config file
* Extend Properties folder and open AssemblyInfo.cs file
* Put the following line at the end of the file:

     [assembly: PreApplicationStartMethod(typeof(Installer), "PreApplicationStart")]
     
* Build the solution
* Restart Sitefinity application


### Additional resources:

For more detailed explanation on the code see:
[My personal blog - Sitefinity tips and tricks]()

