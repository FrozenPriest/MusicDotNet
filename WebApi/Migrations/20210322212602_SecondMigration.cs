using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALBUM_ARTIST",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_SONG_ALBUM",
                table: "Song");

            migrationBuilder.AddForeignKey(
                name: "FK_ALBUM_ARTIST",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SONG_ALBUM",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALBUM_ARTIST",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_SONG_ALBUM",
                table: "Song");

            migrationBuilder.AddForeignKey(
                name: "FK_ALBUM_ARTIST",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SONG_ALBUM",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
