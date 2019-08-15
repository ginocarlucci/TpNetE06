using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * from materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mtr = new Materia();
                    mtr.ID = (int)drMaterias["id_materia"];
                    mtr.DescMateria = (string)drMaterias["desc_materia"];
                    mtr.HsSemanales = (int)drMaterias["hs_semanales"];
                    mtr.HsTotales = (int)drMaterias["hs_totales"];
                    mtr.IdPlan = (int)drMaterias["id_plan"];
                    materias.Add(mtr);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mtr = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias where id_materia = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mtr.ID = (int)drMaterias["id_materia"];
                    mtr.DescMateria = (string)drMaterias["desc_materia"];
                    mtr.HsSemanales = (int)drMaterias["hs_semanales"];
                    mtr.HsTotales = (int)drMaterias["hs_totales"];
                    mtr.IdPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Excepcion al recuperar datos de Materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mtr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("DELETE FROM materias WHERE id_materia = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdMaterias.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("INSERT INTO materias(id_materia,desc_materia,hs_semanales,hs_totales,id_plan)" +
                    "values(@id_materia,@desc_materia,@hs_semanales,@hs_totales,@id_plan)" + "select @@identity", sqlConn);
                cmdMaterias.Parameters.Add("@id_materia", SqlDbType.Int).Value = materia.ID;
                cmdMaterias.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdMaterias.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdMaterias.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdMaterias.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia," +
                    " hs_semanales = @hs_semanales, " + " hs_totales = @hs_totales," + "id_plan = @id_plan" + "WHERE id_materia = @id_materia");
                cmdMaterias.Parameters.Add("@id_materia", SqlDbType.Int).Value = materia.ID;
                cmdMaterias.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdMaterias.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdMaterias.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                cmdMaterias.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia m)
        {
            if (m.State == BusinessEntity.States.Delete)
            {
                this.Delete(m.ID);
            }
            else if (m.State == BusinessEntity.States.New)
            {
                this.Insert(m);
            }
            else if (m.State == BusinessEntity.States.Modified)
            {
                this.Update(m);
            }
            m.State = BusinessEntity.States.Unmodified;
        }
    }
}
