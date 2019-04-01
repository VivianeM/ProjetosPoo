using System;

class Fabricante{
  private string nome;
  private string pais;
  private Categoria[] cats = new Categoria[5];
  private  int t = 0;

  public string GetNome(){
    return nome;
  }

  public string GetPais(){
    return pais;
  }

  public void Inserir(Categoria c){
    cats[t] = c;
    t++;
  
  }
public Categoria[] Listar(){
    return cats;
  }

  public Fabricante (string n, string p){
    nome = n;
    pais = p;
  }

  public Veiculo MaiorValor(){
   Veiculo maior = new Veiculo("","", 0,0,0);
    for( int i = 0; i<cats.Length; i++){
      Categoria c = cats[i];
      if(c != null){
         Veiculo v = c.MaiorValor();
       if(maior != null && v!= null && v.GetPreco()> maior.GetPreco()){
           maior = v;
        }
      }
     }  return maior;
    } 
  }
