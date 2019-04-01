using System;

class Prova{
  private static BancoDeDados bd = new BancoDeDados(); 
   private static Fabricante[] fabricantes = new Fabricante[3];
 public static void Main (string[] args) {
   Console.WriteLine("0:SAIR\n1:Inserir Fabricante\n2:Inserir Categoria\n3:Inserir Veiculo\n4:Listar veiculos\n5:Listar Categorias e Veiculos por Fabricante");
   int menu = int.Parse(Console.ReadLine());
   
   while(menu !=0){
 
     switch(menu){
       case 1: 
       InserirFabricante();
       break;

       case 2:
       InserirCategoria();
       break;

       case 3:
       InserirVeiculo();
       break;

       case 4:
       ListarVeiculos();
       break;

       case 5:
       ListarCategoriasVeiculosPorFabricante();
       break;
     }
     Console.WriteLine("0:Sair\n1:Inserir Fabricante\n2:Inserir Categoria\n3:Inserir Veículo\n4:Listar veiculos\n5:Listar Categorias e Veiculos por Fabricante");
     menu = int.Parse(Console.ReadLine());
   
   }
 }

 public static  void InserirFabricante(){
    Console.WriteLine ("Digite nome do fabricante");
    string nomeFabricante = Console.ReadLine();
    Console.WriteLine ("Digite País do Fabricante");
    string paisFabricante = Console.ReadLine();
    Fabricante f = new Fabricante(nomeFabricante, paisFabricante);
    bd.InserirFabricante(f);

  }

   
    public static void InserirCategoria(){
  Console.WriteLine ("Digite nome da categoria");
     string nomeCategoria = Console.ReadLine();
     Categoria c = new Categoria(nomeCategoria);
     bd.InserirCategoria(c);

     Fabricante[] fabricantes = bd.GetFabricantes();
      Console.WriteLine("Digite o número do Fabricante");
      for( int i = 0; i<fabricantes.Length; i++){
          Fabricante fabric = fabricantes[i];
          if (fabric != null){
            Console.WriteLine(i + "=" + fabric.GetNome());
          }
          
      }
       int menu = int.Parse(Console.ReadLine());
      Fabricante fabricanteSelecionado = fabricantes[menu];
      fabricanteSelecionado.Inserir(c);
       Console.WriteLine("Escolha condedida com sucesso!");


}

public static void InserirVeiculo(){
  Console.WriteLine("Digite o nome do veículo");
       string nome = Console.ReadLine();
       Veiculo v = new Veiculo(nome);
       Console.WriteLine("Digite o nome do motor do veículo");
       v.SetMotor(Console.ReadLine());
       Console.WriteLine("Digite o comprimento do veículo");
       v.SetComprimento(double.Parse(Console.ReadLine()));
       Console.WriteLine("Digite a largura do veículo");
       v.SetLargura(double.Parse(Console.ReadLine()));
       Console.WriteLine("Digite o valor do veículo");
       v.SetPreco(double.Parse(Console.ReadLine()));

       bd.InserirVeiculo(v);

      Categoria[] categorias = bd.GetCategorias();
      Console.WriteLine("Digite o número da Categoria");
      for( int i = 0; i<categorias.Length; i++){
          Categoria cat = categorias[i];
          if (cat != null){
            Console.WriteLine(i + "=" + cat.GetNome());
          }
      }
      int menu = int.Parse(Console.ReadLine());
      Categoria categoriaSelecionada = categorias[menu];
      categoriaSelecionada.Inserir(v);
       Console.WriteLine("Escolha condedida com sucesso!");


}

  public static void ListarVeiculos(){
    Categoria[] cats = bd.GetCategorias();
    Console.WriteLine("Categorias:");
    for(int j= 0; j<cats.Length; j++){
      Categoria c = cats[j];

      if(c!=null){
        Console.WriteLine($"\t{c.GetNome()}");
        Veiculo[] veiculos = c.Listar();

        for(int g= 0; g<veiculos.Length; g++){
          Veiculo b = veiculos[g];

          if(b!=null){
            Console.WriteLine($"Veículos: {b.GetNome()}");
          }
        }
      }
    }
  }
  

  public static void ListarCategoriasVeiculosPorFabricante(){
    Fabricante[] fabric = bd.GetFabricantes();
    Console.WriteLine("Fabricantes:");
     
    for( int i = 0; i<fabric.Length; i++){
      Fabricante f = fabric[i];
      if(f!=null){
        int total =0;
        Console.WriteLine($"Fabricante: {f.GetNome()}\nPaís:{f.GetPais()}");

      Categoria[] cats = f.Listar();
      
      for(int j= 0; j<cats.Length; j++){
        Categoria c = cats[j];
        if(c!=null){

          total += c.GetTotalDeVeiculos();
          Console.WriteLine($"Categoria: {c.GetNome()}");
          Veiculo[] veiculos = c.Listar();
          Console.WriteLine("Veículos: ");
          for(int g= 0; g<veiculos.Length; g++){
            Veiculo b = veiculos[g];
            if(b!=null){
              Console.WriteLine($"{b.GetNome()}");
            }
          }
        }
      }
       Console.WriteLine($"\nTotal de Veículos :{total}");
       Console.WriteLine();

        Console.WriteLine($"Veiculo de maior valor é: {f.MaiorValor().GetNome()}"); 
        Console.WriteLine("FIM!");
        Console.WriteLine();
      }
    
     }
   }


}
   