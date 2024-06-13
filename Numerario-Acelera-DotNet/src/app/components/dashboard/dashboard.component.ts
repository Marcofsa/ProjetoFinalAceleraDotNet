import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  transacoes: any[] = [
    {
      data: '2024-06-12',
      hora: '10:30',
      agencia: '1234',
      operacao: 'Depósito',
      situacao: 'Concluída',
      valor: 1000.00
    },
    {
      data: '2024-06-13',
      hora: '11:00',
      agencia: '5678',
      operacao: 'Saque',
      situacao: 'Pendente',
      valor: 500.00
    },
    {
      data: '2024-06-14',
      hora: '15:45',
      agencia: '9876',
      operacao: 'Transferência',
      situacao: 'Concluída',
      valor: 750.00
    },
    {
      data: '2024-06-15',
      hora: '09:15',
      agencia: '4321',
      operacao: 'Pagamento',
      situacao: 'Pendente',
      valor: 200.00
    },
    {
      data: '2024-06-16',
      hora: '14:20',
      agencia: '1357',
      operacao: 'Depósito',
      situacao: 'Concluída',
      valor: 3000.00
    }
  ];

  constructor() {
    // Aqui você poderia inicializar a propriedade transacoes com dados de um serviço, se necessário
  }
}
