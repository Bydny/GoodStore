using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.BussinessLogic.Implementation.Services;
using GoodStore.DataAccess.Interfaces;
using GoodStore.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace GoodStore.UnitTests.Services
{
    public class GoodStoreServiceTests
    {
        private Mock<IRepository<GoodEntity>> _goodRepositoryMock;
        private Mock<IMapper> _mapperMock;

        private IGoodService _goodService;

        private static IEnumerable<GoodEntity> _fakeGoodsStore = new List<GoodEntity>()
        {
            new GoodEntity()
            {
                Name = "Milk",
                GoodTypeId = 10,
            },
            new GoodEntity()
            {
                Name = "Meat",
                GoodTypeId = 7,
            },
            new GoodEntity()
            {
                Name = "Nuts",
                GoodTypeId = 5,
            },
            new GoodEntity()
            {
                Name = "Mood",
                GoodTypeId = 10,
            },
            new GoodEntity()
            {
                Name = "Apple",
                GoodTypeId = 2,
            },
            new GoodEntity()
            {
                Name = "Cucumber",
                GoodTypeId = 1,
            },
            new GoodEntity()
            {
                Name = "Pine",
                GoodTypeId = 7,
            },
        };

        [SetUp]
        public void Init()
        {
            _goodRepositoryMock = new Mock<IRepository<GoodEntity>>();
            _mapperMock = new Mock<IMapper>();

            _goodService = new GoodService(_goodRepositoryMock.Object, _mapperMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _goodRepositoryMock = null;
            _mapperMock = null;

            _goodService = null;
        }

        public delegate TResult FilterRepository<in T1, in T2, out TResult>(
            T1 arg1,
            T2 arg2);

        [Test]
        public async Task GetFilteredByTypeReturnsItems()
        {
            //Arrange
            _goodRepositoryMock
                .Setup(x =>
                    x.FilterIncludeAsync(It.IsAny<Expression<Func<GoodEntity, bool>>>(), It.IsAny<string[]>()))
                .ReturnsAsync((Expression<Func<GoodEntity, bool>> x, string [] y) => _fakeGoodsStore.Where(x.Compile()).ToList());

            _mapperMock
                .Setup(x => x.Map<IEnumerable<GoodDto>>(It.IsAny<IEnumerable<GoodEntity>>()))
                .Returns((IEnumerable<GoodEntity> x) => x.Select(y => new GoodDto() { Name = y.Name, GoodTypeId = y.GoodTypeId }));

            var typeId = 10;

            //Act
            var resultGoods = await _goodService.GetFilteredByTypeAsync(typeId);

            //Assert
            Assert.IsTrue(resultGoods.All(x => x.GoodTypeId == typeId));
            Assert.AreEqual(
                _fakeGoodsStore.Count(x => x.GoodTypeId == typeId), 
                resultGoods.Count());
        }

        [Test]
        public async Task GetNameStartedWithReturnsItems()
        {
            //Arrange
            _goodRepositoryMock
                .Setup(x =>
                    x.FilterIncludeAsync(It.IsAny<Expression<Func<GoodEntity, bool>>>(), It.IsAny<string[]>()))
                .ReturnsAsync((Expression<Func<GoodEntity, bool>> x, string[] y) => _fakeGoodsStore.Where(x.Compile()).ToList());

            _mapperMock
                .Setup(x => x.Map<IEnumerable<GoodDto>>(It.IsAny<IEnumerable<GoodEntity>>()))
                .Returns((IEnumerable<GoodEntity> x) => x.Select(y => new GoodDto() { Name = y.Name, GoodTypeId = y.GoodTypeId }));

            var namePrefix = "M";

            //Act
            var resultGoods = await _goodService.GetStartedWithNameAsync(namePrefix);

            //Assert
            Assert.IsTrue(resultGoods.All(x => x.Name.StartsWith(namePrefix)));
            Assert.AreEqual(
                _fakeGoodsStore.Count(x => x.Name.StartsWith(namePrefix)),
                resultGoods.Count());

        }
    }
}
