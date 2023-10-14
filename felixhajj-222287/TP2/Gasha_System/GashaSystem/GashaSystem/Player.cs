using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GashaSystem
{
	public class Player : BaseUser
	{
		public override void validate()
		{



		}
		private History history;
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public int Balance { get; set; }
		public int Pulls { get; set; }

		public void PerformPull() { }
		public void TrackPullHistory() {}
		public void TrackPityCounter()  {}

	}
}