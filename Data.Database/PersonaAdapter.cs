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
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.Nombre = (String)drPersonas["nombre"];
                    persona.Apellido = (String)drPersonas["apellido"];
                    persona.Direccion = (String)drPersonas["direccion"];
                    persona.Email = (String)drPersonas["email"];
                    persona.Telefono = (String)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IdPlan = (int)drPersonas["id_plan"];

                    personas.Add(persona);
                }
                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener los personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }
        public Persona GetOne(int ID)
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    
                    persona.Nombre = (String)drPersonas["nombre"];
                    persona.Apellido = (String)drPersonas["apellido"];
                    persona.Direccion = (String)drPersonas["direccion"];
                    persona.Email = (String)drPersonas["email"];
                    persona.Telefono = (String)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IdPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener un persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("DELETE FROM personas WHERE id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al borrar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("INSERT INTO personas(nombre,apellido,direccion,email,telefono," +
                    "fecha_nac,legajo,tipo_persona,id_plan) " +
                    "VALUES(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan) " +
                    "select @@identity", sqlConn);
                cmdPersonas.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdPersonas.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdPersonas.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdPersonas.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdPersonas.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdPersonas.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdPersonas.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdPersonas.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("UPDATE personas SET nombre = @nombre,apellido=@apellido," +
                    "direccion=@direccion,email=@email,telefono=@telefono,fecha_nac=@fecha_nac,legajo=@legajo," +
                    "tipo_persona=@tipo_persona,id_plan=@id_plan WHERE id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdPersonas.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdPersonas.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdPersonas.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdPersonas.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdPersonas.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdPersonas.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdPersonas.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Delete)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
