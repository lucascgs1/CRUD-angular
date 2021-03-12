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
  public cliente: Cliente = new Cliente();
  public isSubmited: boolean = false;
  public isEmailValid: boolean = false;

  public clienteForm: FormGroup = this.formBuilder.group({
    id: [0],
    dataCadastro: [new Date],
    nomeFantasia: ["", [Validators.required]],
    razaoSocial: ["", [Validators.required]],
    email: ["", [Validators.required, Validators.pattern("^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$"),],],
    cnpj: ["", [Validators.required]],
    telefone: ["", [Validators.required]],
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private clienteService: ClienteService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(
      (params) => {
        console.log(params["id"]);
        this.clienteId = params["id"] != null && params["id"] > 0 ? params["id"] : 0;
        if (this.clienteId > 0)
          this.iniciarFormulario();
      });
  }

  iniciarFormulario() {
    console.log
    if (this.clienteId != undefined && this.clienteId > 0) {
      this.clienteService.getClienteById(this.clienteId)
        .subscribe(
          result => {
            this.cliente = result;

            console.log(this.cliente)
            this.clienteForm = this.formBuilder.group({
              id: [this.cliente.id],
              dataCadastro: [this.cliente.dataCadastro],
              nomeFantasia: [this.cliente.nomeFantasia, [Validators.required]],
              razaoSocial: [this.cliente.razaoSocial, [Validators.required]],
              cnpj: [this.cliente.cnpj, [Validators.required]],
              telefone: [this.cliente.telefone, [Validators.required]],
              email: [this.cliente.email, [Validators.required, Validators.pattern("^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$"),],],
            });

            this.validateEmail(null);
          }
        );
    }
  }

  validateEmail(event: any) {
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    this.isEmailValid = !re.test(this.clienteForm.controls["email"].value);
    console.log(this.isEmailValid);
  }


  onSubmit() {
    console.log(this.clienteForm);
    console.log('teste');

    this.isSubmited = true;

    if (this.clienteForm.invalid) {
      return;
    }
    this.clienteService.postCliente(this.clienteForm.value)
      .subscribe(
        result => {
          this.router.navigate([""]);
        }
      );
  }


  delete() {
    this.clienteService.deleteClienteById(this.clienteId)
      .subscribe(
        result => {
          this.router.navigate([""]);
        }
      );
  }
}
