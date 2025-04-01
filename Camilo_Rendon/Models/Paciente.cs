using System;
using System.Collections.Generic;

namespace Camilo_Rendon.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? HistorialMedico { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();
}
