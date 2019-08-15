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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * from planes", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pln = new Plan();
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    planes.Add(pln);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar la lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan pln = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes where id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IdEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar datos de Planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return pln;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("DELETE FROM planes WHERE id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPlanes.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("INSERT INTO planes(id_plan,desc_plan,id_especialidad)" +
                    "values(@id_plan,@desc_plan,@id_especialidad)" + "select @@identity", sqlConn);
                cmdPlanes.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan.ID;
                cmdPlanes.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdPlanes.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdPlanes.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan," +
                    " id_especialidad = @id_especialidad" + "WHERE id_plan = @id_plan");
                cmdPlanes.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan.ID;
                cmdPlanes.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdPlanes.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdPlanes.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Delete)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
