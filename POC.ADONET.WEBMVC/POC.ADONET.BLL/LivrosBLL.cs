using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using POC.ADONET.DAL;


namespace POC.ADONET.BLL
{
    public class LivrosBLL
    {
        // vamos criar uma variavel do tipo DAL
        LivrosDAL livrosDAL;

        public List<LivroMOD> BuscarTodosLivros()
        {
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                // retorna o resultado do metodo
                // que já definimos que é uma lista
                return livrosDAL.GetBooks();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LivroMOD BuscarLivroPorId(string id)
        {
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                // retorna o livro filtrando por Id
                return livrosDAL.GetBooksById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SalvarLivro(LivroMOD livro)
        {
            // variavel de controle de retorno
            bool resultado = false;

            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                // vamos validar os campos recebidos 
                if (ValidarInfoLivro(livro))
                {
                    // se o metodo ValidarInfoLivro retornar TRUE entao inserimos no Banco Dados
                    resultado = livrosDAL.UpdateBook(livro);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public bool ExcluirLivro(string id)
        {
            // variavel de controle de retorno
            bool resultado = false;

            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                // se o metodo ValidarInfoLivro retornar TRUE entao inserimos no Banco Dados
                resultado = livrosDAL.DeleteBookById(id);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        private bool ValidarInfoLivro(LivroMOD livro)
        {
            if (string.IsNullOrEmpty(livro.Titulo))
            {
                throw new Exception("O título deve ser preenchido");
            }
            else if (string.IsNullOrEmpty(livro.Tipo))
            {
                throw new Exception("O tipo do livro deve ser informado");
            }
            else if(livro.Preco < 0 || livro.Preco == null)
            {
                throw new Exception("O Preço do livro deve ser informado e não deve ser negativo");
            }
            else if (string.IsNullOrEmpty(livro.Resenha) || livro.Resenha.Length > 200)
            {
                throw new Exception("O texto referente a resenha deve ser informado e ser no máximo 200 caracteres");
            }

            // se passou por todas as verificações acima, retornamos TRUE
            return true;

        }
    }
}
