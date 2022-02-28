using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using BLAZORREGISTRO.DAL;
using BLAZORREGISTRO.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BLAZORREGISTRO.BLL
{
    public class ProductosBLL
    {
        public static bool Existe(int productoId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Productos.Any(e => e.ProductoId == productoId);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }
        public static bool Existe(string descripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Productos.Any(e => e.Descripcion == descripcion);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;

        }
        private static bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Productos.Add(productos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }
        private static bool Modificar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;


        }

        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        public static bool Eliminar(int productoId)
        {

            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var librodeProductos = contexto.Productos.Find(productoId);
                if (librodeProductos != null)
                {
                    contexto.Productos.Remove(librodeProductos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static Productos? Buscar(int productoId)
        {


            Contexto contexto = new Contexto();
            Productos? producto;
            try
            {
                producto = contexto.Productos.Find(productoId);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;




        }
        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {


            Contexto contexto = new Contexto();
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = contexto.Productos.Where(criterio).ToList();
            }
            catch (System.Exception)
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