using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
namespace Data.Database
{
    class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> moduloUsuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuarios = new SqlCommand("SELECT * FROM modulos_usuarios", sqlConn);
                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                while (drModuloUsuarios.Read())
                {
                    ModuloUsuario mu = new ModuloUsuario();
                    mu.ID = (int)drModuloUsuarios["id_modulo_usuario"];
                    mu.IdModulo = (int)drModuloUsuarios["id_modulo"];
                    mu.IdUsuario = (int)drModuloUsuarios["id_usuario"];
                    mu.Alta = (bool)drModuloUsuarios["alta"];
                    mu.Baja = (bool)drModuloUsuarios["baja"];
                    mu.Modificacion = (bool)drModuloUsuarios["modificacion"];
                    mu.Consulta = (bool)drModuloUsuarios["consulta"];

                    moduloUsuarios.Add(mu);
                }
                drModuloUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return moduloUsuarios;
        }
        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario mu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuario = new SqlCommand("SELECT * FROM modulos_usuarios WHERE id_modulo_usuario = @id", sqlConn);
                cmdModuloUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drModuloUsuario = cmdModuloUsuario.ExecuteReader();
                if (drModuloUsuario.Read())
                {
                    mu.ID = (int)drModuloUsuario["id_modulo_usuario"];
                    mu.IdModulo = (int)drModuloUsuario["id_modulo"];
                    mu.IdUsuario = (int)drModuloUsuario["id_usuario"];
                    mu.Alta = (bool)drModuloUsuario["alta"];
                    mu.Baja = (bool)drModuloUsuario["baja"];
                    mu.Modificacion = (bool)drModuloUsuario["modificacion"];
                    mu.Consulta = (bool)drModuloUsuario["consulta"];
                }
                drModuloUsuario.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un modulo_usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mu;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("DELETE FROM modulos_usuarios WHERE id_modulo_usuario = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdCursos.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar modulo_usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuario = new SqlCommand("INSERT INTO modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion" +
                    ",consulta) VALUES(@idModulo,@idUsuario,@alta,@baja,@modificacion,@consulta) select @@identity", sqlConn);
                cmdModuloUsuario.Parameters.Add("@idModulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdModuloUsuario.Parameters.Add("@idUsuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdModuloUsuario.Parameters.Add("@alta", SqlDbType.Bit).Value = mu.Alta;
                cmdModuloUsuario.Parameters.Add("@baja", SqlDbType.Bit).Value = mu.Baja;
                cmdModuloUsuario.Parameters.Add("@modificacion", SqlDbType.Bit).Value = mu.Modificacion;
                cmdModuloUsuario.Parameters.Add("@consulta", SqlDbType.Bit).Value = mu.Consulta;
                mu.ID = Decimal.ToInt32((decimal)cmdModuloUsuario.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar ModuloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuario = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @idModulo, " +
                    "id_usuario = @idUsuario, alta = @alta, baja = @baja, modificaicon = @modificacion," +
                    "consulta = @consulta WHERE id_modulo_usuario = @idModuloUsuario", sqlConn);
                cmdModuloUsuario.Parameters.Add("@idModulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdModuloUsuario.Parameters.Add("@idUsuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdModuloUsuario.Parameters.Add("@idModuloUsuario", SqlDbType.Int).Value = mu.ID;
                cmdModuloUsuario.Parameters.Add("@alta", SqlDbType.Bit).Value = mu.Alta;
                cmdModuloUsuario.Parameters.Add("@baja", SqlDbType.Bit).Value = mu.Baja;
                cmdModuloUsuario.Parameters.Add("@modificacion", SqlDbType.Bit).Value = mu.Modificacion;
                cmdModuloUsuario.Parameters.Add("@consulta", SqlDbType.Bit).Value = mu.Consulta;
                cmdModuloUsuario.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar ModuloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
