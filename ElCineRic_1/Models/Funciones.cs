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
        public DataTable listaFunciones() {
            return adaFuncion.GetData();
        }
    }
}