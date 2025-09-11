using AppBlazor.Entities;
using System;

namespace AppBlazor.Client.Services
{
    public class LibroService
    {
        private List<LibroListCLS> lista;
        private TipoLibroService tipolibroservice;
        public LibroService(TipoLibroService _tipolibroservice)
        {
            tipolibroservice = _tipolibroservice;
            lista = new List<LibroListCLS>();
            lista.Add(new LibroListCLS { idLibro= 1, titulo="Libro 1", nombreTipoLibro="Cuento"});
            lista.Add(new LibroListCLS { idLibro = 2, titulo = "Libro 2", nombreTipoLibro = "Novela" });
        }
        public List<LibroListCLS> listarLibros()
        {
            return lista;
        }
        public void eliminarLibros(int idlibro)
        {
            var listaQueda = lista.Where(p => p.idLibro != idlibro).ToList();
           lista = listaQueda;
        }


        public LibroFormCLS recuperarLibroPorId(int idlibro)
        {
            var obj = lista.Where(p => p.idLibro == idlibro).FirstOrDefault();
            if (obj != null)
            {
                return new LibroFormCLS
                {
                    idLibro = obj.idLibro,
                    titulo = obj.titulo,
                    resumen = "ResumenResumenResumenResumenResumen",
                    idTipoLibro = tipolibroservice.ObtenerIdTipoLibro(obj.nombreTipoLibro), image = obj.imagen // Usamos el nuevo método para obtener el ID
                };
            }
            else
            {
                return new LibroFormCLS();
            }
        }


        public void guardarLibro(LibroFormCLS oLibroFormCLS)
        {
            if(oLibroFormCLS.idLibro == 0)
            {
                int idLibro = lista.Select(p => p.idLibro).Max() + 1;
                lista.Add(new LibroListCLS
                {
                    idLibro = idLibro,
                    titulo = oLibroFormCLS.titulo,
                    nombreTipoLibro = tipolibroservice.ObtenerTipoLibro(oLibroFormCLS.idTipoLibro),

                    imagen = oLibroFormCLS.image // Asignar la imagen si está disponible
                });
            }
            else
            {
                var obj = lista.Where(p => p.idLibro == oLibroFormCLS.idLibro).FirstOrDefault();
                if (obj != null)
                {
                    obj.titulo = oLibroFormCLS.titulo;
                    obj.nombreTipoLibro = tipolibroservice.ObtenerNombreTipoLibro(oLibroFormCLS.idTipoLibro);
                    obj.imagen = oLibroFormCLS.image;
                }
            }
                
        }

        public void actualizarLibro(LibroFormCLS oLibroFormCLS) //LibroFormCLS libro
        {
            /*var libroExistente = lista.FirstOrDefault(l => l.idLibro == libro.idLibro);

            if (libroExistente != null)
            {
                libroExistente.titulo = libro.titulo;
                libroExistente.resumen = libro.resumen;
            }
            else
            {
                throw new Exception("Libro no encontrado para actualizar.");
            }*/
            if (oLibroFormCLS.idLibro == 0)
            {
                int idLibro = lista.Select(p => p.idLibro).Max() + 1;
                lista.Add(new LibroListCLS
                {
                    idLibro = idLibro,
                    titulo = oLibroFormCLS.titulo,
                    nombreTipoLibro = tipolibroservice.ObtenerTipoLibro(oLibroFormCLS.idTipoLibro)
                });
            }
            else
            {
                var obj = lista.Where(p => p.idLibro == oLibroFormCLS.idLibro).FirstOrDefault();
                if (obj != null)
                {
                    obj.titulo = oLibroFormCLS.titulo;
                    obj.nombreTipoLibro = tipolibroservice.ObtenerNombreTipoLibro(oLibroFormCLS.idTipoLibro);
                }
            }
        }

    }
}
