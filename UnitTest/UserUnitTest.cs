using EventManagerLib.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        private User us = null;

        [TestInitialize]
        public void BeforeEachTestMethod()
        {
            us = new User();

        }


        [TestMethod]
        [DataRow("123")]
        [DataRow("cecilie")]
        [DataRow("A long text string....")]
        public void TestLastNameOk(string lastname)
        {
            //Arrange
            User u = new User();
            string expectedLastName = lastname;

            //Act
            u.LastName = lastname;

            //Asset
            Assert.AreEqual(expectedLastName, u.LastName);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("12")]
        public void TestLastNameNotOk(string lastname)
        {
            //Arrange
            User u = new User();


            //Act

            //Asset
            Assert.ThrowsException<ArgumentException>(() => u.LastName = lastname);
        }

        [TestMethod]
        [DataRow("1234")]
        [DataRow("cille1")]
        [DataRow("long text.....")]
        public void TestPasswordOk(string password)
        {
            //Arrange
            User u = new User();
            string expectedePassword = password;

            //Act
            u.Password = password;

            //Asset
            Assert.AreEqual(expectedePassword, u.Password);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("12")]
        public void TestPasswordNotOk(string password)
        {
            //Arrange
            User u = new User();

            //Act

            //Asset
            Assert.ThrowsException<ArgumentException>(() => u.Password = password);
        }
        /*
 * Testing property  FirstName- At least 3 chars
 */

        // acceptable values 3 chars and 10 char
        [TestMethod]
        [DataRow("123")]
        [DataRow("1234567890")]
        public void TestFirstNameAccept(string FirstName)
        {
            // Arrange
            string expectedValue = FirstName;

            // Act
            us.FirstName = FirstName;
            string actualValue = us.FirstName;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod]
        [DataRow("88888888")]
        public void PhoneAccept(string Phone)
        {
            // Arrange
            string expectedValue = Phone;
           
            // Act
            us.Phone = Phone;
            string actualValue = us.Phone;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        // Error values 2 chars  
        [TestMethod]
        [DataRow("1")]
        public void TestFirstNameNotAccept1(string FirstName)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.FirstName = FirstName);

        }


        // Error values null and 10 spaces -> empty 
        [TestMethod]
        [DataRow(null)]

        public void TestFirstNameNotAccept2(String FirstName)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => us.FirstName = FirstName);

        }

        

        // Error values 7 char
        [TestMethod]
        [DataRow("1234567")]
        public void TestPhoneNotAccept1(String Phone)
        {
            // Arrange - all in assert
            
            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => us.Phone = Phone);

        }




        // Error values 9 Chars  
        [TestMethod]
        [DataRow("234567890")]
        public void TestPhoneNotAccept3(String Phone)
        {


            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => us.Phone = Phone);

        }




        // Error values null  -> empty 
        [TestMethod]
        [DataRow(null)]

        public void TestPhoneNotAccept2(String Phone)
        {
            // Arrange - all in assert

            // Act - all in assert

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => us.Phone = Phone);

        }

    }
}
