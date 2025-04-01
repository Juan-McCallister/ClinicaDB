using System;
using System.Collections.Generic;

namespace Camilo_Rendon.Models;

public partial class CitasMedica
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdMedico { get; set; }

    public DateTime FechaHora { get; set; }

    public string? Estado { get; set; }

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
