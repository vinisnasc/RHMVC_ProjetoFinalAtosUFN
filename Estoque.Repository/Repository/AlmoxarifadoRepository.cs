using Estoque.Domain;
using Estoque.Domain.Interfaces.Repository;
using System.Data.SqlClient;

namespace Estoque.Data.Repository
{
    public class AlmoxarifadoRepository : BaseRepository<Almoxarifado>, IAlmoxarifadoRepository
    {
        public override string TableName { get; set; } = "Almoxarifados";

        public async Task<int> QuantidadeProduto(Guid produtoId)
        {
            Almoxarifado produto = await SelecionarPorId(produtoId);
            return produto.Quantidade;
        }

        public override async Task<Almoxarifado> Alterar(Almoxarifado entity)
        {
            try
            {
                var cn = await AbrirConexaoAsync();
                SqlCommand command = new($"update {TableName} set Nome = '{entity.Nome}', Valor = '{entity.Valor}', MinimoEmEstoque = '{entity.MinimoEmEstoque}', MaximoEmEstoque = '{entity.MaximoEmEstoque}' where Id like '{entity.Id}'", cn);
                await command.ExecuteNonQueryAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            finally
            {
                await FecharConexaoAsync();
            }
        }

        public bool RetiradaAlmoxarifado(RetiradaAlmoxarifado entity)
        {

            return false;
        }
    }
}
