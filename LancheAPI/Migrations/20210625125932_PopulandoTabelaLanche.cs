using Microsoft.EntityFrameworkCore.Migrations;

namespace LancheAPI.Migrations
{
    public partial class PopulandoTabelaLanche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Lanches](Categoria,DescricaoCurta,UrlImagem,UrlCapa,Nome,Preco) VALUES('Normal','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha','https://casa.abril.com.br/wp-content/uploads/2016/11/cheese-salada-01-credito-mauro-holanda.jpeg?quality=70&strip=all','http://radames.manosso.nom.br/linguagem/files/x-salada.jpg','Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Lanches](Categoria,DescricaoCurta,UrlImagem,UrlCapa,Nome,Preco) VALUES('Normal','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.','https://www.hellmanns.com.br/content/dam/unilever/global/recipe_image/116/11673/116733-default.jpg/_jcr_content/renditions/cq5dam.web.800.600.jpeg','https://craftlog.com/m/i/1507367=s1280=h960','Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Lanches](Categoria,DescricaoCurta,UrlImagem,UrlCapa,Nome,Preco) VALUES('Normal','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.','https://www.foodrepublic.com/wp-content/uploads/2012/03/033_FR11785.jpg','https://media.gettyimages.com/photos/cheeseburger-picture-id1159548717?s=612x612','Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Lanches](Categoria,DescricaoCurta,UrlImagem,UrlCapa,Nome,Preco) VALUES('Natural','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.','http://lanchoneteoficinadosabor.com.br/static/uploads/produto/be75ae2723bafcbaa5264b029ec9da05.jpg','http://lanchoneteoficinadosabor.com.br/static/uploads/produto/be75ae2723bafcbaa5264b029ec9da05.jpg','Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Lanches]");
        }
    }
}
