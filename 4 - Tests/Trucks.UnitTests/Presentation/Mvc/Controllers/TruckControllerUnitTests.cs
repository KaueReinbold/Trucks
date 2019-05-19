using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Trucks.Application.AutoMapper;
using Trucks.Application.Services;
using Trucks.Application.ViewModels;
using Trucks.Mvc.Controllers;
using Trucks.UnitTests.FakeObjects.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trucks.Application.ViewModels.Enumerables;
using System;
using System.Linq;
using Trucks.Domain.Contracts.UnitOfWork;

namespace Trucks.UnitTests.Presentation.Mvc.Controllers
{
    [TestClass]
    public class TruckControllerUnitTests
    {

        #region snippet_Variables

        private Mock<TruckService> TruckService { get; set; }
        private Mock<ILogger<TrucksController>> Logger { get; set; }
        private IUnitOfWork FakeUnitOfWork { get; set; }
        private Mapper Mapper;
        private TrucksController Controller { get; set; }

        #endregion

        #region snippet_Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            FakeUnitOfWork = new FakeUnitOfWork();

            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MappingProfile())));

            Logger = new Mock<ILogger<TrucksController>>();

            TruckService = new Mock<TruckService>(FakeUnitOfWork, Mapper);

            Controller = new TrucksController(Logger.Object, TruckService.Object);
        }

        #endregion

        #region snippet_Index_ShouldGetList

        [DataTestMethod]
        [DynamicData(nameof(DataToGetAll), DynamicDataSourceType.Property)]
        public void Index_ShouldGetList(int count)
        {
            // Act
            var result = Controller.Index() as ViewResult;

            var model = (List<TruckViewModel>)result.Model;

            // Assert
            Assert.AreEqual(count, model?.Count, "It should return a list");
        }

        #endregion

        #region snippet_Details_ShouldGetItem

        [DataTestMethod]
        [DynamicData(nameof(DataToFind), DynamicDataSourceType.Property)]
        public void Details_ShouldGetItem(
            int id,
            string chassis)
        {
            // Act
            var result = Controller.Details(id) as ViewResult;

            var model = (TruckViewModel)result?.Model;

            // Assert
            Assert.AreEqual(chassis, model?.Chassis, "It should return the same Chassis");
        }

        #endregion

        #region snippet_Create_ShouldCreateItem

        [TestMethod]
        public void Create_ShouldReturnView()
        {
            // Act
            var result = Controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result?.Model, "It should return the View");
        }

        [DataTestMethod]
        [DataRow(2019)]
        public void Create_ShouldReturnViewWithYear(int year)
        {
            // Act
            var result = Controller.Create() as ViewResult;

            var model = (TruckViewModel)result?.Model;

            // Assert
            Assert.AreEqual(year, model.Year, "It should return the View");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataToAdd), DynamicDataSourceType.Property)]
        public void Create_ShouldCreateItem(
            string chassis,
            EnumModelViewModel model,
            int year,
            int modelYear)
        {
            // Arrange
            var truckViewModel = new TruckViewModel
            {
                Chassis = chassis,
                Model = model,
                Year = year,
                ModelYear = modelYear
            };

            // Act
            var result = Controller.Create(truckViewModel) as RedirectToActionResult;
            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Chassis.Equals(chassis)).FirstOrDefault();

            // Assert
            Assert.AreEqual(nameof(TrucksController.Index), result?.ActionName, "It should create and redirect to Index");

            Assert.AreEqual(chassis, truck.Chassis, "Item was not added");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataToValidate), DynamicDataSourceType.Property)]
        public void Create_ShouldReturnValidationError(
            string key,
            string message)
        {
            // Arrange
            var truckViewModel = new TruckViewModel();

            Controller.ModelState.AddModelError(key, message);

            // Act
            var result = Controller.Create(truckViewModel) as ViewResult;

            var error = result.ViewData.ModelState.GetValueOrDefault(key).Errors.FirstOrDefault(v => v.ErrorMessage == message);

            // Assert
            Assert.AreEqual(message, error.ErrorMessage, "It should be valid");
        }

        [DataTestMethod]
        [DataRow(-1)]
        public void Create_ShouldThrowException(int id)
        {
            // Arrange
            TruckService = new Mock<TruckService>(new FakeUnitOfWorkWithException(), Mapper);

            Controller = new TrucksController(Logger.Object, TruckService.Object);

            // Act
            var result = Controller.Create(new TruckViewModel { Id = id }) as ViewResult;

            var model = (TruckViewModel)result.Model;

            // Assert
            Assert.AreEqual(id, model.Id, "Exception was not thrown");
        }

        #endregion

        #region snipper_Edit_ShouldEditItem

        [DataTestMethod]
        [DynamicData(nameof(DataToFind), DynamicDataSourceType.Property)]
        public void Edit_ShouldGetItem(
            int id,
            string chassis)
        {
            // Act
            var result = Controller.Edit(id) as ViewResult;

            var model = (TruckViewModel)result?.Model;

            // Assert
            Assert.AreEqual(chassis, model?.Chassis, "It should return the same Chassis");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataToUpdate), DynamicDataSourceType.Property)]
        public void Edit_ShouldEditItem(
            int id,
            string chassis,
            EnumModelViewModel model,
            int year,
            int modelYear)
        {
            // Arrange
            var truckViewModel = new TruckViewModel
            {
                Id = id,
                Chassis = chassis,
                Model = model,
                Year = year,
                ModelYear = modelYear
            };

            // Act
            var result = Controller.Edit(id, truckViewModel) as RedirectToActionResult;
            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Chassis.Equals(chassis)).FirstOrDefault();

            // Assert
            Assert.AreEqual(nameof(TrucksController.Index), result?.ActionName, "It should edit and redirect to Index");

            Assert.AreEqual(chassis, truck.Chassis, "Item was not updated");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataToValidate), DynamicDataSourceType.Property)]
        public void Edit_ShouldReturnValidationError(
            string key,
            string message)
        {
            // Arrange
            var truckViewModel = new TruckViewModel();

            Controller.ModelState.AddModelError(key, message);

            // Act
            var result = Controller.Edit(0, truckViewModel) as ViewResult;

            var error = result.ViewData.ModelState.GetValueOrDefault(key).Errors.FirstOrDefault(v => v.ErrorMessage == message);

            // Assert
            Assert.AreEqual(message, error.ErrorMessage, "It should be valid");
        }

        [DataTestMethod]
        [DataRow(-1)]
        public void Edit_ShouldThrowException(int id)
        {
            // Arrange
            TruckService = new Mock<TruckService>(new FakeUnitOfWorkWithException(), Mapper);

            Controller = new TrucksController(Logger.Object, TruckService.Object);

            // Act
            var result = Controller.Edit(id, new TruckViewModel { Id = id }) as ViewResult;

            var model = (TruckViewModel)result.Model;

            // Assert
            Assert.AreEqual(id, model.Id, "Exception was not thrown");
        }

        #endregion

        #region snipper_Delete_ShouldDeleteItem

        [DataTestMethod]
        [DynamicData(nameof(DataToFind), DynamicDataSourceType.Property)]
        public void Delete_ShouldGetItem(
            int id,
            string chassis)
        {
            // Act
            var result = Controller.Delete(id) as ViewResult;

            var model = (TruckViewModel)result?.Model;

            // Assert
            Assert.AreEqual(chassis, model?.Chassis, "It should return the same Chassis");
        }

        [DataTestMethod]
        [DynamicData(nameof(DataToRemove), DynamicDataSourceType.Property)]
        public void Delete_ShouldDeleteItem(int id)
        {
            // Arrange
            var truckViewModel = new TruckViewModel
            {
                Id = id
            };

            // Act
            var result = Controller.Delete(id, truckViewModel) as RedirectToActionResult;
            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Id == id).FirstOrDefault();

            // Assert
            Assert.AreEqual(nameof(TrucksController.Index), result?.ActionName, "It should delete and redirect to Index");

            Assert.IsNull(truck, "Item was not deleted");
        }

        [DataTestMethod]
        [DataRow(-1)]
        public void Delete_ShouldThrowException(int id)
        {
            // Arrange
            TruckService = new Mock<TruckService>(new FakeUnitOfWorkWithException(), Mapper);

            Controller = new TrucksController(Logger.Object, TruckService.Object);

            // Act
            var result = Controller.Delete(id, new TruckViewModel { Id = id }) as ViewResult;

            var model = (TruckViewModel)result.Model;

            // Assert
            Assert.AreEqual(id, model.Id, "Exception was not thrown");
        }

        #endregion

        #region snippet_ModelValidade

        [DataTestMethod]
        [DataRow("The Chassis is invalid.", "1111111111111", null, null)]
        [DataRow(
            "The field Chassis must be a string or array type with a maximum length of '17'.", 
            "111111111111111111111111111111111111111", null, null)]
        [DataRow(
            "The field Chassis must be a string or array type with a maximum length of '17'.", 
            "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111", null, null)]
        [DataRow("The field Model is invalid.", "a", 0, null)]
        public void ModelValidate(
            string message,
            string chassis,
            EnumModelViewModel model,
            string modelComplement)
        {
            // Arrange
            var truckViewModel = new TruckViewModel
            {
                Chassis = chassis,
                Model = model
            };

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(truckViewModel, serviceProvider: null, items: null);

            var validationResults = new List<ValidationResult>();

            // Act
            Validator.TryValidateObject(truckViewModel, context, validationResults, true);

            // Assert
            Assert.IsNotNull(validationResults.Find(c => c.ErrorMessage == message));
        }


        #endregion

        #region snippet_DataRowValues

        public static IEnumerable<object[]> DataToAdd
        {
            get
            {
                yield return new object[] { "YB3L06BA3GB034835", EnumModelViewModel.FH, DateTime.Today.Year, DateTime.Today.Year + 1 };
                yield return new object[] { "YV1902SE9F1175906", EnumModelViewModel.FM, DateTime.Today.Year, DateTime.Today.Year + 1 };
            }
        }

        public static IEnumerable<object[]> DataToUpdate
        {
            get
            {
                return new FakeTruckRepository().Entities.Select(e => new object[] { e.Id, "YV4952CY8E1680461", e.Model, e.Year, e.ModelYear }).ToList();
            }
        }

        public static IEnumerable<object[]> DataToRemove
        {
            get
            {
                return new FakeTruckRepository().Entities.Select(e => new object[] { e.Id }).ToList();
            }
        }

        public static IEnumerable<object[]> DataToGetAll
        {
            get
            {
                yield return new object[] { new FakeTruckRepository().Entities.Count };
            }
        }

        public static IEnumerable<object[]> DataToFind
        {
            get
            {
                return new FakeTruckRepository().Entities.Select(e => new object[] { e.Id, e.Chassis }).ToList();
            }
        }

        public static IEnumerable<object[]> DataToValidate
        {
            get
            {
                yield return new object[] { nameof(TruckViewModel.Chassis), "The Chassis field is required." };
                yield return new object[] { nameof(TruckViewModel.Model), "The Model field is required." };
                yield return new object[] { nameof(TruckViewModel.Year), "The Year field is required." };
                yield return new object[] { nameof(TruckViewModel.ModelYear), "The ModelYear field is required." };
                yield return new object[] { nameof(TruckViewModel.Chassis), "The Chassis is invalid." };
            }
        }

        #endregion

    }
}
