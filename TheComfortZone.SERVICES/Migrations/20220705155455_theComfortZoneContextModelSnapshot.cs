using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheComfortZone.SERVICES.Migrations
{
    public partial class theComfortZoneContextModelSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentType",
                columns: table => new
                {
                    AppointmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.AppointmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    DesignerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ConsultationPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.DesignerID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialID);
                });

            migrationBuilder.CreateTable(
                name: "MetricUnit",
                columns: table => new
                {
                    MetricUnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricUnit", x => x.MetricUnitID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Space",
                columns: table => new
                {
                    SpaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Space", x => x.SpaceID);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    DesignerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.CollectionID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_3",
                        column: x => x.DesignerID,
                        principalTable: "Designer",
                        principalColumn: "DesignerID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Adress = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_20",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SpaceID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_2",
                        column: x => x.SpaceID,
                        principalTable: "Space",
                        principalColumn: "SpaceID");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DesignerID = table.Column<int>(type: "int", nullable: false),
                    AppointmentTypeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    AppointmentNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_16",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_17",
                        column: x => x.DesignerID,
                        principalTable: "Designer",
                        principalColumn: "DesignerID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_18",
                        column: x => x.AppointmentTypeID,
                        principalTable: "AppointmentType",
                        principalColumn: "AppointmentTypeID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_22",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_15",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    NOIP = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<float>(type: "real", nullable: true),
                    UsedDiscountCoupon = table.Column<bool>(type: "bit", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_10",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_21",
                        column: x => x.EmployeeID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "FurnitureItem",
                columns: table => new
                {
                    FurnitureItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CollectionID = table.Column<int>(type: "int", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: false),
                    RegularPrice = table.Column<float>(type: "real", nullable: false),
                    DiscountPrice = table.Column<float>(type: "real", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    State = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Favourited = table.Column<bool>(type: "bit", nullable: true),
                    MetricUnitID = table.Column<int>(type: "int", nullable: false),
                    InStockQuantity = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Width = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureItem", x => x.FurnitureItemID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_1",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_19",
                        column: x => x.MetricUnitID,
                        principalTable: "MetricUnit",
                        principalColumn: "MetricUnitID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_4",
                        column: x => x.CollectionID,
                        principalTable: "Collection",
                        principalColumn: "CollectionID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_5",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "MaterialID");
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    FavouriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureItemID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.FavouriteID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_13",
                        column: x => x.FurnitureItemID,
                        principalTable: "FurnitureItem",
                        principalColumn: "FurnitureItemID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_14",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "FurnitureColor",
                columns: table => new
                {
                    FurnitureColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    FurnitureItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureColor", x => x.FurnitureColorID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_6",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ColorID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_7",
                        column: x => x.FurnitureItemID,
                        principalTable: "FurnitureItem",
                        principalColumn: "FurnitureItemID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureItemID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_REFERENCE_11",
                        column: x => x.FurnitureItemID,
                        principalTable: "FurnitureItem",
                        principalColumn: "FurnitureItemID");
                    table.ForeignKey(
                        name: "FK_REFERENCE_12",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentTypeID",
                table: "Appointment",
                column: "AppointmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DesignerID",
                table: "Appointment",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_EmployeeID",
                table: "Appointment",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserID",
                table: "Appointment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SpaceID",
                table: "Category",
                column: "SpaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_DesignerID",
                table: "Collection",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_UserID",
                table: "Coupon",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_FurnitureItemID",
                table: "Favourite",
                column: "FurnitureItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_UserID",
                table: "Favourite",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureColor_ColorID",
                table: "FurnitureColor",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureColor_FurnitureItemID",
                table: "FurnitureColor",
                column: "FurnitureItemID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureItem_CategoryID",
                table: "FurnitureItem",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureItem_CollectionID",
                table: "FurnitureItem",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureItem_MaterialID",
                table: "FurnitureItem",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureItem_MetricUnitID",
                table: "FurnitureItem",
                column: "MetricUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_FurnitureItemID",
                table: "OrderItem",
                column: "FurnitureItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "FurnitureColor");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "AppointmentType");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "FurnitureItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MetricUnit");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Space");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
