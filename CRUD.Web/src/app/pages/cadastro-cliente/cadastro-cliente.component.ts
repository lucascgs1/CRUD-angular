//model
import { Cliente } from '../../core/model/cliente';

//service
import { ClienteService } from '../../core/service/cliente.service';

//package
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, } from "@angular/forms";

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
  styleUrls: ['./cadastro-cliente.component.scss']
})

export class CadastroClienteComponent implements OnInit {

  public clienteId: number = 0;
  public cliente: Cliente = new Cliente;
  public telefone: any;
  public cnpj: any;
  public isSubmited: boolean = false;

  public clienteForm: FormGroup = this.formBuilder.group({
    nomeFantasia: ["", [Validators.required]],
    razaoSocial: ["", [Validators.required]],
    email: ["", [Validators.required, Validators.pattern("^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$"),],],
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private clienteService: ClienteService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {


    console.log(this.clienteForm);
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(
      (params) => {
        this.clienteId = params["id"] != null && params["id"] > 0 ? params["id"] : 0;

        this.iniciarFormulario();

        console.log(this.clienteId);
      });
  }

  iniciarFormulario() {
    //if (this.cliente != undefined && this.cliente.id > 0) {
    //  this.clienteForm = this.formBuilder.group({
    //    nomeFantasia: [this.cliente.nomeFantasia],
    //    razaoSocial: [this.cliente.razaoSocial],
    //    email: [this.cliente.email, [Validators.required, Validators.pattern("^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$"),],],
    //  });

    //  this.telefone = this.cliente.telefone;
    //  this.cnpj = this.cliente.cnpj;
    //}
  }

  getCliente() {
    if (this.clienteId > 0) {
      this.clienteService.getClienteById(this.clienteId)
        .subscribe(
          result => {
            this.cliente = result;

            console.log(this.cliente);
          }
        );
    }
  }

  voltar() {
    this.router.navigate([""]);
  }

  onSubmit() {
    console.log(this.clienteForm);
    console.log('teste');

    this.isSubmited = true;

    if (this.clienteForm.invalid) {
      return;
    }


  }
}
