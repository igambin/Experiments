Experiments
===========

This Visual Studio solution is my place to store experimental code. I create this code mainly when I am curious to try and play with some ideas. 

Whereas some of this solutions content may be proof of concept implementations, other parts may not be state of the art or even finished.

#### WinFormsToolbox
A starter app to start WinForms applications that implement a certain iInterface using MEF

##### - Mp3RegexEditor
Simple tool to facilitate mass-edit-actions to mp3 tags within a directory using regular expressions. This tool might be handy to unitise the album or disc information of mp3 files.

##### - FileRenamer
Simple tool to facilitate mass-renaming of files within a selected directory. Filter and rename files based on Regex search/replace patterns

#### Mp3RegexEditor
Standalone Wrapper to start the Mp3RegexEditor directly
 
#### SelfmadeIoC
A little project where I played around with creating my own IoC-Container. It is just an example implementation and for educational purposes. I suggest you do not use it in production. There are many better IoC-Containers out there and freely available too. (Ninject, Unity, Castle Windsor, Autofac, StructureMap, et. al. ... just to name a few)


#### EFDecoupled
Its a project where I am playing around with Entity Framework, the Repository and the Unit of Work patterns... while just for fun trying to keep all of it decoupled using my SelfmadeIoC Container.


#### Toolbox
A collection of mostly reusable projects to handle logging (log4net), provide extensions or caching functionality

##### - IG.Caching
An interface and an implementation to facilitate the (a)synchronous use the C# MemoryCache functionality

##### - IG.CommonLogging
A small wrapper to offer an extended logging-interface using log4net, providing more possibilities to log messages and offering the use of the SerializingLogItem class to allow objects to be logged to a blobstorage. Additionally a self-written MailNotificationAppender is included

##### - IG.Extensions 
A collection of useful extensions to strings, dateTimes, Exceptions, ByteArrays and more

##### - IG.SettingsReaders
A small example how to organize settings and how to read them from DB or .config-file app settings

##### - IG.XmlAssistant 
Tiny generic helpers to transform an object to xml and back using XmlSerialization

##### - IG.Validations
Experimental approach to model-/property-Validation

##### - IG.ResourceAssistant
Small helper to read data from embedded resources

##### - IG.Repository
Small examplary implementation of a generic repository

#### XperimentsTest
Collection of tests for some of this experimental codes implementations as well as a small showcase for some testing experiments, e. g. using DataSources as test input, using shims and fakes