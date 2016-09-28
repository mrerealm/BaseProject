using System;
using BaseProject.Domain.Entities;
using BaseProject.Domain.IApp;
using BaseProject.Domain.IRepositories;
using BaseProject.Domain.ValueObject;

namespace BaseProject.App
{
    public class UserApp : IUserApp
    {
        private readonly IUserRepository _UserRepository;

        public UserApp(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public User Get(string login)
        {
            return _UserRepository.Get(login);
        }

        public User Get(Email email)
        {
            return _UserRepository.Get(email);
        }

        public User Get(int id)
        {
            return _UserRepository.Get(id);
        }

        public void Salvar(User User)
        {
            if(_UserRepository.CpfJaCadastrado(User.Cpf,User.Id))
                throw new Exception("CPF já cadastrado para outro usuário!");

            if (_UserRepository.LoginJaCadastrado(User.Login, User.Id))
                throw new Exception("Login já cadastrado para outro usuário!!");

            _UserRepository.Salvar(User);
        }
    }
}
