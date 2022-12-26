using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programare_medic_final.Models
{
    public class Programare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [SQLite.MaxLength(250), Unique]

        //Description: descrierea problemei pacientului
        public string Description { get; set; }

        //????????????????????
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
