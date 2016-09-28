using System.Linq;
using BaseProject.Domain.Entities;
using BaseProject.Domain.IRepositories;
using BaseProject.Domain.ValueObject;

namespace BaseProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _UserRepository;

        public UserRepository(IRepository<User> UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public bool CpfJaCadastrado(Cpf cpf, int UserId)
        {
            return _UserRepository.Get().Any(x => x.Cpf.Codigo == cpf.Codigo
                                           && x.Id != UserId);
        }

        public bool LoginJaCadastrado(string login, int UserId)
        {
            return _UserRepository.Get().Any(x => x.Login == login
                                           && x.Id != UserId);
        }

        public void Salvar(User User)
        {
            _UserRepository.AddOrUpdate(User);
            _UserRepository.Commit();
        }

        public User Get(int id)
        {
            return _UserRepository.Get(id);
        }

        public User Get(string login)
        {
            return _UserRepository.Get()
                .FirstOrDefault(x => x.Login == login);
        }
        
        public User Get(Email email)
        {
            return _UserRepository.Get()
                .FirstOrDefault(x => x.Email.Endereco == email.Endereco);
        }
    }
}