using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Models;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Academy.Tests.CommandsTests.Adding.AddStudentToSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Throw_When_ParametersAreLessThenExpected()
        {
            var sut = GetCommand("student1");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonIdIsNotInteger()
        {
            var sut = GetCommand("student1", "a");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_StudentDoesNotExist()
        {
            var sut = GetCommand("student3", "0");

            Assert.ThrowsException<InvalidOperationException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonDoesNotExist()
        {
            var sut = GetCommand("student1", "200");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Execute());
        }

        [TestMethod] //TODO
        public void Throw_When_StudentAlreadyInSeason()
        {
            var sut = GetCommand("student1", "0");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnMessage_When_ParametersAreCorrect()
        {
            var sut = GetCommand("student2", "0");

            Assert.IsNotNull(sut.Execute());
        }


        private ICommand GetCommand(params string[] parameters)
        {
            Repository repository = this.GetRepository();
            IList<string> parametersList = new List<string>(parameters);
            ICommand command = new AddStudentToSeasonCommand(parametersList, repository);
            return command;
        }

        private Repository GetRepository()
        {
            Repository repository = new Repository();

            var student = repository.CreateStudent("student1", Track.Dev);
            repository.CreateStudent("student2", Track.Dev);
            var season = repository.CreateSeason(2019, 2020, Initiative.SoftwareAcademy);
            season.Students.Add(student);

            return repository;
        }
    }
}
