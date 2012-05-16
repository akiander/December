Version 50215.01
----------------

The providers contained in the accompanying project represent functionality from the ASP.NET 2.0 Beta 1
timeframe.  New features or functionality added post-Beta 1 have not been incorporated into the DecemberAccessProvider provider
source code in the accompanying project.  

The sample web.config file included with the project expects the assembly name to be "SampleAccessProviders.dll".
If you used the defaults when creating the assembly from the Starter Kit project, your assembly name will be
different.  Simply change the assembly reference in your web.config to use whatever assembly name is output
by your project.

Listed below are the major pieces of new functionality that are
not implemented and/or are stubbed out in the DecemberAccessProvider provider source code:

All providers
-------------
None of the providers support the "commandTimeout" attribute.  The providers issue OleDb commands using
the default timeout for OleDbCommand(s) which is 30 seconds.

The providers all carry out read and write operations against the DecemberAccessProvider database using the security 
credentials associated with the current request.  Unlike the built-in providers, the sample providers do
not suspend impersonation when client impersonation is in effect.  This means one of the following
identities requires Read/Write access to the App_Data directory:
     1.  The worker process identity if no impersonation is used.
     2.  The application impersonation identity if <identity impersonate="true" user="userid" password="pwd" /> is used.
     3.  Each client identity if <identity impersonate="true" /> is used.

Parameter validation and syntax checking of parameters is current as of ASP.NET 2.0 Beta 1.  As a result
the parameter validations used in Beta 2 and RTM providers will differ slightly from the validations
enforced by the DecemberAccessProvider providers.



Membership
----------
Password strength requirements are not enforced in the CreateUser and ChangePassword methods.  The settings are
read from configuration, but at are not used by the provider.

Account lockouts are not implemented in the provider.  The UnlockUser method has no effect, and the provider
does not count bad password or bad password answer attempts.

The DecemberAccessProvider provider does not support creating a new user with an explicit UserId (i.e. providerUserKey).

The DecemberAccessProvider provider does not support retrieving a user based on UserId (i.e. providerUserKey).


Role Manager
------------
No known limitations.


Profile
-------
Marking Profile properties with "serializeAs=binary" will not work in partial trust web applications.  Since 
the sample provider does not assert any serialization permission (it can't since the sample provider is not
inside of System.Web.dll), the demand for serialization permission will fail in High trust or lower.


Web Parts Personalization
-------------------------
No known limitations.



