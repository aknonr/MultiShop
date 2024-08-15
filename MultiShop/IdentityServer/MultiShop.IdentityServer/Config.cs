// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
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
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermisson"}},
           new ApiResource("ResourceCargo"){Scopes={"CargoFullPermisson"}},
           new ApiResource("ResourceBasket"){Scopes={"BasketFullPermisson"}},

           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
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
             new ApiScope("OrderFullPermisson","Full authority for order operations"),

              //CargoFullPermisson Cargo işlmeleri için full yetki verdik 
             new ApiScope("CargoFullPermisson","Full authority for Cargo operations"),

             //BasketFullPermisson Sepet işlmeleri için full yetki verdik 
             new ApiScope("BasketFullPermisson","Full authority for Basket operations"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };




        public static IEnumerable<Client> Clients => new Client[]
        {
        
          //Visitor
          new Client
          {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
             AllowedScopes={"CatalogReadPermission","CatalogFullPermission"}

          },


          //Manager

          new Client
          {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", IdentityServerConstants.LocalApi.ScopeName,
              IdentityServerConstants.StandardScopes.Email,
              IdentityServerConstants.StandardScopes.OpenId,
              IdentityServerConstants.StandardScopes.Profile},





          },


          //Admin

          new Client
          { 
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson","CargoFullPermisson","BasketFullPermisson",
              IdentityServerConstants.LocalApi.ScopeName,
              IdentityServerConstants.StandardScopes.Email,
              IdentityServerConstants.StandardScopes.OpenId,
              IdentityServerConstants.StandardScopes.Profile},

              AccessTokenLifetime=600
          }


        };




    }
}