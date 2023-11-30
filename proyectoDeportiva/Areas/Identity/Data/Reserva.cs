using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using proyectoDeportiva.Data;

namespace proyectoDeportiva.Areas.Identity.Data
{
	public class Reserva
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime FechaReserva { get; set; }
		public DateTime DiaReserva { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFin { get; set; }

		[ForeignKey("IdUsuario")]
		public User Usuario { get; set; }

		[ForeignKey("IdPista")]
		public Pista Pista { get; set; }

	}

    
}
