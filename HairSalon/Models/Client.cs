using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
	public class Client
	{
		private int _id;
		private string _name;
		private string _email;
		private string _phone;
		private int _stylistId;
		
		public Client(string name, string email, string phone, int stylistId, int id = 0)
		{
			_name = name;
			_email = email;
			_phone = phone;
			_stylistId = stylistId;
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
		public string GetEmail()
		{
			return _email;
		}
		public string GetPhone()
		{
			return _phone;
		}
		public int GetStylistId()
		{
			return _stylistId;
		}
		
		public override bool Equals(System.Object otherClient)
		{
			if(!(otherClient is Client))
			{
				return false;
			}
			else
			{
				Client newClient = (Client) otherClient;
				bool idEquality = (this.GetId() == newClient.GetId());
				bool nameEquality = (this.GetName() == newClient.GetName());
				bool emailEquality = (this.GetEmail() == newClient.GetEmail());
				bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
				bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
				return (idEquality && nameEquality && emailEquality && phoneEquality && stylistIdEquality);	
			}
		}
		public override int GetHashCode()
		{
			return this.GetName().GetHashCode();
		}
		public static List<Client> GetAll()
		{
			List<Client> allClient = new List<Client>();
			MySqlConnection conn = DB.Connection();
			conn.Open();
			
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM client;";
			var rdr = cmd.ExecuteReader() as MySqlDataReader;
			while(rdr.Read())
			{
				int id = rdr.GetInt32(0);
				string name = rdr.GetString(1);
				string email = rdr.GetString(2);
				string phone = rdr.GetString(3);
				int stylistId = rdr.GetInt32(4);
				Client newClient = new Client(name,email,phone,stylistId,id);
				allClient.Add(newClient);
			}
			conn.Close();
			return allClient;
		}
		public void Save()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"INSERT INTO client(name,email,phone,stylistId) VALUES(@name,@email,@phone,@stylistId);";
			
			MySqlParameter name = new MySqlParameter();
			name.ParameterName = "@name";
			name.Value = this._name;
			cmd.Parameters.Add(name);
			
			MySqlParameter email = new MySqlParameter();
			email.ParameterName = "@email";
			email.Value = this._email;
			cmd.Parameters.Add(email);
			
			MySqlParameter phone = new MySqlParameter();
			phone.ParameterName = "@phone";
			phone.Value = this._phone;
			cmd.Parameters.Add(phone);
			
			MySqlParameter stylistId = new MySqlParameter();
			stylistId.ParameterName = "@stylistId";
			stylistId.Value = this._stylistId;
			cmd.Parameters.Add(stylistId);
			
			cmd.ExecuteNonQuery();
			_id = (int) cmd.LastInsertedId;
			conn.Close();
		}
		public void Update()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();
			
			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"UPDATE client SET name=@name,email=@email,phone=@phone,stylistId=@stylistId WHERE id=@id;";
			
			MySqlParameter name = new MySqlParameter();
			name.ParameterName = "@name";
			name.Value = this._name;
			cmd.Parameters.Add(name);
			
			MySqlParameter id = new MySqlParameter();
			id.ParameterName = "@id";
			id.Value = this._id;
			cmd.Parameters.Add(id);
			
			MySqlParameter email = new MySqlParameter();
			email.ParameterName = "@email";
			email.Value = this._email;
			cmd.Parameters.Add(email);
			
			MySqlParameter phone = new MySqlParameter();
			phone.ParameterName = "@phone";
			phone.Value = this._phone;
			cmd.Parameters.Add(phone);
			
			MySqlParameter stylistId = new MySqlParameter();
			stylistId.ParameterName = "@stylistId";
			stylistId.Value = this._stylistId;
			cmd.Parameters.Add(stylistId);
			
			cmd.ExecuteNonQuery();
			_id = (int) cmd.LastInsertedId;
			conn.Close();
		}
		public static Client Find(int id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"SELECT * FROM client WHERE id=@searchId;";

			MySqlParameter searchId = new MySqlParameter();
			searchId.ParameterName = "@searchId";
			searchId.Value = id;
			cmd.Parameters.Add(searchId);

			var rdr = cmd.ExecuteReader() as MySqlDataReader;
			int clientId = 0;
			string name = "";
			string email = "";
			string phone = "";
			int stylistId = 0;

			while (rdr.Read())
			{
				clientId = rdr.GetInt32(0);
				name = rdr.GetString(1);
				email = rdr.GetString(2);
				phone = rdr.GetString(3);
				stylistId = rdr.GetInt32(4);
			}
			Client newClient = new Client(name,email,phone,stylistId,clientId);
			conn.Close();
			return newClient;
		}
		public Stylist GetStylist()
		{
			return Stylist.Find(_stylistId);			
		}
		
		public static void DeleteAll()
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"DELETE FROM client;";
			cmd.ExecuteNonQuery();
			conn.Close();
		}
		public static void Delete(int id)
		{
			MySqlConnection conn = DB.Connection();
			conn.Open();

			var cmd = conn.CreateCommand() as MySqlCommand;
			cmd.CommandText = @"DELETE FROM client WHERE id = (@searchId);";
			MySqlParameter searchId = new MySqlParameter();
			searchId.ParameterName = "@searchId";
			searchId.Value = id;
			cmd.Parameters.Add(searchId);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
	
}