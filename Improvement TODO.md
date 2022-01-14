

Having the FTP folder (bulk data..?) on the same disk where you host your application is probably not the best security / performence measure. You probably want to use a cheaper alternative for file server. A dedicated file server ? azure blob storage?


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

1. Move the hard coded file paths (in PrenaxImporter) to a configuration file. app config or something similar which can be deployed seperately to different env using pipeline. This way yo ucna have serperate files for test/uat and production. No need to change source code.
 Instead of a config file one also have a configuration database and build a service to perform CURD on the db. but only for this application its probably is a over kill.

2. Couldn't find how you are getting the db connection string but lets aslo move it to a configuration file for the same purpose as mentioned above.


- Good to have
3. The stored procedure names can be put as constant string in a seperate file for better readability.
4. Entity framework can be used instead as well .

5. Some of the helper classes are not being used. I assume this application was previously aslo copying the files from FTP to local disk. However the arguments (_strRemoteHost, _strRemoteUser, _strRemotePassword) of the FtpHelper constructor should also be retrieved form config file/db. 

