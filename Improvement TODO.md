
- Let's wrap the existing code in an azure function. 

- The function is triggered by the change in blob storage. (When new xl files are added by a publisher). 

- Azure blob storage has SFTP support. So, published uploads via SFTP. and triggers the function call. 

- Finally, azure function updates the on-premise / cloud database (Meadify system) based on the existing business logic. 

  

Gains: 

  

Cron job not required. The trigger is built in with the Azure function. Just need to configure it. 

You have moved to the cloud and your files and application doesn't have to be on the same server. 

Improved deployment routine, no manual copy of the binaries.   

Publisher agnostic of the change (except for the new SFTP connection configuration). 

Less pain with Functions-as-a-Service (FaaS), no need to maintain infrastructure  

  

Code refactoring: 
  

- Required for cloud migration  
  

* Move the hard coded file paths (in PrenaxImporter) to a configuration file. app config or something similar which can be deployed separately to different env using pipeline. This way yo u can have separate files for test/uat and production. No need to change source code. 

Instead of a config file one also has a configuration database and build a service to perform CURD on the db. but only for this application it is probably a over kill. 

* Couldn't find how you are getting the db connection string but let’s also move it to a configuration fil for the same purpose as mentioned above. 

* Only in this exercise the application is logging on the console but in real life it should create/write a log file for this application on a location (some container in the azure blob storage) that should be configured on the config file. 


- For better readability

* I would also like to use interpolated strings all way trouhgt the system. 

* Better/Readable veriable names. 

* Some of the helper classes are not being used. 
- FtpHelper: I assume this application was previously also copying the files from FTP to local disk. However, the arguments (_strRemoteHost, _strRemoteUser, _strRemotePassword) of the FtpHelper constructor should also be retrieved form config file/db.  
- CacheManager: Anyway, the timeout (60000) shouldn't be hardcoded.

* Unused code shouldbe removed.
- The BaseImporter class is not being used at the moment. Is it an old class? The BaseMultiPorter sems like an updated version of that.
if it it not used may be it should be removed? OR is it so that some future publisher implementation (similar to PrenuxImported ) you may use the BaseImported instead?

* Remove unused comments. like //TEST section


- May be in future improve
  
* The stored procedure names can be put as constantstring in a separate file for better readability. 
  
* Entity framework can be used instead as well.

*



  

  

further question: 

* Why is the data being updated on an xl? can this change in future? is it a requirement from the publisher or is it us who decided how the data should be provided to us? 

* If the requirement changes you need to update the db schema + xl data structure 

* Alternatively we can build a webpage (publisher.tidningskungen.se ?) that all the publisher access and fill in the data and the updates happens directely to db. 