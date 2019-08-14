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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentesCursos",sqlConn);
                SqlDataReader drDocentesCursos = cmdDocenteCurso.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso doc = new DocenteCurso();
                    doc.Cargo = (int)drDocentesCursos["cargo"];
                    doc.IdCurso = (int)drDocentesCursos["id_curso"];
                    doc.ID = (int)drDocentesCursos["id_dictado"];
                    doc.IdDocente = (int)drDocentesCursos["id_docente"];
                    docentesCursos.Add(doc);
                }
                drDocentesCursos.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los docentescursos",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentesCursos;
        }
        public DocenteCurso GetOne(int idDictado)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado = @id",sqlConn);
                cmdDocentesCursos.Parameters.Add("@id", SqlDbType.Int).Value = idDictado;

                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                if (drDocentesCursos.Read())
                {
                    dc.Cargo = (int)drDocentesCursos["cargo"];
                    dc.IdCurso = (int)drDocentesCursos["id_curso"];
                    dc.IdDocente = (int)drDocentesCursos["id_docente"];
                    dc.ID = (int)drDocentesCursos["id_dictado"];
                }
            }catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un docenteCurso",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }
        public void Delete(int idDictado)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("DELETE FROM docentes_cursos WHERE id_dictado = @id",sqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = idDictado;
                cmdDocenteCurso.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un docenteCurso",Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("INSERT INTO docentes_cursos(id_curso,id_docente,cargo)" +
                    "VALUES(@idCurso,@idDocente,@cargo) select @@identity",sqlConn);
                cmdDocenteCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = dc.IdCurso;
                cmdDocenteCurso.Parameters.Add("@idDocente", SqlDbType.Int).Value = dc.IdDocente;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                dc.ID = Decimal.ToInt32((decimal)cmdDocenteCurso.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ingresar un docenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("UPDATE docentes_cursos SET id_dictado = @idDictado, " +
                    "id_curso = @idCurso,cargo = @cargo WHERE id_dictado = @idDictado", sqlConn);
                cmdDocenteCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = dc.IdCurso;
                cmdDocenteCurso.Parameters.Add("@idDocente", SqlDbType.Int).Value = dc.IdDocente;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdDocenteCurso.Parameters.Add("@idDictado", SqlDbType.Int).Value = dc.ID;
                cmdDocenteCurso.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar un docenteCurso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Delete)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}