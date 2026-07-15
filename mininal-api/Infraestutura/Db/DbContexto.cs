using Microsoft.EntityFrameworkCore;
using mininal_api.Dominio.Entidades;

namespace mininal_api.Infraestutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    

    public DbContexto(DbContextOptions<DbContexto> options, IConfiguration configuracaoAppSettings)
        : base(options)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }

    public DbSet<Administrador> Administradores { get; set; } = default;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {

            var stringConxeao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
            if (!string.IsNullOrEmpty(stringConxeao))
            {
                optionsBuilder.UseMySql(stringConxeao,
                    ServerVersion.AutoDetect(stringConxeao));
            }
        }


    }
}