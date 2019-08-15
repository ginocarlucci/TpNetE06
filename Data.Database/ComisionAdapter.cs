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
    class ComisionAdapter : Adapter
    {

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>;

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("Select * FROM comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision cms = new Comision();
                    cms.ID = (int)drComisiones["id_comision"];
                    cms.DescComision = (string)drComisiones["desc_comision"];
                    cms.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    cms.IdPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(cms);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar la lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision cms = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComision = new SqlCommand("Select * FROM comisiones WHERE id_comision = @id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComision = cmdComision.ExecuteReader();
                if (drComision.Read())
                {
                    cms.DescComision = (string)drComision["desc_comision"];
                    cms.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    cms.IdPlan = (int)drComision["id_plan"];
                }
                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar datos de 1 Comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cms;



        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("DELETE FROM comisiones WHERE id_comision = @id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdComisiones.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar Comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("INSERT INTO comisiones(id_comision, desc_comision, anio_especialidad, id_plan)" +
                    "values(@id_comision,@desc_comision,@anio_especialidad,@id_plan)" + "select @@identity", sqlConn);
                cmdComisiones.Parameters.Add("@id_comision", SqlDbType.Int).Value = usuario.ID;
                cmdComisiones.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdComisiones.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdComisiones.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdComisiones.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision," +
                    " anio_especialidad = @anio_especialidad, " + " id_plan = @id_plan," + "WHERE id_comision = @id_comision");
                cmdComisiones.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.ID;
                cmdComisiones.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdComisiones.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdComisiones.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                cmdComisiones.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision c)
        {
            if (c.State == BusinessEntity.States.Delete)
            {
                this.Delete(c.ID);
            }
            else if (c.State == BusinessEntity.States.New)
            {
                this.Insert(c);
            }
            else if (c.State == BusinessEntity.States.Modified)
            {
                this.Update(c);
            }
            c.State = BusinessEntity.States.Unmodified;
        }


    }
}
