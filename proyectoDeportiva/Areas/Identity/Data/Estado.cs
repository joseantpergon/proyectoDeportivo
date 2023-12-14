using Microsoft.AspNetCore.Identity;
using MudBlazor;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoDeportiva.Areas.Identity.Data
{
    public class Estado 
    {
        public string Nombre { get; set; }

        public int Id { get; set; }

    }
}
