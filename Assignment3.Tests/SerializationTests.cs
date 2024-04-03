using System.Collections.Generic;
using NUnit.Framework;
using Assignment3; 

namespace Assignment3.Tests
{
    [TestFixture]
    public class SerializationTests
    {
        private List<User> users = new List<User>();
        private readonly string testFileName = @"..\..\user.bin";

        
        [SetUp]
        public void Setup()
        {
            users.Add(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Add(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Add(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Add(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            
            this.users.Clear();
        }

        [Test]
        public void TestSerialization()
        {
           SerializationHelper.SerializeUsers(users, testFileName);
           Assert.IsTrue(File.Exists(testFileName));
        }

        
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            List<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            Assert.AreEqual(users.Count, deserializedUsers.Count);
            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(users[i].Id, deserializedUsers[i].Id);
                Assert.AreEqual(users[i].Name, deserializedUsers[i].Name);
                Assert.AreEqual(users[i].Email, deserializedUsers[i].Email);
                Assert.AreEqual(users[i].Password, deserializedUsers[i].Password);
            }
        }
    }
}
