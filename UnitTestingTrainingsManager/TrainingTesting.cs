using DataLayer;
using DomainLibrary.Domain;
using Interface_TrainingManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace UnitTestingTrainingsManager
{
    [TestClass]
    public class TrainingTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            //TrainingManager test = new TrainingManager(new UnitOfWork(new TrainingContext("Test")));
            //test.AddCyclingTraining(new DateTime(2020, 4, 19, 16, 45, 00), null, new TimeSpan(1, 0, 00), null, 219, TrainingType.Interval, "5x5 min 270", BikeType.IndoorBike);
        }
    }
    public class TrainingContextTest : TrainingContext
    {
        public TrainingContextTest(bool keepExistingDB = false) : base("Test")
        {
            if(keepExistingDB)
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
