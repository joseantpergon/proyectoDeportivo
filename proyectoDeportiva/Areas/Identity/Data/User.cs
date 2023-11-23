using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace proyectoDeportiva.Areas.Identity.Data
{
    [Table("user")]
    public class User : IdentityUser
	{

    }

}
