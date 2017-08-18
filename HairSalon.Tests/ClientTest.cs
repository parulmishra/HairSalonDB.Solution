using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=hair_salon_test;";
    }
    [TestMethod]
    public void GetAll_DatabaseCountsWhenTheDatabaseIsEmpty_0()
    {
      //Arrange
      int expected = 0;
      //Act
      int actual = Client.GetAll().Count;
      //Assert
      Assert.AreEqual(expected,actual);
    }
    [TestMethod]
    public void GetAll_ReturnsDatabaseCounts_2()
    {
      //Arrange
      Client newClient1 = new Client("client1","client1@gmail.com","1234567891",1);
      newClient1.Save();
      Client newClient2 = new Client("client2","client2@gmail.com","1234567892",1);
      newClient2.Save();
      int expected = 2;
      //Act
      int actual = Client.GetAll().Count;
      //Assert
      Assert.AreEqual(expected,actual);
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameObjects_True()
    {
      //Arrange
      Client newClient1 = new Client("client3","client3@gmail.com","1234567893",1);
      Client newClient2 = new Client("client3","client3@gmail.com","1234567893",1);
	  //Act
	  bool actual = Client.Equals(newClient1, newClient2);
	  //Assert
      Assert.AreEqual(true,actual);
    }
      [TestMethod]
      public void Save_SavesEntryToDatabase_allClients()
      {
		//Arrange
        Client newClient = new Client("client3","client3@gmail.com","1234567893",1);
        newClient.Save();
		List<Client> expected = new List<Client>();
		//Act
        List<Client> actual = Client.GetAll();
        expected.Add(newClient);
		//Assert
        CollectionAssert.AreEqual(expected,actual);
      }
      [TestMethod]
      public void Find_FindsClientInDatabase_SpecificClientRecord()
      {
		//Arrange
        Client expected = new Client("client4","client4@gmail.com","1234567894",1);
        expected.Save();
		//Act
        Client actual = Client.Find(expected.GetId());
		//Assert
        Assert.AreEqual(expected, actual);
      }
      /*[TestMethod]
      public void Update_UpdatesPhoneNumberOfClientInDatabase_String()
      {
      //Arrange
       Client newClient = new Client("client5","client5@gmail.com","1234567895",5);
       newClient.Save();
       string newNumber = "";
	  //Act
      newClient.UpdateNumber(newNumber);
      string actual = newClient.GetPhone();
    //Assert
      Assert.AreEqual(newNumber,actual);
    }
	*/
  }
}