using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using ElCineRic_1.DAL.DataSetFuncionTableAdapters;
namespace ElCineRic_1.Models
{
    public class Funciones
    {
        View_FuncionTableAdapter adaFuncion = new View_FuncionTableAdapter();
        

        public DataTable FuncionesDelDia(int idcine, int idmovie, int idsala, DateTime fecha)
        {
            return adaFuncion.GetDataFuncionByFechaSalaMovie(idcine, idmovie, idsala, fecha);
        }

        SillaTableAdapter adaSilla = new SillaTableAdapter();
        public DataTable ListadoSillas(int idfuncion)
        {
            return adaSilla.GetDataSillasByFuncion(idfuncion);
        }

        MovieTableAdapter adamovie = new MovieTableAdapter();
        public DataTable ListadoPeliculas()
        {
            return adamovie.GetData();
        }

        View_PeliculasHoyTableAdapter adapelishoy = new View_PeliculasHoyTableAdapter();
        public DataTable PeliculasHoy()
        {
            return adapelishoy.GetData();
        }

        SalaTableAdapter adasala = new SalaTableAdapter();
        public DataTable SalaByID(int id)
        {
            return adasala.GetDataSalaById(id);
        }

        public DataTable FuncionByID(int id)
        {
            return adaFuncion.GetDataFuncionById(id);
        }
        public void ActualizarSilla(int id_silla, bool estado)
        {
            adaSilla.UpdateEstadoSillaBySilla(estado, id_silla);
        }

        public DataTable ListadoMasBaratas(int idmovie)
        {
            return adaFuncion.GetDataTop10CheapestMovieByIDMovie(idmovie);
        }

        View_TotalxPeliculaTableAdapter adatotalxpelicula = new View_TotalxPeliculaTableAdapter();
        public DataTable Taquilleras()
        {
            return adatotalxpelicula.GetData();
        }

    }
}