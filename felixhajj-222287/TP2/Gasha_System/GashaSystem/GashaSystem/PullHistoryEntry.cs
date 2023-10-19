using GashaSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GashaSystem
{
	public class PullHistoryEntry
	{
		public GachaItem ItemID { get; set; }
		public ExclusiveBanner Banner { get; set; }
		public DateTime CreationDate { get; set; }
		public int PullNumber { get; set; }

	}
}