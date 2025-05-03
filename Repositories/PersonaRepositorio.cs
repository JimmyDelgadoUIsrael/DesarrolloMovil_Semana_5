using jdelgadoS5A.Models;
using SQLite;

namespace jdelgadoS5A.Repositories
{
    public class PersonaRepositorio
    {
        string dbPath;
        private SQLiteConnection conn;

        public string statusMessage { get; set; }



        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonaRepositorio(string path)
        {
            dbPath = path;

        }

        public void AddPersona(String nombre)
        {
            int result = 0;

            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Persona no puede ser nulo");

                Persona person = new() { Nombre = nombre };
                result = conn.Insert(person);
                statusMessage = string.Format("Dato Ingresado: {0} (Nombre:{1})", result, nombre);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al Ingresar: {0} (Nombre:{1})", nombre, ex.Message);
            }

        }

        public List<Persona> GetPersonas()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error" + ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePersona(int id)
        {
            try
            {
                Init();
                conn.Delete<Persona>(id);
                statusMessage = "Persona eliminada";
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error" + ex.Message);
            }
        }

        public void UpdatePersona(Persona persona)
        {
            try
            {
                Init();
                conn.Update(persona);
                statusMessage = "Persona actualizada";
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error" + ex.Message);
            }
        }

        public Persona GetPersona(int id)
        {
            try
            {
                Init();
                return conn.Get<Persona>(id);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error" + ex.Message);
            }
            return new Persona();
        }
        //En el archivo MauiProgram.cs, se agrega el siguiente código para registrar el repositorio en el contenedor de servicios de la aplicación:
        // string dbPath = FileAccesHelper.GetLocalFilePath("personas.db");
        //builder.Services.AddSingleton<Repositories.PersonaRepositorio>
        //(s => ActivatorUtilities.CreateInstance<Repositories.PersonaRepositorio>(s, dbPath));

    }
}
