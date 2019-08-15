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
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("SELECT * FROM modulos", sqlConn);
                SqlDataReader drModulo = cmdModulo.ExecuteReader();

                while (drModulo.Read())
                {
                    Modulo mu = new Modulo();
                    mu.ID = (int)drModulo["id_modulo"];
                    mu.Descripcion = (String)drModulo["desc_modulo"];
                    mu.Ejecuta = (String)drModulo["ejecuta"];

                    modulos.Add(mu);
                }
                drModulo.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }
        public Modulo GetOne(int ID)
        {
            Modulo mu = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("SELECT * FROM modulos WHERE id_modulo = @id", sqlConn);
                cmdModulo.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drModulo = cmdModulo.ExecuteReader();
                if (drModulo.Read())
                {
                    mu.ID = (int)drModulo["id_modulo_usuario"];
                    mu.Descripcion = (String)drModulo["desc_modulo"];
                    mu.Ejecuta = (String)drModulo["ejecuta"];
                }
                drModulo.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un modulo", Ex);
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
                SqlCommand cmdCursos = new SqlCommand("DELETE FROM modulos WHERE id_modulo = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdCursos.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Modulo mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("INSERT INTO modulos(desc_modulo,ejecuta)" +
                    " VALUES(@desc_modulo,@ejecuta) select @@identity", sqlConn);
                cmdModulo.Parameters.Add("@desc_modulo", SqlDbType.VarChar,50).Value = mu.Descripcion;
                cmdModulo.Parameters.Add("@ejecuta", SqlDbType.VarChar,50).Value = mu.Ejecuta;
                mu.ID = Decimal.ToInt32((decimal)cmdModulo.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Modulo mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("UPDATE modulos SET desc_modulo = @desc_modulo, " +
                    "ejecuta = @ejecuta WHERE id_modulo = @id_modulo", sqlConn);
                cmdModulo.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = mu.Descripcion;
                cmdModulo.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = mu.Ejecuta;
                cmdModulo.Parameters.Add("@id_modulo", SqlDbType.Int).Value = mu.ID;
                cmdModulo.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar Modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Modulo mu)
        {
            if (mu.State == BusinessEntity.States.Delete)
            {
                this.Delete(mu.ID);
            }
            else if (mu.State == BusinessEntity.States.New)
            {
                this.Insert(mu);
            }
            else if (mu.State == BusinessEntity.States.Modified)
            {
                this.Update(mu);
            }
            mu.State = BusinessEntity.States.Unmodified;
        }
    }
}
