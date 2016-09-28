using BaseProject.Domain.Entities;
using BaseProject.Domain.ValueObject;

namespace BaseProject.Domain.IApp
{
    public interface IUserApp
    {
        User Get(string login);
        User Get(Email email);
        User Get(int id);
        void Salvar(User User);
    }
}
