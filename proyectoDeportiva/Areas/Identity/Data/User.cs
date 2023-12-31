﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace proyectoDeportiva.Areas.Identity.Data
{
    [Table("user")]
	public class User : IdentityUser
	{
		public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string DNI { get; set; }
		public string Rol {  get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }

	//public enum UserRole
	//{
	//	USER,
	//	ADMIN
	//}


}
