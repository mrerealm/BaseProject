using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BaseProject.Domain.Entities;
using BaseProject.Domain.Enuns;
using BaseProject.Domain.IRepositories;
using BaseProject.Domain.ValueObject;

namespace BaseProject.App.Tests
{
    [TestClass]
    public class UserAppTest
    {
        private readonly Mock<IUserRepository> _UserRepository;
        private readonly User _User;
        public UserAppTest()
        {
            var endereco = new Endereco("rua teste", "complemento teste", "numero teste", "bairro teste", "cidade teste", Uf.SP, new Cep("06400-000"));
            _User = new User("loginTeste1", new Cpf("356.354.274-05"), new Email("emailTeste1@teste.com"), "senhaTeste",
                "senhaTeste", endereco);
            _UserRepository = new Mock<IUserRepository>();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserApp_Salvar_CPF_JaCadastrado()
        {
            _UserRepository.Setup(x => x.CpfJaCadastrado(_User.Cpf, _User.Id)).Returns(true);
            var app = new UserApp(_UserRepository.Object);
            app.Salvar(_User);
            _UserRepository.Verify(x => x.Salvar(_User), Times.Never);
        }

        [TestMethod]
        public void UserApp_Salvar_CPF_Novo()
        {
            _UserRepository.Setup(x => x.CpfJaCadastrado(_User.Cpf, _User.Id)).Returns(false);
            var app = new UserApp(_UserRepository.Object);
            app.Salvar(_User);
            _UserRepository.Verify(x=>x.Salvar(_User),Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserApp_Salvar_Login_JaCadastrado()
        {
            _UserRepository.Setup(x => x.LoginJaCadastrado(_User.Login, _User.Id)).Returns(true);
            var app = new UserApp(_UserRepository.Object);
            app.Salvar(_User);
            _UserRepository.Verify(x => x.Salvar(_User), Times.Never);
        }

        [TestMethod]
        public void UserApp_Salvar_Login_Novo()
        {
            _UserRepository.Setup(x => x.LoginJaCadastrado(_User.Login, _User.Id)).Returns(false);
            var app = new UserApp(_UserRepository.Object);
            app.Salvar(_User);
            _UserRepository.Verify(x => x.Salvar(_User), Times.Once);
        }
    }
}
