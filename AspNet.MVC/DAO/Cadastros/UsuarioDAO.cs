using AspNet.MVC.DAO.Comum;
using AspNet.MVC.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AspNet.MVC.DAO.Cadastros
{
    public class UsuarioDAO
    {
        private readonly SqlCommand command = new SqlCommand();
        private readonly DataTable dataTable = new DataTable();
        private readonly Conexao conexao = new Conexao();

        public void CriarUsuario(Usuario usuario)
        {
            try
            {
                command.Connection = conexao.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_USUARIOS";
                command.Parameters.AddWithValue("@OPT", "CriarUsuario");
                command.Parameters.AddWithValue("@NOME", usuario.Nome);
                command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                command.Parameters.AddWithValue("@ATIVO", usuario.Ativo);

                conexao.Conectar();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public List<Usuario> ObterTodosUsuarios()
        {
            try
            {
                command.Connection = conexao.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_USUARIOS";
                command.Parameters.AddWithValue("@OPT", "ObterTodosUsuarios");

                conexao.Conectar();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                var usuarios = (from row in dataTable.AsEnumerable()
                                select new Usuario()
                                {
                                    Id = Convert.ToInt32(row["Id"]),
                                    Nome = row["Nome"].ToString(),
                                    Email = row["Email"].ToString(),
                                    Ativo = Convert.ToBoolean(row["Ativo"]),
                                    DataCadastro = Convert.ToDateTime(row["DataCadastro"])
                                }).ToList();

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            try
            {
                command.Connection = conexao.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_USUARIOS";
                command.Parameters.AddWithValue("@OPT", "ObterUsuarioPorId");
                command.Parameters.AddWithValue("@ID", id);

                conexao.Conectar();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                var usuario = new Usuario
                {
                    Id = Convert.ToInt32(dataTable.Rows[0]["Id"]),
                    Nome = dataTable.Rows[0]["Nome"].ToString(),
                    Email = dataTable.Rows[0]["Email"].ToString(),
                    Ativo = Convert.ToBoolean(dataTable.Rows[0]["Ativo"]),
                    DataCadastro = Convert.ToDateTime(dataTable.Rows[0]["DataCadastro"])
                };

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            try
            {
                command.Connection = conexao.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_USUARIOS";
                command.Parameters.AddWithValue("@OPT", "EditarUsuario");
                command.Parameters.AddWithValue("@ID", usuario.Id);
                command.Parameters.AddWithValue("@NOME", usuario.Nome);
                command.Parameters.AddWithValue("@EMAIL", usuario.Email);
                command.Parameters.AddWithValue("@ATIVO", usuario.Ativo);

                conexao.Conectar();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            try
            {
                command.Connection = conexao.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_USUARIOS";
                command.Parameters.AddWithValue("@OPT", "ExcluirUsuario");
                command.Parameters.AddWithValue("@ID", usuario.Id);

                conexao.Conectar();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}