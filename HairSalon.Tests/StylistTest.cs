using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=hair_salon_test;";
    }
    [TestMethod]
    public void GetAll_DatabaseCountsWhenTheDatabaseIsEmpty_0()
    {
      //Arrange
      int expected = 0;
      //Act
      int actual = Stylist.GetAll().Count;
      //Assert
      Assert.AreEqual(expected,actual);
    }
    [TestMethod]
    public void GetAll_ReturnsDatabaseCounts_2()
    {
      //Arrange
      Stylist newStylist1 = new Stylist("nina","haircut",1,70,1);
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("mina","haircolor",2,100,2);
      newStylist2.Save();
      int expected = 2;
      //Act
      int actual = Stylist.GetAll().Count;
      //Assert
      Assert.AreEqual(expected,actual);
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameObjects_True()
    {
      //Arrange
      Stylist newStylist1 = new Stylist("parul","haircut",2,100,3);
      Stylist newStylist2 = new Stylist("parul","haircut",2,100,3);
	  //Act
	  bool actual = Stylist.Equals(newStylist1, newStylist2);
	  //Assert
      Assert.AreEqual(true,actual);
    }
      [TestMethod]
      public void Save_SavesEntryToDatabase_allStylist()
      {
		//Arrange
        Stylist newStylist = new Stylist("riya","haircut",2,100,3);
        newStylist.Save();
		List<Stylist> expected = new List<Stylist>();
		//Act
        List<Stylist> actual = Stylist.GetAll();
        expected.Add(newStylist);
		//Assert
        CollectionAssert.AreEqual(expected,actual);
      }
      [TestMethod]
      public void Find_FindsStylistInDatabase_SpecificStylistRecord()
      {
		//Arrange
        Stylist expected = new Stylist("ina","haircolor",3,120,4);
        expected.Save();
		//Act
        Stylist actual = Stylist.Find(expected.GetId());
		//Assert
        Assert.AreEqual(expected, actual);
      }
      /*[TestMethod]
      public void Update_UpdatesRateOfStylistInDatabase_Int()
      {
		//Arrange
		Stylist newStylist = new Stylist("nina","haircut",1,70);
		newStylist.Save();
		int expected = 0;
		//Act
		newstylist.UpdateRate(expected);
		string actual = newStylist.GetRate();
		//Assert
		Assert.AreEqual(expected,actual);
	  }
	  */
  }
}