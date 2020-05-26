using System;
using System.Collections.Generic;
using System.Text;
using Registro.DAL;
using RegistroPersona.Entidades;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RegistroPersona.BLL
{
    public class PersonaBLL
    {
        public static Personas Persona { get; private set; }

        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Personas.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas persona = new Personas();

            try
            {
                persona = db.Personas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        internal static object Buscar(object p)
        {
            throw new NotImplementedException();
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> lista = new List<Personas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}