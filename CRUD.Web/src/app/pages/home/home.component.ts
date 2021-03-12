//model
import { Cliente } from '../../core/model/cliente';

//service
import { ClienteService } from '../../core/service/cliente.service';

//package
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public clienteLst: Cliente[] = [];

  constructor(
    private clienteService: ClienteService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.getClienteList();
  }

  getClienteList(): void {
    this.clienteService.getAllClientes()
      .subscribe(
        result => {
          console.log(result);
          this.clienteLst = result;
        }
      );
  }
}

