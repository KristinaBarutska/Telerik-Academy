namespace Cars.Tests.Moq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using NUnit.Framework;
    using global::Moq;

    [TestFixture]
    public class CarsControllerTests
    {
        private CarsController controller;
        private IList<Car> fakeDatabase;

        [OneTimeSetUp]
        public void SetupMockedRepository()
        {
            var mockedRepository = new Mock<ICarsRepository>();

            this.fakeDatabase = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 }
            };

            mockedRepository.SetupGet(r => r.TotalCars).Returns(this.fakeDatabase.Count);
            mockedRepository.Setup(r => r.Add(It.IsAny<Car>())).Callback<Car>(c => this.fakeDatabase.Add(c));
            mockedRepository.Setup(r => r.Remove(It.IsAny<Car>())).Callback<Car>(c => this.fakeDatabase.Remove(c));
            mockedRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns<int>(id => this.fakeDatabase.FirstOrDefault(c => c.Id == id));
            mockedRepository.Setup(r => r.All()).Returns(this.fakeDatabase);
            mockedRepository.Setup(r => r.SortedByMake()).Returns(this.fakeDatabase.OrderBy(c => c.Make).ToList());
            mockedRepository.Setup(r => r.SortedByYear()).Returns(this.fakeDatabase.OrderBy(c => c.Year).ToList());
            mockedRepository.Setup(r => r.Search(It.IsAny<string>()))
                .Returns<string>(cond => this.fakeDatabase.Where(c => c.Make == cond || c.Model == cond).ToList());

            controller = new CarsController(mockedRepository.Object);
        }

        [Test]
        public void Index_ShouldReturnAllCarsFromTheRepository()
        {
            var expectedCars = this.fakeDatabase;
            var actualCars = this.controller.Index().Model as IList<Car>;

            CollectionAssert.AreEqual(expectedCars, actualCars);
        }

        [Test]
        public void Add_ValidCar_ShouldAddItToTheRepository()
        {
            this.controller.Add(new Car { Id = 5, Make = "Toyota", Model = "Avensis", Year = 2014 });

            int expectedCarsCount = 5;
            int actualCarsCount = (this.controller.Index().Model as IList<Car>).Count;

            Assert.AreEqual(expectedCarsCount, actualCarsCount);
        }

        [Test]
        public void Add_Null_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => this.controller.Add(null));
        }

        [Test]
        public void Add_CarWithEmptyStringForMake_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => this.controller.Add(new Car { Id = 5, Make = string.Empty, Model = "A5", Year = 2005 }));
        }
        [Test]
        public void Add_CarWithEmptyNullForMake_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => this.controller.Add(new Car { Id = 5, Make = null, Model = "A5", Year = 2005 }));
        }

        [Test]
        public void Add_CarWithEmptyStringForModel_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => this.controller.Add(new Car { Id = 5, Make = "Audi", Model = string.Empty, Year = 2005 }));
        }
        [Test]
        public void Add_CarWithEmptyNullForModel_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => this.controller.Add(new Car { Id = 5, Make = "Audi", Model = null, Year = 2005 }));
        }

        [Test]
        public void Details_IdOfExistingCar_ShouldReturnModelWithTheCarWithThisId()
        {
            int id = 1;
            var expected = this.fakeDatabase[0];
            var actual = this.controller.Details(id).Model as Car;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Details_IdOfNonExistingCar_ShouldThrowArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => this.controller.Details(666));
        }

        [Test]
        public void Search_ValidMakeAsCondition_ShouldReturnListWithAllCarsWithThisMake()
        {
            var expected = new List<Car> { this.fakeDatabase[1], this.fakeDatabase[2] };
            var actual = this.controller.Search("BMW").Model as IList<Car>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Search_ValidModelAsCondition_ShouldReturnListWithAllCarsWithThisModel()
        {
            var expected = new List<Car> { this.fakeDatabase[0] };
            var actual = this.controller.Search("A5").Model as IList<Car>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Search_NonValidCondition_ShouldReturnEmptyList()
        {
            Assert.AreEqual(0, (this.controller.Search("A55").Model as ICollection<Car>).Count);
        }
    }
}