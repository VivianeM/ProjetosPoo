using System;
class BancoDeDados{
    private Categoria[] categorias = new Categoria[10];
    private Veiculo[] veiculos = new Veiculo[10];
    private Fabricante[] fabricantes = new Fabricante[10];
    int indiceCategoria = 0;
    int indiceVeiculo = 0;
    int indiceFabricante = 0;
    public void InserirCategoria(Categoria c){
        categorias[indiceCategoria++] = c;

    }
    public void InserirVeiculo(Veiculo v){
        veiculos[indiceVeiculo++] = v;
    }

    public Categoria[] GetCategorias(){
        return categorias;
    }

    public void InserirFabricante(Fabricante f){
        fabricantes[indiceFabricante++] = f;
    }

    public Fabricante[] GetFabricantes(){
        return fabricantes;
    }
}