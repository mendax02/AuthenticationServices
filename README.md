# AuthenticationServices

Contains Examples for different authentication methods.
1) IdentityServer4 Authentication

Process to Run:
1) Select Mutliple project at startup: (IdentityServer, Users.WebApi)
2) When application is UP and running then open POSTMAN
3) Make POST request: https://localhost:5005/connect/token
4) Copy the Token
5) Go to the Users.API swagger page. Click on the Authorize button at the Top Right corner.
6) Paste the copied TOKEN
7) Now, try the GET https://localhost:5001/api/Users. Your should be able to see the data
