using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Infraestrutura.Interfaces;

namespace MinimalApi.Dominio.Servicos
{
    public class AdministradorServico(DbContexto contexto) : IAdministradorServico
    {
        private readonly DbContexto dbContexto = contexto;

        public Administrador? Login(LoginDTO loginDTO)
        {
            var administrador = dbContexto.Administradores
                .Where(a => a.Email == loginDTO.Username && a.Password == loginDTO.Password)
                .ToList();

            return administrador.FirstOrDefault();
        }
    }
}