using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GashaSystem
{
	public abstract class BaseUser : IAccount
	{
		public Status UserStatus;

		public abstract void validate();
		public int id
		{
			get => default;
			set
			{
			}
		}

		public string FirstName
		{
			get => default;
			set
			{
			}
		}

		public string LastName
		{
			get => default;
			set
			{
			}
		}
		public DateTime DateOfBirth { get; set; }

		public int GetAge
		{
			get => default;
			set
			{
			}
		}

		public string GetFullName
		{
			get => default;
			set
			{
			}
		}
	}
}