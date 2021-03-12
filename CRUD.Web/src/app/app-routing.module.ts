//page
import { HomeComponent } from './pages/home/home.component';
import { CadastroClienteComponent } from './pages/cadastro-cliente/cadastro-cliente.component';

//package
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'cadastro-cliente',
    component: CadastroClienteComponent
  },
  {
    path: 'cadastro-cliente/:id',
    component: CadastroClienteComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
