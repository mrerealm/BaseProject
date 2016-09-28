using BaseProject.Domain.Entities;
using BaseProject.Domain.ValueObject;

namespace BaseProject.Domain.IRepositories
{
    public interface IUserRepository
    {
        bool CpfJaCadastrado(Cpf cpf, int UserId);
        bool LoginJaCadastrado(string login, int UserId);
        User Get(string login);
        User Get(Email email);
        User Get(int id);
        void Salvar(User User);
    }
}