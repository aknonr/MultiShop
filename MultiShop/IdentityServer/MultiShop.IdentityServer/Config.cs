// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            // Api resource tek tek isimlendirme yapıyoruz. 
            //ResourceCatalog isimine sahip olan kullanıcı (CatalogFullPermission) yetkisine sahip olacak.
            new ApiResource("ResourcecCatalog"){ Scopes={"CatalogFullPermission","CatalogReadPermission"} }

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



        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            //CatalogFullPermission yetkisine sahip olan kişi Katalog işlemleri için tam yetki verdik . Bunu da ingilizce olarak yazdık .
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),

            //Full okuma işlemi veridm bu yetkiye sahip olan kişiye 
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations")

        };



     
    }
}