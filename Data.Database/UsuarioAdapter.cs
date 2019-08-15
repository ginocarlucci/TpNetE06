using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    class UsuarioAdapter : Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * FROM usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.ClaveUsuario = (string)drUsuarios["clave_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.CambiaClave = (bool)drUsuarios["cambia_clave"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar la lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("Select * FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
                    if (drUsuario.Read())
                {
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.ClaveUsuario = (string)drUsuario["clave_usuario"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.CambiaClave = (bool)drUsuario["cambia_clave"];
                    usr.IdPersona = (int)drUsuario["id_persona"];
                }
                drUsuario.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar datos de 1 usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("DELETE FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdUsuarios.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("INSERT INTO usuarios(id_usuario, nombre_usuario, clave_usuario, habiliado, cambia_clave, id_persona)" +
                    "values(@id_usuario,@nombre_Usuario,@clave_usuario,@habilitado,@cambia_clave,@id_persona)" + "select @@identity", sqlConn);
                cmdUsuarios.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.ID;
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdUsuarios.Parameters.Add("@clave_usuario", SqlDbType.VarChar).Value = usuario.ClaveUsuario;
                cmdUsuarios.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUsuarios.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                cmdUsuarios.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdUsuarios.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario," +
                    " clave_usuario = @clave_usuario, " + " habilitado = @habilitado," + "cambia_clave = @cambia_clave, " + " id_persona = @id_persona" + "WHERE id_usuario = @id_usuario");
                cmdUsuarios.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.ID;
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdUsuarios.Parameters.Add("@clave_usuario", SqlDbType.VarChar).Value = usuario.ClaveUsuario;
                cmdUsuarios.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUsuarios.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                cmdUsuarios.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                cmdUsuarios.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario u)
        {
            if (u.State == BusinessEntity.States.Delete)
            {
                this.Delete(u.ID);
            }
            else if (u.State == BusinessEntity.States.New)
            {
                this.Insert(u);
            }
            else if (u.State == BusinessEntity.States.Modified)
            {
                this.Update(u);
            }
            u.State = BusinessEntity.States.Unmodified;
        }

    }
}
