using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations;

/// <inheritdoc />
public partial class UpgradedToNet10 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Restaurants_WorkingSchedules_WorkingScheduleId",
            table: "Restaurants");

        migrationBuilder.DropIndex(
            name: "IX_Restaurants_WorkingScheduleId",
            table: "Restaurants");

        migrationBuilder.RenameColumn(
            name: "WorkingScheduleId",
            table: "Restaurants",
            newName: "CreatedBy");

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "WorkingSchedules",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "WorkingSchedules",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "WorkingSchedules",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "WorkingSchedules",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "WorkingSchedules",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "RestaurantDbEntityId",
            table: "WorkingSchedules",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "WorkingSchedules",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "WorkingSchedules",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "Restaurants",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "Restaurants",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "Restaurants",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Restaurants",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "Restaurants",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "Restaurants",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "Menus",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "Menus",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "Menus",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "Menus",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Menus",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "Menus",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "Menus",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "MenuItems",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "MenuItems",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "MenuItems",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "MenuItems",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "MenuItems",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "MenuItems",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "MenuItems",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "MenuItemCategories",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "MenuItemCategories",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "MenuItemCategories",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "MenuItemCategories",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "MenuItemCategories",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "MenuItemCategories",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "MenuItemCategories",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "MenuItemAvailabilities",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "MenuItemAvailabilities",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "MenuItemAvailabilities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "MenuItemAvailabilities",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "MenuItemAvailabilities",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "MenuItemAvailabilities",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "MenuItemAvailabilities",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedBy",
            table: "Addresses",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedDate",
            table: "Addresses",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "DeletedBy",
            table: "Addresses",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeletedDate",
            table: "Addresses",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Addresses",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<Guid>(
            name: "UpdatedBy",
            table: "Addresses",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedDate",
            table: "Addresses",
            type: "datetime2",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_WorkingSchedules_RestaurantDbEntityId",
            table: "WorkingSchedules",
            column: "RestaurantDbEntityId");

        migrationBuilder.AddForeignKey(
            name: "FK_WorkingSchedules_Restaurants_RestaurantDbEntityId",
            table: "WorkingSchedules",
            column: "RestaurantDbEntityId",
            principalTable: "Restaurants",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_WorkingSchedules_Restaurants_RestaurantDbEntityId",
            table: "WorkingSchedules");

        migrationBuilder.DropIndex(
            name: "IX_WorkingSchedules_RestaurantDbEntityId",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "RestaurantDbEntityId",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "WorkingSchedules");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "Restaurants");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "Menus");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "MenuItems");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "MenuItemCategories");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "MenuItemAvailabilities");

        migrationBuilder.DropColumn(
            name: "CreatedBy",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "CreatedDate",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "DeletedBy",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "DeletedDate",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "UpdatedBy",
            table: "Addresses");

        migrationBuilder.DropColumn(
            name: "UpdatedDate",
            table: "Addresses");

        migrationBuilder.RenameColumn(
            name: "CreatedBy",
            table: "Restaurants",
            newName: "WorkingScheduleId");

        migrationBuilder.CreateIndex(
            name: "IX_Restaurants_WorkingScheduleId",
            table: "Restaurants",
            column: "WorkingScheduleId");

        migrationBuilder.AddForeignKey(
            name: "FK_Restaurants_WorkingSchedules_WorkingScheduleId",
            table: "Restaurants",
            column: "WorkingScheduleId",
            principalTable: "WorkingSchedules",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
