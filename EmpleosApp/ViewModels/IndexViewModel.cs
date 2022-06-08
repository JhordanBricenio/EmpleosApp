using EmpleosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleosApp.ViewModels
{
    public class IndexViewModel : BaseModelo
    {
        public List<Vacante>? Vacantes { get; set; }
    }
}