//model
import { Cliente } from '../model/cliente';

//module
import { environment } from '../../../environments/environment';


//package
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { retry, catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }


  getClienteById(id: number): Observable<Cliente> {
    var url = environment.endPoints.cliente;

    return this.httpClient.get<Cliente>(url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getAllClientes(): Observable<Cliente[]> {
    var url = environment.endPoints.cliente;

    return this.httpClient.get<Cliente[]>(url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }


  postClienteById(cliente: Cliente): Observable<any> {
    var url = environment.endPoints.cliente;

    return this.httpClient.post(url, cliente, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }


  putClienteById(cliente: Cliente): Observable<any> {
    var url = environment.endPoints.cliente;

    return this.httpClient.put(url, cliente, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  deleteClienteById(id: number): Observable<Cliente> {
    var url = environment.endPoints.cliente;

    return this.httpClient.delete<Cliente>(url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }






  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
