export class Cliente {
  constructor() {
    this.id = 0;
    this.nomeFantasia = "";
    this.razaoSocial = "";
    this.cnpj = "";
    this.email = "";
    this.telefone = "";
    this.dataCadastro = new Date();
  }

  id: number;
  nomeFantasia: string;
  razaoSocial: string;
  email: string;
  cnpj: string;
  telefone: string;
  dataCadastro: Date;
}
