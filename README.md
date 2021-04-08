# AuthenticationServices

Contains Examples for different authentication methods.
1) IdentityServer4 Authentication
2) JWT Authentication Token


Process to Run **IdentityServer4 Authentication**:
1) Select Mutliple project at startup: (IdentityServer, Users.WebApi)
2) When application is UP and running then open POSTMAN
3) Make POST request: https://localhost:5005/connect/token
4) Copy the Token
5) Go to the Users.API swagger page. Click on the Authorize button at the Top Right corner.
6) Paste the copied TOKEN
7) Now, try the GET https://localhost:5001/api/Users. Your should be able to see the data

Process to Run **JWT Authentication Token**
1) Make POST request to  "https://localhost:5001/token"
2) Add username and password (eg: Siddharth, password123)
3) A token will be generated
4) Copy the token and click on the Authorize buttin at the right corner
5) Paste the copied Token and save the value
6) Now, Make a GET request to "https://localhost:5001/api/Users" 
7) User should be able to fetch the result from the endpoint
8) If token is not passed then service should return 401 response code
https://documenter.getpostman.com/view/7377221/TzCTa5SQ
