﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class AddInitialsProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId,CreateDate,ModifiedDate)
                                   VALUES
                                   ('Caderno Espiral', 'Caderno Espiral 100 folhas', 7.40, 50, 'caderno1.jpg', 1, GetDate(),GetDate())");

            migrationBuilder.Sql(@"INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId,CreateDate,ModifiedDate)
                                   VALUES
                                   ('Estojo Escolar', 'Estojo escolar cinza', 5.65, 70, 'estojo1.jpg', 1, GetDate(),GetDate())");

            migrationBuilder.Sql(@"INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId,CreateDate,ModifiedDate)
                                   VALUES
                                   ('Borracha escolar', 'Borracha branca pequena', 3.25, 80, 'borracha1.jpg', 1, GetDate(),GetDate())");

            migrationBuilder.Sql(@"INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId,CreateDate,ModifiedDate)
                                   VALUES
                                   ('Calculadora escolar', 'Calculadora simples', 15.39,20, 'calculadora1.jpg', 2, GetDate(),GetDate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM Products");
        }
    }
}
