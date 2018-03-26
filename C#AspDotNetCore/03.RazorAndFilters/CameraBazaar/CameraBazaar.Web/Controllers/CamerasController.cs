namespace CameraBazaar.Web.Controllers
{
    using Data.Models;
    using Infrastructure;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cameras;
    using Services;
    using System;
    using System.Linq;

    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService cameras;

        public CamerasController(ICameraService cameras, UserManager<User> userManager)
        {
            this.cameras = cameras;
            this.userManager = userManager;
        }

        [Authorize(Roles = GlobalConstants.AdminOrUser)]
        [Timer]
        public IActionResult Add() => this.View();

        [Authorize(Roles = GlobalConstants.AdminOrUser)]
        [HttpPost]
        public IActionResult Add(CameraFormViewModel cameraModel)
        {
            if (cameraModel.LightMeterings == null || !cameraModel.LightMeterings.Any())
            {
                ModelState.AddModelError(nameof(cameraModel.LightMeterings), "Please select at least one light metering.");
            }

            if (!ModelState.IsValid)
            {
                return this.ViewOrNotFound(cameraModel);
            }

            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User)
            );

            return RedirectToAction(nameof(All));
        }

        [Timer]
        public IActionResult All()
            => View(this.cameras.All());

        [Timer]
        public IActionResult Details(int id)
        {
            var isExisting = this.cameras.ExistingById(id);
            if (!isExisting)
            {
                throw new ApplicationException("Camera does not exist."); // to check wheter the logger is working with excep
            }

            return View(this.cameras.ById(id));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var existing = this.cameras.Existing(id, this.userManager.GetUserId(this.User));

            if (!existing)
            {
                return NotFound();
            }

            return View(id);
        }

        [Authorize]
        public IActionResult Destroy(int id)
        {
            this.cameras.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [Timer]
        public IActionResult Edit(int id)
        {
            var existingCamera = this.cameras.Existing(id, this.userManager.GetUserId(this.User));

            if (!existingCamera)
            {
                return NotFound();
            }

            var camera = this.cameras.ById(id);
            var currentUser = this.userManager.GetUserName(this.User);

            if (camera == null || camera.Username != currentUser)
            {
                return NotFound(); // or redirect to some page with TempData error message
            }

            return View(new CameraFormViewModel
            {
                Make = camera.Make,
                Model = camera.Model,
                Price = camera.Price,
                Quantity = camera.Quantity,
                MinShutterSpeed = camera.MinShutterSpeed,
                MaxShutterSpeed = camera.MaxShutterSpeed,
                MinISO = camera.MinISO,
                MaxISO = camera.MaxISO,
                IsFullFrame = camera.IsFullFrame,
                VideoResolution = camera.VideoResolution,
                Description = camera.Description,
                ImageUrl = camera.ImageUrl,
                // LightMeterings cannot be resolved cuz of the foreach in the view form - it takes always all of the values
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CameraFormViewModel cameraModel)
        {
            var existingCamera = this.cameras.Existing(id, this.userManager.GetUserId(this.User));

            if (!existingCamera)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.ViewOrNotFound(cameraModel);
            }

            this.cameras.Edit(
                id,
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageUrl);

            return RedirectToAction(nameof(Details), routeValues: new { id = id });
        }
    }
}
