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
    class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInsc = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnosInsc = cmdAlumnosInsc.ExecuteReader();

                while (drAlumnosInsc.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)drAlumnosInsc["id_modulo_usuario"];
                    ai.IdAlumno = (int)drAlumnosInsc["id_alumno"];
                    ai.IdCurso = (int)drAlumnosInsc["id_curso"];
                    ai.Condicion = (String)drAlumnosInsc["condicion"];
                    ai.Nota = (int)drAlumnosInsc["nota"];
                   
                    alumnoInscripciones.Add(ai);
                }
                drAlumnosInsc.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripciones;
        }
        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion = @id", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drAlumnosInsc = cmdAlumnoInsc.ExecuteReader();
                if (drAlumnosInsc.Read())
                {
                    ai.ID = (int)drAlumnosInsc["id_modulo_usuario"];
                    ai.IdAlumno = (int)drAlumnosInsc["id_alumno"];
                    ai.IdCurso = (int)drAlumnosInsc["id_curso"];
                    ai.Condicion = (String)drAlumnosInsc["condicion"];
                    ai.Nota = (int)drAlumnosInsc["nota"];
                }
                drAlumnosInsc.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ai;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("DELETE FROM alumnos_inscripciones WHERE id_inscripcion = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdCursos.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(AlumnoInscripcion ai)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                    "VALUES(@idAlumno,@idCurso,@condicion,@nota) select @@identity", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@idAlumno", SqlDbType.Int).Value = ai.IdAlumno;
                cmdAlumnoInsc.Parameters.Add("@idCurso", SqlDbType.Int).Value = ai.IdCurso;
                cmdAlumnoInsc.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = ai.Condicion;
                cmdAlumnoInsc.Parameters.Add("@nota", SqlDbType.Int).Value = ai.Nota;
                ai.ID = Decimal.ToInt32((decimal)cmdAlumnoInsc.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(AlumnoInscripcion ai)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInsc = new SqlCommand("UPDATE modulos_usuarios SET id_alumno = @idAlumno, " +
                    "id_curso = @idCurso, condicion = @condicion, nota = @nota WHERE id_inscripcion = @id", sqlConn);
                cmdAlumnoInsc.Parameters.Add("@id", SqlDbType.Int).Value = ai.ID;
                cmdAlumnoInsc.Parameters.Add("@idAlumno", SqlDbType.Int).Value = ai.IdAlumno;
                cmdAlumnoInsc.Parameters.Add("@idCurso", SqlDbType.Int).Value = ai.IdCurso;
                cmdAlumnoInsc.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = ai.Condicion;
                cmdAlumnoInsc.Parameters.Add("@nota", SqlDbType.Int).Value = ai.Nota;

                cmdAlumnoInsc.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(AlumnoInscripcion ai)
        {
            if (ai.State == BusinessEntity.States.Delete)
            {
                this.Delete(ai.ID);
            }
            else if (ai.State == BusinessEntity.States.New)
            {
                this.Insert(ai);
            }
            else if (ai.State == BusinessEntity.States.Modified)
            {
                this.Update(ai);
            }
            ai.State = BusinessEntity.States.Unmodified;
        }
    }
}
