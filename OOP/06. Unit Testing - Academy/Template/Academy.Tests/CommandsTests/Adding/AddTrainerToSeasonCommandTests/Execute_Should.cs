using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Core;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Academy.Tests.CommandsTests.Adding.AddTrainerToSeasonCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Throw_When_ParametersAreLessThenExpected()
        {
            var sut = GetCommand("trainer1");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonIdIsNotInteger()
        {
            var sut = GetCommand("trainer1", "a");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_TrainerDoesNotExist()
        {
            var sut = GetCommand("trainer3", "0");

            Assert.ThrowsException<InvalidOperationException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_SeasonDoesNotExist()
        {
            var sut = GetCommand("trainer1", "200");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_TrainerAlreadyInSeason()
        {
            var sut = GetCommand("trainer1", "0");

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnMessage_When_ParametersAreCorrect()
        {
            var sut = GetCommand("trainer2", "0");

            Assert.IsNotNull(sut.Execute());
        }

        private ICommand GetCommand(params string[] parameters)
        {
            Repository repository = this.GetRepository();
            IList<string> parametersList = new List<string>(parameters);
            ICommand command = new AddTrainerToSeasonCommand(parametersList, repository);
            return command;
        }

        private Repository GetRepository()
        {
            Repository repository = new Repository();

            var trainer = repository.CreateTrainer("trainer1", new List<string>());
            repository.CreateTrainer("trainer2", new List<string>());
            var season = repository.CreateSeason(2019, 2020, Initiative.SoftwareAcademy);
            season.Trainers.Add(trainer);

            return repository;
        }
    }
}
