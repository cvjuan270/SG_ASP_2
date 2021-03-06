using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SG_ASP_2.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Medicina> Medicinas { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Atenciones> Atenciones { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Aptitud> Aptituds { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.ExaMedico> ExaMedicoes { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Auditoria> Auditorias { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Interconsulta> Interconsultas { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_2.Models.Admision> Admisions { get; set; }
    }
}