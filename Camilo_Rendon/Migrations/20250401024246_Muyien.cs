using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Camilo_Rendon.Migrations
{
    /// <inheritdoc />
    public partial class Muyien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Medicos",
            //    columns: table => new
            //    {
            //        id_medico = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_completo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        especialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        correo_electronico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        horario_atencion = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Medicos__E038EB438DD6A80C", x => x.id_medico);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Pacientes",
            //    columns: table => new
            //    {
            //        id_paciente = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_completo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        numero_identificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        historial_medico = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Paciente__2C2C72BB5CFE1ED9", x => x.id_paciente);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Reportes",
            //    columns: table => new
            //    {
            //        id_reporte = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_medico = table.Column<int>(type: "int", nullable: true),
            //        total_citas = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
            //        citas_canceladas = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
            //        citas_reprogramadas = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
            //        pacientes_frecuentes = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Reportes__87E4F5CBD74FE01E", x => x.id_reporte);
            //        table.ForeignKey(
            //            name: "FK__Reportes__id_med__59063A47",
            //            column: x => x.id_medico,
            //            principalTable: "Medicos",
            //            principalColumn: "id_medico",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CitasMedicas",
            //    columns: table => new
            //    {
            //        id_cita = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_paciente = table.Column<int>(type: "int", nullable: false),
            //        id_medico = table.Column<int>(type: "int", nullable: false),
            //        fecha_hora = table.Column<DateTime>(type: "datetime", nullable: false),
            //        estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "Agendada")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__CitasMed__6AEC3C09F73290BF", x => x.id_cita);
            //        table.ForeignKey(
            //            name: "FK__CitasMedi__id_me__534D60F1",
            //            column: x => x.id_medico,
            //            principalTable: "Medicos",
            //            principalColumn: "id_medico");
            //        table.ForeignKey(
            //            name: "FK__CitasMedi__id_pa__52593CB8",
            //            column: x => x.id_paciente,
            //            principalTable: "Pacientes",
            //            principalColumn: "id_paciente");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CitasMedicas_id_paciente",
        //        table: "CitasMedicas",
        //        column: "id_paciente");

        //    migrationBuilder.CreateIndex(
        //        name: "UQ_Cita_Unica",
        //        table: "CitasMedicas",
        //        columns: new[] { "id_medico", "fecha_hora" },
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "UQ__Medicos__5B8A06827A34AFA0",
        //        table: "Medicos",
        //        column: "correo_electronico",
        //        unique: true,
        //        filter: "[correo_electronico] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "UQ__Paciente__C6DD4D32C5A6D1D5",
        //        table: "Pacientes",
        //        column: "numero_identificacion",
        //        unique: true,
        //        filter: "[numero_identificacion] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Reportes_id_medico",
        //        table: "Reportes",
        //        column: "id_medico");
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "CitasMedicas");

            //migrationBuilder.DropTable(
            //    name: "Reportes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Pacientes");

            //migrationBuilder.DropTable(
            //    name: "Medicos");
        }
    }
}
