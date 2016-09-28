using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseProject.Domain.Entities;
using BaseProject.Domain.Enuns;
using BaseProject.Domain.ValueObject;

namespace BaseProject.Domain.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        private Cpf Cpf { get; set; }
        private Email Email { get; set; }
        private string Login { get; set; }

        private string Senha { get; set; }
        private string SenhaConfirmacao { get; set; }
        private User User { get; set; }

        private Endereco Endereco { get; set; }

        public UserTests()
        {
            Cpf = new Cpf("40914294830");
            Email = new Email("email@gmail.com");
            Login = "adminteste";
            Senha = "123456";
            SenhaConfirmacao = "123456";
            Endereco = new Endereco("rua teste", "complemento teste", "numero teste", "bairro teste", "cidade teste",
                Uf.SP, new Cep("06400-000")); 
            User = new User(Login, Cpf, Email, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_Cpf_Obrigatorio()
        {
            new User(Login, null, Email, Senha, SenhaConfirmacao, Endereco);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_Login_Obrigatorio()
        {
            new User("", Cpf, Email, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_Email_Obrigatorio()
        {
            new User(Login, Cpf, null, Senha, SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_Senha_Obrigatorio()
        {
            new User(Login, Cpf, Email, "", SenhaConfirmacao, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_SenhaConfirmacao_Obrigatorio()
        {
            new User(Login, Cpf, Email, Senha, "", Endereco);
        }

        [TestMethod]
        public void User_New_Cpf()
        {
            Assert.AreEqual(Cpf, User.Cpf);
        }

        [TestMethod]
        public void User_New_Login()
        {
            Assert.AreEqual(Login, User.Login);
        }

        [TestMethod]
        public void User_New_Email()
        {
            Assert.AreEqual(Email, User.Email);
        }

        [TestMethod]
        public void User_New_Senha()
        {
            Assert.IsNotNull(User.Senha);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_SetLogin_Min_Value()
        {
            User.SetLogin("12345");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_SetLogin_Max_Value()
        {
            User.SetLogin("1234567890123456789012345678901");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_SetSenha_Min_Value()
        {
            var senha = "12345";
            new User(Login, Cpf, Email, senha, senha, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_SetSenha_Max_Value()
        {
            var senha = "1234567890123456789012345678901";
            new User(Login, Cpf, Email, senha, senha, Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_SetSenha_Senhas_Nao_Conferem()
        {
            new User(Login, Cpf, Email, "testeteste", "blablablabla", Endereco);
        }
    }
}
