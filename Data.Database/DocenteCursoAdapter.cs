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
                    doc.IdDictado = (int)drDocentesCursos["id_dictado"];
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
        }
    }
}