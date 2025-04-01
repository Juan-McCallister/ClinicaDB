using System;
using System.Collections.Generic;

namespace Camilo_Rendon.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string HorarioAtencion { get; set; } = null!;

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
