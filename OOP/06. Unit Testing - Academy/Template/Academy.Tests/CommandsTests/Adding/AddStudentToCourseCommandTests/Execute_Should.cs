using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Academy.Tests.CommandsTests.Adding.AddStudentToCourseCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Throw_When_ParametersAreLessThenExpected()
        {
            //Arrange
            var sut = GetCommand("student", "0", "0");

            //Act, Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonIdIsNotInteger()
        {
            //Arrange
            var sut = GetCommand("student", "seasonID", "0", "onsite");

            //Act, Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_CourseIdIsNotInteger()
        {
            //Arrange
            var sut = GetCommand("student", "0", "courseId", "onsite");

            //Act, Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_StudentDoesNotExist()
        {
            var sut = GetCommand("student3", "0", "0", "onsite");

            Assert.ThrowsException<InvalidOperationException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonDoesNotExist()
        {
            var sut = GetCommand("student", "200", "0", "onsite");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_CourseDoesNotExist()
        {
            var sut = GetCommand("student", "0", "200", "onsite");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_FormIsInvalid()
        {
            var sut = GetCommand("student", "0", "0", "on the beach");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnMessage_When_ParametersAreCorrect()
        {
            var sut = GetCommand("student", "0", "0", "online");

            Assert.IsNotNull(sut.Execute());
        }

        private ICommand GetCommand(params string[] parameters)
        {
            Repository repository = this.GetRepository();
            IList<string> parametersList = new List<string>(parameters);
            ICommand command = new AddStudentToCourseCommand(parametersList, repository);
            return command;
        }

        private Repository GetRepository()
        {
            Repository repository = new Repository();

            repository.CreateStudent("student", Track.Dev);
            var season = repository.CreateSeason(2019, 2020, Initiative.SoftwareAcademy);
            var course = repository.CreateCourse("C# OOP", 5, DateTime.Parse("2019-09-15"), DateTime.Parse("2020-03-03"));
            season.Courses.Add(course);

            return repository;
        }
    }
}
