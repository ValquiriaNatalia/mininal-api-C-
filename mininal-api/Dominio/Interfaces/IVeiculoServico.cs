using mininal_api.Dominio.Entidades;
using mininal_api.Dto;

namespace mininal_api.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int pagina = 1, string ? nome = null, string ? marca = null);
    
    Veiculo? BucarPorId(int id);
    
    void Incluir (Veiculo veiculo);
    
    void Atualizar(Veiculo veiculo);
    
    void Apagar(Veiculo veiculo);



} 