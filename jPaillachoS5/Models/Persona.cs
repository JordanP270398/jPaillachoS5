using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jPaillachoS5.Models
{
    [Table ("persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength (25)]
        public string Name { get; set; }
    }
}
