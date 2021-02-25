# Demo-LogAPI

**Project** - .Net Core 3.1 Web Api

The API is protected by an API key based Authentication.

So, if request to GET messages (http://localhost:56897/Messages) are sent without the API Key, you should see an error
{"Status":401,"Detail":"You are not authorized to access this resource."}

The API key need to be passed in **header** of each request,
* Key name : X-Api-Key
* Key value : key3e5847c8449a5ac5cd72b7ad8c0a3

**Sample GET Messages request.**
![GetMessage](/Documentation/GetMessagesScreenshot.png)

**Sample POST Message request with response.**

![PostMessage](/Documentation/PostMessageScreenshot.png)


