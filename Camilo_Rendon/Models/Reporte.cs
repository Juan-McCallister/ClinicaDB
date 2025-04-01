using System;
using System.Collections.Generic;

namespace Camilo_Rendon.Models;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public int? IdMedico { get; set; }

    public int? TotalCitas { get; set; }

    public int? CitasCanceladas { get; set; }

    public int? CitasReprogramadas { get; set; }

    public string? PacientesFrecuentes { get; set; }

    public virtual Medico? IdMedicoNavigation { get; set; }
}
