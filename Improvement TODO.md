
- Lets wrape the existing code in an azure function.
- The fucntion is triggered by the change in blob storage. (when new xl files are added by a publisher).
- Azure blob storage has SFTP support. So, published uploads via SFTP. and triggers the function call.
- Finally, azure function updates the on-premmise / cloud database (Meadify system) based on the existing business logic.

Gains:

Cron job not required. The triger is built in with the Azure function. Just need to configure it.

You have moved to the cloud and your files and applocation doesn't have to be on the same server.

Improved deployment routine, no manual copy of the binaries.

Publisher agnostic of the change (except for the new SFTP connection configuration).

Less pain with Functions-as-a-Service (FaaS), no need to mantain infrustructure 



Code refactoring:

- Required for migration 

*. Move the hard coded file paths (in PrenaxImporter) to a configuration file. app config or something similar which can be deployed seperately to different env using pipeline. This way yo ucna have serperate files for test/uat and production. No need to change source code.
 Instead of a config file one also have a configuration database and build a service to perform CURD on the db. but only for this application its probably is a over kill.

*. Couldn't find how you are getting the db connection string but lets aslo move it to a configuration fil for the same purpose as mentioned above.

*. Only in this exercise the application is logging on the cosole but in real life it should create/write a log file for this application on a location (some container in the azure blob storage) that is configured on the config file.

- May be in future

*. The stored procedure names can be put as constant string in a seperate file for better readability.

*. Entity framework can be used instead as well .

*. Some of the helper classes are not being used. I assume this application was previously aslo copying the files from FTP to local disk. However the arguments (_strRemoteHost, _strRemoteUser, _strRemotePassword) of the FtpHelper constructor should also be retrieved form config file/db. 


further question:
* Why is the data being updated on an xl? can this change in future? is it a requirement from the publisher or is it us who decided how the data should be provided to us?
* If the requirement changes you need to update the db schema + xl data structure
* Alternatively we can build an webpage (publisher.tidningskungen.se ?) that all the publisher access and fill in the data and the updates happens directely to db.