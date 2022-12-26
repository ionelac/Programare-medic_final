using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Programare_medic_final.Models
{
    public class ListServiciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Programare))]
        public int ProgramareID { get; set; }
        public int ServiciuID { get; set; }
    }
}
