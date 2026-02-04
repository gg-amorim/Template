using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class Test : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "public");

        migrationBuilder.CreateTable(
            name: "clients",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                phone = table.Column<string>(type: "text", nullable: true),
                email = table.Column<string>(type: "text", nullable: true),
                dietary_restrictions = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_clients", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "dishes",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                photo_url = table.Column<string>(type: "text", nullable: true),
                sale_price = table.Column<decimal>(type: "numeric", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_dishes", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "ingredients",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                unit = table.Column<int>(type: "integer", nullable: false),
                cost_price = table.Column<decimal>(type: "numeric", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_ingredients", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "menus",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_menus", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "users",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                password_hash = table.Column<string>(type: "text", nullable: false),
                code_confirmation_token = table.Column<string>(type: "text", nullable: true),
                code_confirmation_token_expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_users", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "dish_ingredients",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                dish_id = table.Column<Guid>(type: "uuid", nullable: false),
                ingredient_id = table.Column<Guid>(type: "uuid", nullable: false),
                quantity = table.Column<decimal>(type: "numeric", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_dish_ingredients", x => x.id);
                table.ForeignKey(
                    name: "fk_dish_ingredients_dishes_dish_id",
                    column: x => x.dish_id,
                    principalSchema: "public",
                    principalTable: "dishes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_dish_ingredients_ingredients_ingredient_id",
                    column: x => x.ingredient_id,
                    principalSchema: "public",
                    principalTable: "ingredients",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "events",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                event_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                number_of_guests = table.Column<int>(type: "integer", nullable: false),
                address = table.Column<string>(type: "text", nullable: true),
                status = table.Column<int>(type: "integer", nullable: false),
                agreed_price = table.Column<decimal>(type: "numeric", nullable: false),
                cost_estimate = table.Column<decimal>(type: "numeric", nullable: false),
                client_id = table.Column<Guid>(type: "uuid", nullable: false),
                menu_id = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_events", x => x.id);
                table.ForeignKey(
                    name: "fk_events_clients_client_id",
                    column: x => x.client_id,
                    principalSchema: "public",
                    principalTable: "clients",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_events_menus_menu_id",
                    column: x => x.menu_id,
                    principalSchema: "public",
                    principalTable: "menus",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "menu_dishes",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                menu_id = table.Column<Guid>(type: "uuid", nullable: false),
                dish_id = table.Column<Guid>(type: "uuid", nullable: false),
                category = table.Column<int>(type: "integer", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_menu_dishes", x => x.id);
                table.ForeignKey(
                    name: "fk_menu_dishes_dishes_dish_id",
                    column: x => x.dish_id,
                    principalSchema: "public",
                    principalTable: "dishes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_menu_dishes_menus_menu_id",
                    column: x => x.menu_id,
                    principalSchema: "public",
                    principalTable: "menus",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "shopping_lists",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                event_id = table.Column<Guid>(type: "uuid", nullable: false),
                is_completed = table.Column<bool>(type: "boolean", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_shopping_lists", x => x.id);
                table.ForeignKey(
                    name: "fk_shopping_lists_events_event_id",
                    column: x => x.event_id,
                    principalSchema: "public",
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "shopping_list_itens",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                shopping_list_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                unit = table.Column<string>(type: "text", nullable: false),
                quantity_needed = table.Column<decimal>(type: "numeric", nullable: false),
                is_checked = table.Column<bool>(type: "boolean", nullable: false),
                original_ingredient_id = table.Column<Guid>(type: "uuid", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                is_inactive = table.Column<bool>(type: "boolean", nullable: false),
                id_tmp = table.Column<int>(type: "integer", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_shopping_list_itens", x => x.id);
                table.ForeignKey(
                    name: "fk_shopping_list_itens_shopping_lists_shopping_list_id",
                    column: x => x.shopping_list_id,
                    principalSchema: "public",
                    principalTable: "shopping_lists",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "ix_dish_ingredients_dish_id",
            schema: "public",
            table: "dish_ingredients",
            column: "dish_id");

        migrationBuilder.CreateIndex(
            name: "ix_dish_ingredients_ingredient_id",
            schema: "public",
            table: "dish_ingredients",
            column: "ingredient_id");

        migrationBuilder.CreateIndex(
            name: "ix_events_client_id",
            schema: "public",
            table: "events",
            column: "client_id");

        migrationBuilder.CreateIndex(
            name: "ix_events_menu_id",
            schema: "public",
            table: "events",
            column: "menu_id");

        migrationBuilder.CreateIndex(
            name: "ix_menu_dishes_dish_id",
            schema: "public",
            table: "menu_dishes",
            column: "dish_id");

        migrationBuilder.CreateIndex(
            name: "ix_menu_dishes_menu_id",
            schema: "public",
            table: "menu_dishes",
            column: "menu_id");

        migrationBuilder.CreateIndex(
            name: "ix_shopping_list_itens_shopping_list_id",
            schema: "public",
            table: "shopping_list_itens",
            column: "shopping_list_id");

        migrationBuilder.CreateIndex(
            name: "ix_shopping_lists_event_id",
            schema: "public",
            table: "shopping_lists",
            column: "event_id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_users_email",
            schema: "public",
            table: "users",
            column: "email",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "dish_ingredients",
            schema: "public");

        migrationBuilder.DropTable(
            name: "menu_dishes",
            schema: "public");

        migrationBuilder.DropTable(
            name: "shopping_list_itens",
            schema: "public");

        migrationBuilder.DropTable(
            name: "users",
            schema: "public");

        migrationBuilder.DropTable(
            name: "ingredients",
            schema: "public");

        migrationBuilder.DropTable(
            name: "dishes",
            schema: "public");

        migrationBuilder.DropTable(
            name: "shopping_lists",
            schema: "public");

        migrationBuilder.DropTable(
            name: "events",
            schema: "public");

        migrationBuilder.DropTable(
            name: "clients",
            schema: "public");

        migrationBuilder.DropTable(
            name: "menus",
            schema: "public");
    }
}
