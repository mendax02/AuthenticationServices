﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId="userClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256()),
                    },
                    AllowedScopes ={"userAPI"}
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
          new ApiScope[]
          {
              new ApiScope("userAPI","User API")
          };
        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {

          };
        public static IEnumerable<IdentityResource> IdentityResource =>
          new IdentityResource[]
          {

          };
        public static List<TestUser>  TestUsers =>
          new List<TestUser>
          {

          };

    }
}
