using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trucks.Application.Services;
using AutoMapper;
using Trucks.Application.AutoMapper;
using Trucks.UnitTests.FakeObjects.UnitOfWork;
using System.Linq;
using Trucks.Application.Contracts;
using Trucks.Application.ViewModels;
using Trucks.Application.ViewModels.Enumerables;
using System;

namespace Trucks.UnitTests.Application.Services
{
    [TestClass]
    public class TruckServiceUnitTests
    {

        #region snippet_Variables

        public Mapper Mapper { get; private set; }
        public FakeUnitOfWork FakeUnitOfWork { get; private set; }
        public ITruckService TruckService { get; private set; }

        #endregion

        #region snippet_Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            FakeUnitOfWork = new FakeUnitOfWork();

            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MappingProfile())));

            TruckService = new TruckService(FakeUnitOfWork, Mapper);
        }

        #endregion

        #region snippet_Add_ShouldAddNewItem

        [DataTestMethod]
        [DynamicData(nameof(DataToAdd), DynamicDataSourceType.Property)]
        public void Add_ShouldAddNewItem(
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
            TruckService.Add(truckViewModel);

            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Chassis.Equals(chassis)).FirstOrDefault();

            // Assert
            Assert.AreEqual(chassis, truck.Chassis, "Item was not added");

        }

        #endregion

        #region snippet_Update_ShouldUpdateItem

        [DataTestMethod]
        [DynamicData(nameof(DataToUpdate), DynamicDataSourceType.Property)]
        public void Update_ShouldUpdateItem(
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
            TruckService.Update(truckViewModel);

            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Chassis.Equals(chassis)).FirstOrDefault();

            // Assert
            Assert.AreEqual(chassis, truck.Chassis, "Item was not updated");

        }

        #endregion

        #region snippet_Remove_ShouldRemoveItem

        [DataTestMethod]
        [DynamicData(nameof(DataToRemove), DynamicDataSourceType.Property)]
        public void Remove_ShouldRemoveItem(int id)
        {
            // Act
            TruckService.Remove(id);

            var truck = FakeUnitOfWork.TruckRepository.GetAll(t => t.Id == id).FirstOrDefault();

            // Assert
            Assert.IsNull(truck, "Item was not deleted");

        }

        #endregion

        #region snippet_Find_ShouldFindItem

        [DataTestMethod]
        [DynamicData(nameof(DataToFind), DynamicDataSourceType.Property)]
        public void Find_ShouldFindItem(
            int id, 
            string chassis)
        {
            // Act
            TruckViewModel truckViewModel = TruckService.Find(id);

            // Assert
            Assert.AreEqual(chassis, truckViewModel.Chassis, "It should return the same Chassis");
        }

        #endregion

        #region snippet_GetAll_ShouldListAllItems

        [DataTestMethod]
        [DynamicData(nameof(DataToGetAll), DynamicDataSourceType.Property)]
        public void GetAll_ShouldListAllItems(int count)
        {
            // Act
            List<TruckViewModel> trucksViewModel = TruckService.GetAll();

            // Assert
            Assert.AreEqual(count, trucksViewModel.Count(), "It should return the correct count");
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

        #endregion

    }
}
