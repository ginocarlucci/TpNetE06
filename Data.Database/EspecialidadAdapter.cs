using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                //abrimos conexion
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades", sqlConn);

                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();

                while (drEspecialidad.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Desc_especialidad = (string)drEspecialidad["desc_especialidad"];

                    especialidades.Add(esp);
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }
        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", sqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
                if (drEspecialidad.Read())
                {
                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Desc_especialidad = (string)drEspecialidad["desc_especialidad"];
                }
                drEspecialidad.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("DELETE FROM especialidades WHERE id_especialidad = @id", sqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdEspecialidad.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidad = 
                    new SqlCommand("INSERT INTO especialidades(desc_especialidad)VALUES(@desc_especialiad) select @@identity",sqlConn);
                cmdEspecialidad.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Desc_especialidad;
                esp.ID = Decimal.ToInt32((decimal)cmdEspecialidad.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidad = 
                    new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE id_especialidad = @id_especialidad");
                cmdEspecialidad.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.Desc_especialidad;
                cmdEspecialidad.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = esp.ID;
                cmdEspecialidad.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
