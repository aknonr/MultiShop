// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{

    //Yetki verdiğimiz classlar 
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            // Api resource tek tek isimlendirme yapıyoruz. 
            //ResourceCatalog isimine sahip olan kullanıcı (CatalogFullPermission) yetkisine sahip olacak.
            new ApiResource("ResourcecCatalog"){ Scopes={"CatalogFullPermission","CatalogReadPermission"} },

            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },

            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"} },

        };


        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            //Herkese açık olan Id'ye erişim sağlayacak
           new IdentityResources.OpenId(),

           //herkese açık olan Email erişim sağlacak
           new IdentityResources.Email(),

           //Herkese açık olan Profile erişim sağlayacak
           new IdentityResources.Profile(),
        };


        //Bir Kullanıcın sahip olduğu ilgili yetki de yapacaklarını belirledik

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            //CatalogFullPermission yetkisine sahip olan kişi Katalog işlemleri için tam yetki verdik . Bunu da ingilizce olarak yazdık .
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),

            //Full okuma işlemi veridm bu yetkiye sahip olan kişiye 
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),

            //DiscountFullPermission discount işlemleri için full yetki verdik . 
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),

            //OrderFullPermission order işlmeleri için full yetki verdik . 
            new ApiScope("OrderFullPermission","Full authority for order operations"),

        };




        public static IEnumerable<Client> Clients => new Client[]
        {
        
          //Visitor
          new Client
          {
              ClientId="MultiShopVisitorId",
              ClientName="Multi Shop Visitor User",
              AllowedGrantTypes= GrantTypes.ClientCredentials,
              ClientSecrets={new Secret("multishopsecret".Sha256()) },
              AllowedScopes={ "CatalogReadPermission" }

          },


          //Manager

          new Client
          {
              ClientId="MultiShopManagerId",
              ClientName="Multi Shop Manager User",
              AllowedGrantTypes= GrantTypes.ClientCredentials,
              ClientSecrets= {new Secret ("multishopsecret".Sha256()) },
              AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
          },


          //Admin

          new Client
          {
              ClientId="MultiShopAdminId",
              ClientName="Multi Shop Admin User", 
              AllowedGrantTypes=GrantTypes.ClientCredentials,
              ClientSecrets={new Secret("multishopsecret".Sha256()) },
              AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
              IdentityServerConstants.LocalApi.ScopeName,
              IdentityServerConstants.StandardScopes.Email,
              IdentityServerConstants.StandardScopes.OpenId,
              IdentityServerConstants.StandardScopes.Profile,
              },

              AccessTokenLifetime=600
          },


        };



     
    }
}