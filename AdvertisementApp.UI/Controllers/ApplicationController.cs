﻿using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> List()
        {
            var response = await _advertisementService.GetAllAsync();
            return this.ResponseView(response);
        }
        public IActionResult Create()
        {
            return View(new AdvertisementCreateDtos());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDtos dto)
        {
            var response = await _advertisementService.CreateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
        public async Task<IActionResult> Update(int id) 
        {
            var response = await _advertisementService.GetByIdAsync<AdvertisementUpdateDtos>(id);
            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDtos dto)
        {
            var response = await _advertisementService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisementService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }
    }
}
