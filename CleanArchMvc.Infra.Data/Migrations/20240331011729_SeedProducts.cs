﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " + 
                "VALUES('Caderno espiral','Caderno Espiral 100 folhas',7.45,50,'caderno1.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Estojo escolar','Estojo escolar cinza',5.45,50,'estojo12.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
