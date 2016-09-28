using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseProject.Domain.Entities;
using BaseProject.Domain.IRepositories;
using BaseProject.Domain.ValueObject;
using BaseProject.Repositories.Tests.TestData;

namespace BaseProject.Repositories.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly IUserRepository _UserRepository;
        private readonly RepositoryList<User> _repository;

        public UserRepositoryTests()
        {
            _repository = new RepositoryList<User>(UserTestData.Get());
            _UserRepository = new UserRepository(_repository);
        }

        [TestMethod]
        public void UserRepository_CpfJaCadastrado_Ja_Cadastrado_Novo_User()
        {
            var jaCadastrado = _UserRepository.CpfJaCadastrado(new Cpf("356.354.274-05"), 0);
            Assert.IsTrue(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_CpfJaCadastrado_Ja_Cadastrado_Proprio_User()
        {
            var jaCadastrado = _UserRepository.CpfJaCadastrado(new Cpf("356.354.274-05"), 1);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_CpfJaCadastrado_Nao_Cadastrado()
        {
            var jaCadastrado = _UserRepository.CpfJaCadastrado(new Cpf("001.832.936-57"), 0);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_LoginJaCadastrado_Ja_Cadastrado_Novo_User()
        {
            var jaCadastrado = _UserRepository.LoginJaCadastrado("loginTeste1", 0);
            Assert.IsTrue(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_LoginJaCadastrado_Ja_Cadastrado_Proprio_User()
        {
            var jaCadastrado = _UserRepository.LoginJaCadastrado("loginTeste1", 1);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_LoginJaCadastrado_Nao_Cadastrado()
        {
            var jaCadastrado = _UserRepository.LoginJaCadastrado("afsdhbdfbhdfsb", 0);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UserRepository_Salvar_Novo()
        {
            var User = new User("loginTesteSalvar", new Cpf("018.971.571-50"), new Email("emailTesteSalvar@teste.com"),
                "senhaTeste", "senhaTeste", UserTestData.GetEnderecoTest());

            var totalAntesDeSalvar = _repository.Get().Count();
            _UserRepository.Salvar(User);
            var totalDepoisDeSalvar = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalAntesDeSalvar + 1, totalDepoisDeSalvar);
        }

        [TestMethod]
        public void UserRepository_Salvar_JaCadastrado()
        {
            var User = _repository.First();
            var novoEmail = new Email("novoEmail@email.com");
            User.SetEmail(novoEmail);

            var totalAntesDeSalvar = _repository.Get().Count();
            _UserRepository.Salvar(User);
            var totalDepoisDeSalvar = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalAntesDeSalvar, totalDepoisDeSalvar);
            Assert.AreEqual(User.Email, _repository.First().Email);
        }

        [TestMethod]
        public void UserRepository_Get_Id()
        {
            var User = _repository.First();
            Assert.AreEqual(User, _UserRepository.Get(User.Id));
        }

        [TestMethod]
        public void UserRepository_Get_Login()
        {
            var User = _repository.First();
            Assert.AreEqual(User, _UserRepository.Get(User.Login));
        }

        [TestMethod]
        public void UserRepository_Get_Email()
        {
            var User = _repository.First();
            Assert.AreEqual(User, _UserRepository.Get(User.Email));
        }
    }
}
