﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    //bu attribute altında kalan yerler başka metotlar ve sınıflar vs .Mutlaka Identityserver acces token sahip olmak zorunda . 
    [Authorize(LocalApi.PolicyName)]

    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]

        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            // Kullanıcı kaydı işlemini gerçekleştirmek için yazılmıştır . 

            //ApplicationUser adından bir nesne oluşturuyoruz. ve gelen dto bu nesneyi alır ve atamasını asağıda yapılmıştır.
            //Dikkat !! Postman üzerinden veri girişi yapılmıştır ve db bear üzerinden kontrol edilmiştir.
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };

            var result=await _userManager.CreateAsync(values, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                return Ok("Bir hata oluştu tekrar deneyiniz");
            }
            
        }
    }
}
