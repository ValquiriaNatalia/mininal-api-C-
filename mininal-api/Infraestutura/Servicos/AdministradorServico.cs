using Microsoft.EntityFrameworkCore;
using mininal_api.Dominio.Entidades;
using mininal_api.Dominio.Interfaces;
using mininal_api.Dto;
using mininal_api.Infraestutura.Db;

namespace mininal_api.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico

{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
        
    }
    public Administrador? Login(LoginDto loginDto)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDto.Email && a.Senha == loginDto.Senha).FirstOrDefault();
        return adm;
    }
}