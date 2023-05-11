using Newtonsoft.Json;

namespace INSY_API.Data
{
	public class Employee
	{
		#region variables
		private int _employeeId;
		private string _lastName;
		private string _firstName;
		private string _title;
		private string _titleOfCourtesy;
		private DateTime _birthday;
		private DateTime _hireDate;
		private string _address;
		private string _city;
		private string _region;
		private int _postalCode;
		private string _country;
		private string _homePhone;
		private int _extension;
		private string _photo;
		private string _notes;
		private int _reportsTo;
		private string _photoPath;
		#endregion

		#region Constructor
		public Employee(int employeeId = -1, string lastName = null, string firstName = null, string title = null, string titleOfCourtesy = null, DateTime birthday = new DateTime(), DateTime hireDate = new DateTime(), string address = null, string city = null, string region = null, int postalCode = -1, string country = null, string homePhone = null, int extension = -1, string photo = null, string notes = null, int reportsTo = -1, string photoPath = null)
		{
			_employeeId = employeeId;
			_lastName = lastName;
			_firstName = firstName;
			_title = title;
			_titleOfCourtesy = titleOfCourtesy;
			_birthday = birthday;
			_hireDate = hireDate;
			_address = address;
			_city = city;
			_region = region;
			_postalCode = postalCode;
			_country = country;
			_homePhone = homePhone;
			_extension = extension;
			_photo = photo;
			_notes = notes;
			_reportsTo = reportsTo;
			_photoPath = photoPath;
		}
		#endregion

		public int EmployeeId { get { return _employeeId; } set { _employeeId = value; } }
		public string LastName { get { return _lastName; } set { _lastName = value; } }
		public string FirstName { get { return _firstName; } set { _firstName = value; } }
		public string Title { get { return _title; } set { _title = value; } }
		public string TitleOfCourtesy { get { return _titleOfCourtesy; }  }
	}
}
