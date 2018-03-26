namespace CarDealer.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Suppliers;
    using Services;
    using Services.Models.Suppliers;
    using System;

    public class SuppliersController : Controller
    {
        private const string SupplierView = "Filtered";

        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        [Log(OperationCode.Create)] // filter recording changes
        public IActionResult Create(SupplierBasicModel supplierModel)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierModel);
            }

            var existingSupplier = this.suppliers.ExistingName(supplierModel.Name);

            if (existingSupplier)
            {
                RedirectToAction(nameof(All));
            }

            this.suppliers.Create(
                supplierModel.Name,
                supplierModel.IsImporter);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var supplier = this.suppliers.ById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(new SupplierBasicModel
            {
                Id = supplier.Id,
                IsImporter = supplier.IsImporter,
                Name = supplier.Name
            });
        }

        [HttpPost]
        [Authorize]
        [Log(OperationCode.Edit)] // filter recording changes
        public IActionResult Edit(int id, SupplierBasicModel supplierModel)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierModel);
            }

            var existingSupplier = this.suppliers.Exists(id);
            var supplierUnique = this.suppliers.ExistingName(supplierModel.Name);

            if (!existingSupplier || supplierUnique)
            {
                return NotFound();
            }

            this.suppliers.Edit(
                id,
                supplierModel.Name,
                supplierModel.IsImporter);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id) => View(id);

        [Authorize]
        [Log(OperationCode.Delete)] // filter recording changes
        public IActionResult Destroy(int id)
        {
            this.suppliers.Delete(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
            => View(this.suppliers.AllBasic());

        public IActionResult Local()
            => View(SupplierView, this.GetSupplierModel(false));

        public IActionResult Importers()
            => View(SupplierView, this.GetSupplierModel(true));

        private FilteredSuppliersModel GetSupplierModel(bool isImporter)
        {
            var type = isImporter ? "Importer" : "Local";

            var filteredSuppliers = this.suppliers.Filtered(isImporter);

            return new FilteredSuppliersModel
            {
                Type = type,
                Suppliers = filteredSuppliers                
            };
        }
    }
}
