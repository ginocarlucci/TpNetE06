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
    public class CursoAdapter:Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos",sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursos["id_curso"];
                    c.IdEspecialidad = (int)drCursos["id_especialidad"];
                    c.IdMateria = (int)drCursos["id_materia"];
                    c.IdComision = (int)drCursos["id_comision"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    c.Cupo = (int)drCursos["cupo"];

                    cursos.Add(c);
                }
                drCursos.Close();

            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }
        public Curso GetOne(int ID)
        {
            Curso c = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @idCurso", sqlConn);
                cmdCursos.Parameters.Add("@idCurso", SqlDbType.Int).Value = ID;

                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    c.ID = (int)drCursos["id_curso"];
                    c.IdEspecialidad = (int)drCursos["id_especialidad"];
                    c.IdMateria = (int)drCursos["id_materia"];
                    c.IdComision = (int)drCursos["id_comision"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    c.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return c;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("DELETE FROM cursos WHERE id_curso = @idCurso", sqlConn);
                cmdCursos.Parameters.Add("@idCurso", SqlDbType.Int).Value = ID;
                cmdCursos.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Curso curso)
        {
            try {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("INSERT INTO cursos(id_materia,id_comision,anio_calendario,cupo)" +
                    "VALUES(@idMateria,@idComision,@anioCalendario,@cupo) select @@identity", sqlConn);
                cmdCursos.Parameters.Add("@idMateria", SqlDbType.Int).Value = curso.IdMateria;
                cmdCursos.Parameters.Add("@idComision", SqlDbType.Int).Value = curso.IdComision;
                cmdCursos.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdCursos.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdCursos.ExecuteScalar());

            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("UPDATE cursos SET id_materia = @idMateria, id_comision = @idComision," +
                    "anio_calendario = @anioCalendario, cupo = @cupo WHERE id_curso = @idCurso",sqlConn);
                cmdCursos.Parameters.Add("@idMateria", SqlDbType.Int).Value = curso.IdMateria;
                cmdCursos.Parameters.Add("@idComision", SqlDbType.Int).Value = curso.IdComision;
                cmdCursos.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdCursos.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdCursos.Parameters.Add("@idCurso", SqlDbType.Int).Value = curso.ID;
                cmdCursos.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Delete)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
