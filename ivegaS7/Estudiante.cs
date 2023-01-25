﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ivegaS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Usuario { get; set; }
        [MaxLength(50)]
        public string Contrasena { get; set; }
    }
}