import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  transacoes = [
    {
      data: '2024-06-13',
      hora: '10:30',
      agencia: '1234',
      operacao: 'Débito',
      situacao: 'Concluída',
      valor: 150.75
    },
    {
      data: '2024-06-12',
      hora: '15:45',
      agencia: '5678',
      operacao: 'Crédito',
      situacao: 'Pendente',
      valor: 200.50
    },
    // Adicione quantas transações desejar
  ];
}
