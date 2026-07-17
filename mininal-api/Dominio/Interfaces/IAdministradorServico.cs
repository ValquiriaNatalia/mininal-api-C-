using mininal_api.Dominio.Entidades;
using mininal_api.Dto;

namespace mininal_api.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDto loginDto);
 

}