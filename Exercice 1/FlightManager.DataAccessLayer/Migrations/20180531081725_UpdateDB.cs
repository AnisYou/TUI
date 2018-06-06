using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlightManager.DataAccessLayer.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightTime",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FlightType",
                table: "Flight");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FlightTime",
                table: "Flight",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FlightType",
                table: "Flight",
                nullable: true);
        }
    }
}
