using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoDeportiva.Areas.Identity.Data
{
	public class Pista
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Estado{ get; set; }
		public string TipoDeporte { get; set; }
		public TimeSpan HorarioApertura { get; set; }
		public TimeSpan HorarioCierre { get; set; }
		public int? CapacidadMaxima { get; set; }
	}

	//public enum TipoDeporte
	//{
	//	TENIS,
	//	PADEL
	//}

	//public enum EstadoPista
	//{
	//	DISPONIBLE,
	//	OCUPADA
	//}
}