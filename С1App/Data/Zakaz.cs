using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С1App.Data
{
	public class Zakaz
	{
		public int Id {  get; set; }
		public string UserId { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }
		public string State { get; set; }
		public string Items { get; set; }
		public string Colichestvo {  get; set; }
	}
}
