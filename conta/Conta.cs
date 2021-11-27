using System;

namespace dio.banco.conta
{
    public class Conta
    {
        private TipoConta Tipo{get;set;}
        private string Nome{get;set;}
        private double Saldo {get; set;}
        private double Credito {get;set;}

        public Conta(TipoConta tipo, string nome, double saldo, double credito)
        {
            this.Tipo=tipo;
            this.Nome = nome;
            this.Saldo=saldo;
            this.Credito=credito;
        }

        public bool Sacar(double valor){
            if(this.Saldo - valor < (this.Credito*-1)){
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }else{
                this.Saldo -= valor;
                Console.WriteLine("Sacou: {0}\nSaldo Atual: {1}", valor, this.Saldo);
                return true;
            }
        }

        public void Depositar(double valor){
            if(valor > 0){
                this.Saldo+=valor;
                Console.WriteLine("Depositou: {0}\nSaldo Atual: {1}", valor, this.Saldo);

            }
        }

        public void Transferir(double valor, Conta destino){
            if(Sacar(valor)){
                destino.Depositar(valor);
                Console.WriteLine("Transferiu: {0}\nSaldo Atual: {1}", valor, this.Saldo);
            }
        }

        public override string ToString()
        {
            string retorno = "Tipo Conta: "+this.Tipo+"\nNome: "+this.Nome+"\nSaldo: "+this.Saldo+"\nCrédito: "+this.Credito;
            return retorno;
        }
    }
}