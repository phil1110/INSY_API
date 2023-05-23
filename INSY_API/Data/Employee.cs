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
		
		public string TitleOfCourtesy { get { return _titleOfCourtesy; } set { _titleOfCourtesy = value; } }
		
		public DateTime BirthDay { get { return _birthday; } set { _birthday = value; } }
		
		public DateTime HireDate { get { return _hireDate; } set { _hireDate = value; } }
		
		public string Address { get { return _address; } set { _address = value; } }
		
		public string City { get { return _city;} set { _city = value; } }
		
		public string Region { get { return _region;} set { _region = value; } }
		
		public int PostalCode { get { return _postalCode; } set { _postalCode = value; } }
		
		public string Country { get { return _country; } set { _country = value; } }
		
		public string HomePhone { get { return _homePhone; } set { _homePhone = value; } }
		
		public int Extension { get { return _extension; } set { _extension = value; } }
		
		public string Photo { get { return _photo; } set { _photo = value; } }
		
		public string Notes { get { return _notes; } set { _notes = value; } }
		
		public int ReportsTo { get { return _reportsTo; } set { _reportsTo = value; } }
		
		public string PhotoPath { get { return _photoPath; } set { _photoPath = value;	} }
	}
}
