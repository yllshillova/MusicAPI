using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class PropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.scdn.co%2Fimage%2Fab67616d0000b27379bfa4a1649b0bd029d023d9&tbnid=8e-UmsgXBWypDM&vet=12ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMygnegUIARCpAQ..i&imgrefurl=https%3A%2F%2Fopen.spotify.com%2Falbum%2F6XgVBqUVSDb1a1JxyqIONf&docid=ZC7Sit_z_f-VqM&w=640&h=640&q=songs%20images&ved=2ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMygnegUIARCpAQ");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageURL",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fparade.com%2Fentertainment%2Fcountry-love-songs&psig=AOvVaw1dN6-pjGCaky0aqYuT6nkC&ust=1694985052754000&source=images&cd=vfe&opi=89978449&ved=2ahUKEwje34LBhbCBAxXq4AIHHd8sBgMQjRx6BAgAEAw");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURL",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.musicgrotto.com%2Fwp-content%2Fuploads%2F2022%2F01%2Fpop-songs-for-altos-graphic-art.jpg&tbnid=lHsryGeZ0P0J1M&vet=12ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMyg_egUIARDkAQ..i&imgrefurl=https%3A%2F%2Fwww.musicgrotto.com%2Falto-songs%2F&docid=r20AxsNhsYDcSM&w=1200&h=628&q=songs%20images&ved=2ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMyg_egUIARDkAQ");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageURL",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fassets.teenvogue.com%2Fphotos%2F64a5ba095699418416716eba%2F16%3A9%2Fw_2560%252Cc_limit%2F1474272248&tbnid=SDylMx7U2QQr3M&vet=12ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMyhEegUIARDwAQ..i&imgrefurl=https%3A%2F%2Fwww.teenvogue.com%2Fstory%2Fbest-unrequited-love-songs&docid=9E1-4Y4IDbsIHM&w=2560&h=1440&q=songs%20images&ved=2ahUKEwin_b2XhbCBAxXJ8LsIHX-8Aw0QMyhEegUIARDwAQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Songs");
        }
    }
}
