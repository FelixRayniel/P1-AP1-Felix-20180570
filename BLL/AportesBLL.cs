using Microsoft.EntityFrameworkCore;
using P1_AP1_Felix_20180570.DAL;
using P1_AP1_Felix_20180570.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Felix_20180570.BLL
{
   public class AportesBLL
    {
        
        //Este metodo guarda un elemento a la base de datos.
        public static bool Guardar(Aportes aporte)
        {
            if (!ExisteID(aporte.AporteID))
            {
                return Insertar(aporte);
            }
            else
            {
                return Modificar(aporte);
            }
        }

        //Este metodo guarda un elemento a la base de datos.
        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aportes.Add(aporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Este metodo modifica un elemento a la base de datos.
        public static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(aporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //Este metodo elimina un elemento a la base de datos.
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var aporte = contexto.Aportes.Find(id);

                if (aporte != null)
                {
                    contexto.Aportes.Remove(aporte);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //Este metodo busca un elemento a la base de datos.
        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes aporte;

            try
            {
                aporte = contexto.Aportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return aporte;
        }


        //Este metodo define el criterio para la consulta del proyecto.
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> aporte)
        {
            Contexto contexto = new Contexto();
            List<Aportes> Lista = new List<Aportes>();

            try
            {
                Lista = contexto.Aportes.Where(aporte).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        //Este metodo comprueba si existe mas de un ID con el mismo valor en la base de datos.
        public static bool ExisteID(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(u => u.AporteID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static List<Aportes> GetUsuario()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
