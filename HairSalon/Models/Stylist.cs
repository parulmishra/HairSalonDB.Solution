using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
	public class Stylist
	{
		private int _id;
		private string _name;
		private string _expertise;
		private int _experience;
		private int _rate;
		
		public Stylist(string name, string expertise, int experience, int rate, int id = 0)
		{
			_name = name;
			_expertise = expertise;
			_experience = experience;
			_rate = rate;
			_id= id;
		}
		public int GetId()
		{
			return _id;
		}
		public string GetName()
		{
			return _name;
		}
		public string GetExpertise()
		{
			return _expertise;
		}
		public int GetExperience()
		{
			return _experience;
		}
		public int GetRate()
		{
			return _rate;
		}
		
		public override bool Equals(System.Object otherStylist)
		{
			if(!(otherStylist is Stylist))
			{
				return false;
			}
			else
			{
				Stylist newStyist = (Stylist) otherStylist;
				bool idEquality = (this.GetId() == newStyist.GetId());
				bool nameEquality = (this.GetName() == newStyist.GetName());
				bool expertiseEquality = (this.GetExpertise() == newStyist.GetExpertise());
				bool experienceEquality = (this.GetExperience() == newStyist.GetExperience());
				bool rateEquality = (this.GetRate() == newStyist.GetRate());
				return (idEquality && nameEquality && expertiseEquality && experienceEquality && rateEquality);	
			}
		}
		public override int GetHashCode()
		{
			return this.GetName().GetHashCode();
		}
		
		public static List<Stylist> GetAll()
		{
			List<Stylist> allStylist = new List<Stylist>();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist;";
			var rdr = cmd.ExecuteReader() as MySqlDataReader;
			while(rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				string expertise = rdr.GetString(2);
				int experience = rdr.GetInt32(3);
				int rate = rdr.GetInt32(4);
				Stylist newStylist = new Stylist(name, expertise, experience, rate, id);
				allStylist.Add(newStylist);
			}
			conn.Close();
			return allStylist;
		}
		public void Save()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO stylist(name,expertise,experience,rate) VALUES(@name,@expertise,@experience,@rate);";
			
			MySqlParameter name = new MySqlParameter();
			name.ParameterName = "@name";
			name.Value = this._name;
			cmd.Parameters.Add(name);
			
			MySqlParameter expertise = new MySqlParameter();
			expertise.ParameterName = "@expertise";
			expertise.Value = this._expertise;
			cmd.Parameters.Add(expertise);
			
			MySqlParameter experience = new MySqlParameter();
			experience.ParameterName = "@experience";
			experience.Value = this._experience;
			cmd.Parameters.Add(experience);
			
			MySqlParameter rate = new MySqlParameter();
			rate.ParameterName = "@rate";
			rate.Value = this._rate;
				cmd.Parameters.Add(rate);
			
			cmd.ExecuteNonQuery();
			_id = (int) cmd.LastInsertedId;
			conn.Close();
		}
		public static Stylist Find(int id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM stylist WHERE id = @searchId";

			MySqlParameter searchId = new MySqlParameter();
			searchId.ParameterName = "@searchId";
			searchId.Value = id;
			cmd.Parameters.Add(searchId);

			var rdr = cmd.ExecuteReader() as MySqlDataReader;
			int stylistId = 0;
			string name = "";
			string expertise = "";
			int experience = 0;
			int rate = 0;

			while (rdr.Read())
			{
				stylistId = rdr.GetInt32(0);
				name = rdr.GetString(1);
				expertise = rdr.GetString(2);
				experience = rdr.GetInt32(3);
				rate = rdr.GetInt32(4);
			}
			Stylist newStylist = new Stylist(name,expertise,experience,rate,stylistId);
			conn.Close();
			return newStylist;
		}
		public List<Client> GetClients()
		{
			List<Client> stylistClients = new List<Client>();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM client WHERE stylistId = @thisId;";

			MySqlParameter stylistId = new MySqlParameter();
			stylistId.ParameterName = "@thisId";
			stylistId.Value = this._id;
			cmd.Parameters.Add(stylistId);

			int id;
			string name;
			string email;
			string phone;
			int stId;

			var rdr = cmd.ExecuteReader() as MySqlDataReader;

			while(rdr.Read())
			{
				id = rdr.GetInt32(0);
				name = rdr.GetString(1);
				email = rdr.GetString(2);
				phone =rdr. GetString(3);
				stId = rdr.GetInt32(4);
				Client newClient = new Client(name,email,phone,stId,id);
				stylistClients.Add(newClient);
			}
			conn.Close();
			return stylistClients;
		}
		public static void DeleteAll()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"DELETE FROM stylist;";
			cmd.ExecuteNonQuery();
			conn.Close();
		}
		public static void Delete(int id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"DELETE FROM stylist WHERE id = (@searchId);";
			MySqlParameter searchId = new MySqlParameter();
			searchId.ParameterName = "@searchId";
			searchId.Value = id;
			cmd.Parameters.Add(searchId);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}